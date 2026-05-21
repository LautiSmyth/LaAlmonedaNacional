using System.Collections.Generic;

namespace BE
{
    public class Lote : UnidadDeVenta
    {
        private readonly List<UnidadDeVenta> _componentes = new List<UnidadDeVenta>();

        public Lote(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public void Agregar(UnidadDeVenta componente)
        {
            _componentes.Add(componente);
        }

        public void Remover(UnidadDeVenta componente)
        {
            _componentes.Remove(componente);
        }
        public List<UnidadDeVenta> ObtenerComponentes()
        {
            return _componentes;
        }

        public override decimal ObtenerPrecio()
        {
            decimal total = 0;
            foreach (var componente in _componentes)
            {
                total += componente.ObtenerPrecio();
            }
            return total;
        }

        public override string ObtenerDetalles(int nivel = 0)
        {
            string sangria = new string(' ', nivel * 2);
            string resultado = $"{sangria}+ [Lote] {Nombre}: {Descripcion} (Precio acumulado: ${ObtenerPrecio()})\n";
            foreach (var componente in _componentes)
            {
                resultado += componente.ObtenerDetalles(nivel + 1);
            }
            return resultado;
        }
    }
}
