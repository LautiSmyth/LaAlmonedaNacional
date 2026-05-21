using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SubastaDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public int CrearSubasta(int unidadVentaId, decimal precioInicial)
        {
            try
            {
                string q = @"INSERT INTO Subastas
                               (UnidadVentaId, PrecioInicial, PrecioActual, Activa, FechaInicio)
                             VALUES
                               (@UnidadVentaId, @PrecioInicial, @PrecioInicial, 1, GETDATE())";
                SqlParameter[] p = {
                    new SqlParameter("@UnidadVentaId", unidadVentaId),
                    new SqlParameter("@PrecioInicial", precioInicial)
                };
                return _acceso.EscribirYObtenerID(q, p);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear subasta: {ex.Message}", ex);
            }
        }

        public void ActualizarOferta(int subastaId, decimal nuevaOferta, int postorGanadorId)
        {
            try
            {
                string q = @"UPDATE Subastas
                             SET PrecioActual=@Precio, PostorGanadorId=@PostorId
                             WHERE Id=@Id AND Activa=1";
                SqlParameter[] p = {
                    new SqlParameter("@Precio",   nuevaOferta),
                    new SqlParameter("@PostorId", postorGanadorId),
                    new SqlParameter("@Id",       subastaId)
                };
                int filas = _acceso.Escribir(q, p);
                if (filas == 0)
                    throw new InvalidOperationException("No se pudo actualizar la oferta (subasta cerrada o inexistente).");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar oferta: {ex.Message}", ex);
            }
        }

        public void CerrarSubasta(int subastaId, DateTime fechaCierre)
        {
            try
            {
                string q = @"UPDATE Subastas
                             SET Activa=0, FechaCierre=@FechaCierre
                             WHERE Id=@Id";
                _acceso.Escribir(q, new[] {
                    new SqlParameter("@FechaCierre", fechaCierre),
                    new SqlParameter("@Id",          subastaId)
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cerrar subasta #{subastaId}: {ex.Message}", ex);
            }
        }

        public void PersistirFinDeSubasta(int subastaId, int unidadVentaId,
            string nombreItem, decimal precioFinal,
            int postorGanadorId, string nombreGanador, string emailGanador)
        {
            try
            {
                string q = @"INSERT INTO HistorialSubastas
                               (SubastaId, UnidadVentaId, NombreItem, PrecioFinal,
                                PostorGanadorId, NombreGanador, EmailGanador, FechaHora)
                             VALUES
                               (@SubastaId, @UnidadVentaId, @NombreItem, @PrecioFinal,
                                @PostorGanadorId, @NombreGanador, @EmailGanador, GETDATE())";
                SqlParameter[] p = {
                    new SqlParameter("@SubastaId",       subastaId),
                    new SqlParameter("@UnidadVentaId",   unidadVentaId),
                    new SqlParameter("@NombreItem",      nombreItem),
                    new SqlParameter("@PrecioFinal",     precioFinal),
                    new SqlParameter("@PostorGanadorId", postorGanadorId),
                    new SqlParameter("@NombreGanador",   nombreGanador),
                    new SqlParameter("@EmailGanador",    emailGanador)
                };
                _acceso.Escribir(q, p);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al persistir fin de subasta: {ex.Message}", ex);
            }
        }

        public DataRow ObtenerSubastaPorId(int id)
        {
            try
            {
                string q = @"SELECT s.Id, s.UnidadVentaId, u.Nombre AS NombreItem,
                                    s.PrecioInicial, s.PrecioActual, s.Activa,
                                    s.PostorGanadorId, p.NombrePostor,
                                    s.FechaInicio, s.FechaCierre
                             FROM Subastas s
                             JOIN UnidadesDeVenta u ON s.UnidadVentaId = u.Id
                             LEFT JOIN Postores p   ON s.PostorGanadorId = p.Id
                             WHERE s.Id=@Id";
                DataTable t = _acceso.Leer(q, new[] { new SqlParameter("@Id", id) });
                return t.Rows.Count > 0 ? t.Rows[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener subasta #{id}: {ex.Message}", ex);
            }
        }

        public DataTable ObtenerActivas()
        {
            try
            {
                string q = @"SELECT s.Id, s.UnidadVentaId, u.Nombre AS NombreItem,
                                    s.PrecioInicial, s.PrecioActual,
                                    s.PostorGanadorId, p.NombrePostor AS NombreGanador,
                                    s.FechaInicio
                             FROM Subastas s
                             JOIN UnidadesDeVenta u ON s.UnidadVentaId = u.Id
                             LEFT JOIN Postores p   ON s.PostorGanadorId = p.Id
                             WHERE s.Activa=1
                             ORDER BY s.FechaInicio DESC";
                return _acceso.Leer(q);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener subastas activas: {ex.Message}", ex);
            }
        }

        public DataTable ObtenerHistorial()
        {
            try
            {
                string q = @"SELECT Id, NombreItem, PrecioFinal,
                                    NombreGanador, EmailGanador, FechaHora
                             FROM HistorialSubastas
                             ORDER BY FechaHora DESC";
                return _acceso.Leer(q);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener historial: {ex.Message}", ex);
            }
        }
    }
}