using System.Collections.Generic;

namespace BE
{
    public class Subasta
    {
        private readonly List<IObserver> _subscriptores = new List<IObserver>();

        public int Id { get; set; }
        public UnidadDeVenta ItemSubastado { get; set; }
        public decimal OfertaActual { get; set; }
        public string NombreGanadorActual { get; set; }
        public bool Activa { get; set; }

        public Subasta(int id, UnidadDeVenta item)
        {
            Id = id;
            ItemSubastado = item;
            OfertaActual = item.ObtenerPrecio();
            NombreGanadorActual = "Sin ofertas";
            Activa = true;
        }

        public void Suscribir(IObserver observador)
        {
            _subscriptores.Add(observador);
        }

        public void Desuscribir(IObserver observador)
        {
            _subscriptores.Remove(observador);
        }

        public void NotificarSuscriptores(string mensaje)
        {
            foreach (var suscriptor in _subscriptores)
            {
                suscriptor.Actualizar(mensaje);
            }
        }
    }
}
