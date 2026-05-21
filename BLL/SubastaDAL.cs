using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class SubastaBLL
    {
        private static readonly Dictionary<int, Subasta> _activas = new Dictionary<int, Subasta>();
        private static readonly object _lockPuja = new object();

        private readonly SubastaDAL _subastaDAL = new SubastaDAL();
        private readonly PostorDAL _postorDAL = new PostorDAL();
        private readonly SuscripcionDAL _suscripcionDAL = new SuscripcionDAL();
        private readonly UnidadDeVentaDAL _udvDAL = new UnidadDeVentaDAL();

        public bool VerificarConexion() => Acceso.GetInstance().VerificarConexion();

        public Subasta CrearSubasta(int unidadVentaId)
        {
            UnidadDeVenta item = _udvDAL.ObtenerPorId(unidadVentaId);
            if (item == null)
                throw new InvalidOperationException($"No existe la unidad de venta #{unidadVentaId}.");
            foreach (var s in _activas.Values)
            {
                if (s.ItemSubastado.Id == unidadVentaId && s.Activa)
                    throw new InvalidOperationException($"Ya existe una subasta activa para '{item.Nombre}'.");
            }
            int nuevoId = _subastaDAL.CrearSubasta(unidadVentaId, item.ObtenerPrecio());
            var subasta = new Subasta(nuevoId, item);
            lock (_lockPuja)
                _activas[nuevoId] = subasta;
            AuditoriaService.RegistrarLog($"Subasta #{nuevoId} creada: '{item.Nombre}' (Base: ${item.ObtenerPrecio():N2})");
            return subasta;
        }

        public void Suscribir(int subastaId, int postorId)
        {
            Subasta subasta = ObtenerSubastaActiva(subastaId);
            Postor postor = _postorDAL.ObtenerPorId(postorId)
                ?? throw new InvalidOperationException($"No existe el postor #{postorId}.");
            if (subasta.EstaSuscripto(postorId))
                throw new InvalidOperationException($"{postor.NombrePostor} ya está suscripto a esta subasta.");
            subasta.Suscribir(postor);
            _suscripcionDAL.Suscribir(subastaId, postorId);
            AuditoriaService.RegistrarLog($"Postor '{postor.NombrePostor}' suscripto a subasta #{subastaId}");
        }

        public void Desuscribir(int subastaId, int postorId)
        {
            Subasta subasta = ObtenerSubastaActiva(subastaId);
            Postor postor = _postorDAL.ObtenerPorId(postorId)
                ?? throw new InvalidOperationException($"No existe el postor #{postorId}.");
            subasta.Desuscribir(postor);
            _suscripcionDAL.Desuscribir(subastaId, postorId);
            AuditoriaService.RegistrarLog($"Postor '{postor.NombrePostor}' desuscripto de subasta #{subastaId}");
        }

        public void RealizarOferta(int subastaId, int postorId, decimal monto, Action<string> notificacionGui = null)
        {
            lock (_lockPuja)
            {
                Subasta subasta = ObtenerSubastaActiva(subastaId);
                Postor postor = _postorDAL.ObtenerPorId(postorId)
                    ?? throw new InvalidOperationException($"Postor #{postorId} no encontrado.");
                if (monto <= subasta.OfertaActual)
                    throw new ArgumentException(
                        $"La oferta de ${monto:N2} debe superar el precio actual de ${subasta.OfertaActual:N2}.");
                postor.OnNotificacion = notificacionGui;
                _subastaDAL.ActualizarOferta(subastaId, monto, postorId);
                subasta.AplicarOferta(monto, postor);
                string msg = $"Nueva oferta: ${monto:N2} por {postor.NombrePostor} en '{subasta.ItemSubastado.Nombre}'";
                subasta.NotificarSuscriptores(msg);
                AuditoriaService.RegistrarLog($"Oferta: Subasta #{subastaId} | {postor.NombrePostor} → ${monto:N2}");
            }
        }

        public void CerrarSubasta(int subastaId)
        {
            lock (_lockPuja)
            {
                Subasta subasta = ObtenerSubastaActiva(subastaId);
                subasta.Cerrar();
                _subastaDAL.CerrarSubasta(subastaId, subasta.FechaCierre.Value);
                string msg;
                if (subasta.PostorGanador != null)
                {
                    _subastaDAL.PersistirFinDeSubasta(
                        subastaId,
                        subasta.ItemSubastado.Id,
                        subasta.ItemSubastado.Nombre,
                        subasta.OfertaActual,
                        subasta.PostorGanador.Id,
                        subasta.PostorGanador.NombrePostor,
                        subasta.PostorGanador.Email);
                    msg = $"SUBASTA CERRADA | Ganador: {subasta.PostorGanador.NombrePostor} | Precio final: ${subasta.OfertaActual:N2}";
                }
                else
                {
                    msg = $"Subasta '{subasta.ItemSubastado.Nombre}' cerrada sin postores.";
                }
                subasta.NotificarSuscriptores(msg);
                AuditoriaService.RegistrarLog($"Subasta #{subastaId} cerrada. " + msg);
                _activas.Remove(subastaId);
            }
        }

        public void ConfigurarNotificacionGui(int subastaId, Action<string> notificacionGui)
        {
            if (!_activas.TryGetValue(subastaId, out Subasta subasta)) return;
            subasta.OnNotificacion += notificacionGui;
        }

        public Subasta ObtenerSubastaEnMemoria(int id)
        {
            _activas.TryGetValue(id, out Subasta s);
            return s;
        }

        public void CargarSubastasActivas()
        {
            try
            {
                DataTable tabla = _subastaDAL.ObtenerActivas();
                lock (_lockPuja)
                {
                    _activas.Clear();
                    foreach (DataRow fila in tabla.Rows)
                    {
                        int id = Convert.ToInt32(fila["Id"]);
                        int udvId = Convert.ToInt32(fila["UnidadVentaId"]);
                        UnidadDeVenta item = _udvDAL.ObtenerPorId(udvId);
                        if (item == null) continue;
                        var subasta = new Subasta(id, item);
                        _activas[id] = subasta;
                        List<Postor> suscriptores = _postorDAL.ObtenerSuscriptores(id);
                        foreach (var p in suscriptores)
                            subasta.Suscribir(p);
                    }
                }
            }
            catch (Exception ex)
            {
                AuditoriaService.RegistrarLog($"[ERROR] CargarSubastasActivas: {ex.Message}");
            }
        }

        public DataTable ObtenerSubastasActivas() => _subastaDAL.ObtenerActivas();
        public DataTable ObtenerHistorial() => _subastaDAL.ObtenerHistorial();

        private Subasta ObtenerSubastaActiva(int subastaId)
        {
            if (!_activas.TryGetValue(subastaId, out Subasta subasta))
                throw new InvalidOperationException(
                    $"La subasta #{subastaId} no está activa o no existe en memoria. Recargue la lista.");
            if (!subasta.Activa)
                throw new InvalidOperationException($"La subasta #{subastaId} ya fue cerrada.");
            return subasta;
        }
    }
}
