using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public sealed class Acceso
    {
        private static volatile Acceso _instance;
        private static readonly object _lock = new object();
        private readonly string _cadenaConexion;

        private Acceso()
        {
            try
            {
                ConnectionStringSettings entrada = ConfigurationManager.ConnectionStrings["ConexionSQL"];
                if (entrada != null)
                    _cadenaConexion = entrada.ConnectionString;
            }
            catch (Exception)
            {
                _cadenaConexion = null;
            }
        }

        public static Acceso GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Acceso();
                }
            }
            return _instance;
        }

        public bool VerificarConexion()
        {
            if (string.IsNullOrEmpty(_cadenaConexion)) return false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                {
                    conexion.Open();
                    return true;
                }
            }
            catch (Exception) { return false; }
        }

        public DataTable Leer(string consulta, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    conexion.Open();
                    DataTable tabla = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(tabla);
                    return tabla;
                }
            }
            catch (Exception ex) { throw new Exception($"Error al leer: {ex.Message}", ex); }
        }

        public int Escribir(string consulta, SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    conexion.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new Exception($"Error al escribir: {ex.Message}", ex); }
        }
    }
}
