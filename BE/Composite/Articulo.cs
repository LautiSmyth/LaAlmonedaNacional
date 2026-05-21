using System;

namespace BE
{
    public class Articulo : UnidadDeVenta
    {
        private decimal _precioBase;

        public decimal PrecioBase
        {
            get => _precioBase;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "El precio base no puede ser negativo.");
                _precioBase = value;
            }
        }

        public Articulo(int id, string nombre, string descripcion, decimal precioBase)
        {
            Id = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Descripcion = descripcion ?? string.Empty;
            PrecioBase = precioBase;
        }

        public Articulo(string nombre, string descripcion, decimal precioBase) : this(0, nombre, descripcion, precioBase)
        {
        }

        public override decimal ObtenerPrecio() => _precioBase;

        public override string ObtenerDetalles(int nivel = 0)
        {
            string sangria = new string(' ', nivel * 4);
            return $"{sangria}  📦 [Artículo] {Nombre}: {Descripcion} (${_precioBase:N2})\n";
        }
    }
}