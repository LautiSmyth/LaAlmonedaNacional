using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UnidadDeVentaBLL
    {
        private readonly UnidadDeVentaDAL _dal = new UnidadDeVentaDAL();

        public Articulo CrearArticulo(string nombre, string descripcion, decimal precioBase)
        {
            ValidarNombre(nombre);
            if (precioBase < 0)
                throw new ArgumentOutOfRangeException(nameof(precioBase), "El precio base no puede ser negativo.");
            var articulo = new Articulo(nombre, descripcion, precioBase);
            _dal.GuardarArticulo(articulo);
            AuditoriaServicio.RegistrarLog($"Artículo creado: '{nombre}' (${precioBase:N2}) Id={articulo.Id}");
            return articulo;
        }

        public void ActualizarArticulo(Articulo articulo)
        {
            if (articulo == null) throw new ArgumentNullException(nameof(articulo));
            ValidarNombre(articulo.Nombre);
            if (articulo.PrecioBase < 0)
                throw new ArgumentOutOfRangeException("El precio base no puede ser negativo.");
            _dal.ActualizarArticulo(articulo);
            AuditoriaServicio.RegistrarLog($"Artículo actualizado: Id={articulo.Id} '{articulo.Nombre}'");
        }

        public void EliminarUnidad(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.");
            _dal.Eliminar(id);
            AuditoriaServicio.RegistrarLog($"Unidad de venta eliminada: Id={id}");
        }

        public List<Articulo> ObtenerArticulos() => _dal.ObtenerArticulos();

        public Lote CrearLote(string nombre, string descripcion)
        {
            ValidarNombre(nombre);
            var lote = new Lote(nombre, descripcion);
            _dal.GuardarLote(lote);
            AuditoriaServicio.RegistrarLog($"Lote creado: '{nombre}' Id={lote.Id}");
            return lote;
        }

        public void ActualizarLote(Lote lote)
        {
            if (lote == null) throw new ArgumentNullException(nameof(lote));
            ValidarNombre(lote.Nombre);
            _dal.ActualizarLote(lote);
            AuditoriaServicio.RegistrarLog($"Lote actualizado: Id={lote.Id} '{lote.Nombre}'");
        }

        public List<Lote> ObtenerLotes() => _dal.ObtenerLotes();

        public void AgregarComponente(int idLotePadre, int idComponenteHijo)
        {
            if (idLotePadre == idComponenteHijo)
                throw new InvalidOperationException("Un lote no puede contenerse a sí mismo.");
            UnidadDeVenta padre = _dal.ObtenerPorId(idLotePadre);
            if (padre == null)
                throw new InvalidOperationException($"No existe unidad con Id={idLotePadre}.");
            if (!(padre is Lote))
                throw new InvalidOperationException("El elemento padre debe ser un Lote.");
            _dal.GuardarRelacionLote(idLotePadre, idComponenteHijo);
            AuditoriaServicio.RegistrarLog($"Componente #{idComponenteHijo} agregado al lote #{idLotePadre}");
        }

        public void QuitarComponente(int idLotePadre, int idComponenteHijo)
        {
            _dal.EliminarRelacionLote(idLotePadre, idComponenteHijo);
            AuditoriaServicio.RegistrarLog($"Componente #{idComponenteHijo} removido del lote #{idLotePadre}");
        }

        public int ObtenerLotePadreDeComponente(int componenteId)
            => _dal.ObtenerLotePadreDeComponente(componenteId);

        public void MoverComponente(int idLotePadreActual, int idLotePadreNuevo, int idComponente)
        {
            _dal.EliminarRelacionLote(idLotePadreActual, idComponente);
            _dal.GuardarRelacionLote(idLotePadreNuevo, idComponente);
            AuditoriaServicio.RegistrarLog(
                $"Componente #{idComponente} movido del lote #{idLotePadreActual} al #{idLotePadreNuevo}");
        }

        public void EliminarLoteConContenido(int idLote)
        {
            if (idLote <= 0) throw new ArgumentException("Id inválido.");
            _dal.EliminarRecursivo(idLote);
            AuditoriaServicio.RegistrarLog($"Lote #{idLote} eliminado con todo su contenido (composición)");
        }

        public void EliminarLoteSinContenido(int idLote)
        {
            if (idLote <= 0) throw new ArgumentException("Id inválido.");
            _dal.DesvinculrComponentes(idLote);
            _dal.Eliminar(idLote);
            AuditoriaServicio.RegistrarLog($"Lote #{idLote} eliminado; componentes desvinculados y conservados en inventario");
        }

        public List<UnidadDeVenta> ObtenerCatalogo() => _dal.ObtenerTodos();

        public UnidadDeVenta ObtenerPorId(int id) => _dal.ObtenerPorId(id);

        public string ObtenerDetallesCompletos(int id)
        {
            UnidadDeVenta udv = _dal.ObtenerPorId(id);
            if (udv == null) throw new InvalidOperationException($"No existe la unidad #{id}.");
            return udv.ObtenerDetalles();
        }

        public decimal ObtenerPrecio(int id)
        {
            UnidadDeVenta udv = _dal.ObtenerPorId(id);
            if (udv == null) throw new InvalidOperationException($"No existe la unidad #{id}.");
            return udv.ObtenerPrecio();
        }

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (nombre.Length > 200)
                throw new ArgumentException("El nombre no puede superar los 200 caracteres.");
        }
    }
}
