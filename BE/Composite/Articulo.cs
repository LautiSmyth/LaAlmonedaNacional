namespace BE
{
    public class Articulo : UnidadDeVenta
    {
        private decimal _precioBase;

        public Articulo(int id, string nombre, string descripcion, decimal precioBase)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            _precioBase = precioBase;
        }

        public override decimal ObtenerPrecio()
        {
            return _precioBase;
        }

        public override string ObtenerDetalles(int nivel = 0)
        {
            string sangria = new string(' ', nivel * 2);
            return $"{sangria}- [Artículo] {Nombre}: {Descripcion} (${_precioBase})\n";
        }
    }
}
