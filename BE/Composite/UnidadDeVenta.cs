namespace BE
{
    public abstract class UnidadDeVenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public abstract decimal ObtenerPrecio();

        public abstract string ObtenerDetalles(int nivel = 0);

        public override string ToString() => Nombre;
    }
}