using BE;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PostorDAL
    {
        public void RegistrarPostor(Postor postor)
        {
            string query = "INSERT INTO Postores (Id, NombrePostor, Email) VALUES (@Id, @NombrePostor, @Email)";

            SqlParameter[] parametros = {
                new SqlParameter("@Id",           postor.Id),
                new SqlParameter("@NombrePostor", postor.NombrePostor),
                new SqlParameter("@Email",        postor.Email)
            };

            Acceso.GetInstance().Escribir(query, parametros);
        }

        public Postor ObtenerPorId(int id)
        {
            string query = "SELECT Id, NombrePostor, Email FROM Postores WHERE Id = @Id";
            SqlParameter[] parametros = {
                new SqlParameter("@Id", id)
            };

            DataTable tabla = Acceso.GetInstance().Leer(query, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                return new Postor(
                    Convert.ToInt32(fila["Id"]),
                    fila["NombrePostor"].ToString(),
                    fila["Email"].ToString()
                );
            }
            return null;
        }
    }
}
