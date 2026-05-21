using System;
using System.Data.SqlClient;

namespace DAL
{
    public class SubastaDAL
    {
        public void PersistirFinDeSubasta(int subastaId, int unidadVentaId, decimal precioFinal, int postorGanadorId)
        {
            string query = @"INSERT INTO HistorialSubastas (SubastaId, UnidadVentaId, PrecioFinal, PostorGanadorId, FechaHora) 
                             VALUES (@SubastaId, @UnidadVentaId, @PrecioFinal, @PostorGanadorId, @FechaHora)";

            SqlParameter[] parametros = {
                new SqlParameter("@SubastaId",       subastaId),
                new SqlParameter("@UnidadVentaId",   unidadVentaId),
                new SqlParameter("@PrecioFinal",     precioFinal),
                new SqlParameter("@PostorGanadorId", postorGanadorId),
                new SqlParameter("@FechaHora",       DateTime.Now) // Asigna la fecha y hora actual automáticamente
            };

            Acceso.GetInstance().Escribir(query, parametros);
        }
    }
}
