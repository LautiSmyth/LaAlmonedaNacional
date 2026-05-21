using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PostorDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public int RegistrarPostor(Postor postor)
        {
            try
            {
                string q = @"INSERT INTO Postores (NombrePostor, Email, Telefono)
                             VALUES (@NombrePostor, @Email, @Telefono)";
                SqlParameter[] p = {
                    new SqlParameter("@NombrePostor", postor.NombrePostor),
                    new SqlParameter("@Email",        postor.Email),
                    new SqlParameter("@Telefono",     (object)postor.Telefono ?? DBNull.Value)
                };
                int nuevoId = _acceso.EscribirYObtenerID(q, p);
                postor.Id = nuevoId;
                return nuevoId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al registrar postor '{postor.NombrePostor}': {ex.Message}", ex);
            }
        }

        public void ActualizarPostor(Postor postor)
        {
            try
            {
                string q = @"UPDATE Postores
                             SET NombrePostor=@NombrePostor, Email=@Email, Telefono=@Telefono
                             WHERE Id=@Id";
                SqlParameter[] p = {
                    new SqlParameter("@NombrePostor", postor.NombrePostor),
                    new SqlParameter("@Email",        postor.Email),
                    new SqlParameter("@Telefono",     (object)postor.Telefono ?? DBNull.Value),
                    new SqlParameter("@Id",           postor.Id)
                };
                _acceso.Escribir(q, p);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar postor #{postor.Id}: {ex.Message}", ex);
            }
        }

        public void EliminarPostor(int id)
        {
            try
            {
                _acceso.Escribir("DELETE FROM Postores WHERE Id=@Id",
                    new[] { new SqlParameter("@Id", id) });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar postor #{id}: {ex.Message}", ex);
            }
        }

        public Postor ObtenerPorId(int id)
        {
            try
            {
                string q = "SELECT Id, NombrePostor, Email, Telefono FROM Postores WHERE Id=@Id";
                DataTable tabla = _acceso.Leer(q, new[] { new SqlParameter("@Id", id) });
                return tabla.Rows.Count > 0 ? MapearFila(tabla.Rows[0]) : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener postor #{id}: {ex.Message}", ex);
            }
        }

        public Postor ObtenerPorEmail(string email)
        {
            try
            {
                string q = "SELECT Id, NombrePostor, Email, Telefono FROM Postores WHERE Email=@Email";
                DataTable tabla = _acceso.Leer(q, new[] { new SqlParameter("@Email", email) });
                return tabla.Rows.Count > 0 ? MapearFila(tabla.Rows[0]) : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar postor por email: {ex.Message}", ex);
            }
        }

        public List<Postor> ObtenerTodos()
        {
            try
            {
                DataTable tabla = _acceso.Leer(
                    "SELECT Id, NombrePostor, Email, Telefono FROM Postores ORDER BY NombrePostor");
                var lista = new List<Postor>();
                foreach (DataRow fila in tabla.Rows)
                    lista.Add(MapearFila(fila));
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener postores: {ex.Message}", ex);
            }
        }

        public List<Postor> ObtenerSuscriptores(int subastaId)
        {
            try
            {
                string q = @"SELECT p.Id, p.NombrePostor, p.Email, p.Telefono
                             FROM Postores p
                             JOIN Suscripciones s ON p.Id = s.PostorId
                             WHERE s.SubastaId = @SubastaId
                             ORDER BY p.NombrePostor";
                DataTable tabla = _acceso.Leer(q, new[] { new SqlParameter("@SubastaId", subastaId) });
                var lista = new List<Postor>();
                foreach (DataRow fila in tabla.Rows)
                    lista.Add(MapearFila(fila));
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener suscriptores: {ex.Message}", ex);
            }
        }

        private Postor MapearFila(DataRow fila) =>
            new Postor(
                Convert.ToInt32(fila["Id"]),
                fila["NombrePostor"].ToString(),
                fila["Email"].ToString(),
                fila["Telefono"] == DBNull.Value ? null : fila["Telefono"].ToString());
    }
}
