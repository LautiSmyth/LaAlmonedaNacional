using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BE
{
    public class Lote : UnidadDeVenta
    {
        private readonly List<UnidadDeVenta> _componentes = new List<UnidadDeVenta>();

        public Lote(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Descripcion = descripcion ?? string.Empty;
        }

        public Lote(string nombre, string descripcion) : this(0, nombre, descripcion)
        {
        }

        public void Agregar(UnidadDeVenta componente)
        {
            if (componente == null)
                throw new ArgumentNullException(nameof(componente));
            if (componente.Id == Id && Id != 0)
                throw new InvalidOperationException("Un lote no puede contenerse a sí mismo.");
            if (_componentes.Exists(c => c.Id == componente.Id && c.Id != 0))
                throw new InvalidOperationException($"El componente '{componente.Nombre}' ya existe en el lote.");
            _componentes.Add(componente);
        }

        public void Remover(UnidadDeVenta componente)
        {
            if (componente == null)
                throw new ArgumentNullException(nameof(componente));
            _componentes.Remove(componente);
        }

        public IReadOnlyList<UnidadDeVenta> ObtenerComponentes()
            => new ReadOnlyCollection<UnidadDeVenta>(_componentes);

        public override decimal ObtenerPrecio()
        {
            decimal total = 0;
            foreach (var componente in _componentes)
                total += componente.ObtenerPrecio();
            return total;
        }

        public override string ObtenerDetalles(int nivel = 0)
        {
            string sangria = new string(' ', nivel * 4);
            string resultado = $"{sangria}🗂  [Lote] {Nombre}: {Descripcion} (Precio acumulado: ${ObtenerPrecio():N2})\n";
            foreach (var componente in _componentes)
                resultado += componente.ObtenerDetalles(nivel + 1);
            return resultado;
        }
    }
}