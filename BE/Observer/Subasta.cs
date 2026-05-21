using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BE
{
    public class Subasta
    {
        private readonly List<IObserver> _suscriptores = new List<IObserver>();

        public int Id { get; set; }
        public UnidadDeVenta ItemSubastado { get; set; }
        public decimal OfertaActual { get; private set; }
        public Postor PostorGanador { get; private set; }
        public bool Activa { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime? FechaCierre { get; private set; }

        public event Action<string> OnNotificacion;
        public event Action<IObserver, string> OnNotificacionSuscriptor;

        public Subasta(int id, UnidadDeVenta item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Id = id;
            ItemSubastado = item;
            OfertaActual = item.ObtenerPrecio();
            PostorGanador = null;
            Activa = true;
            FechaInicio = DateTime.Now;
        }

        public void Suscribir(IObserver observador)
        {
            if (observador == null)
                throw new ArgumentNullException(nameof(observador));
            if (_suscriptores.Exists(s => s.Id == observador.Id))
                throw new InvalidOperationException($"{observador.NombrePostor} ya está suscripto.");
            _suscriptores.Add(observador);
        }

        public void Desuscribir(IObserver observador)
        {
            if (observador == null)
                throw new ArgumentNullException(nameof(observador));
            _suscriptores.RemoveAll(s => s.Id == observador.Id);
        }

        public bool EstaSuscripto(int postorId)
            => _suscriptores.Exists(s => s.Id == postorId);

        public IReadOnlyList<IObserver> ObtenerSuscriptores()
            => new ReadOnlyCollection<IObserver>(_suscriptores);

        public void NotificarSuscriptores(string mensaje)
        {
            foreach (var suscriptor in _suscriptores)
            {
                suscriptor.Actualizar(mensaje);
                OnNotificacionSuscriptor?.Invoke(suscriptor, mensaje);
            }
            OnNotificacion?.Invoke(mensaje);
        }

        public void AplicarOferta(decimal monto, Postor postor)
        {
            if (!Activa)
                throw new InvalidOperationException("No se puede ofertar: la subasta está cerrada.");
            if (monto <= OfertaActual)
                throw new ArgumentException($"La oferta debe superar ${OfertaActual:N2}.");
            OfertaActual = monto;
            PostorGanador = postor;
        }

        public void Cerrar()
        {
            Activa = false;
            FechaCierre = DateTime.Now;
        }

        public override string ToString()
            => $"Subasta #{Id} – {ItemSubastado?.Nombre} | Precio: ${OfertaActual:N2}";
    }
}
