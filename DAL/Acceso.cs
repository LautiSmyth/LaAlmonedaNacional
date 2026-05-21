using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public sealed class Acceso
    {
        private static volatile Acceso _instance;
        private static readonly object _syncLock = new object();
        private readonly string _cadenaConexion;

        private Acceso()
        {
            try
            {
                ConnectionStringSettings entrada =
                    ConfigurationManager.ConnectionStrings["ConexionSQL"];
                _cadenaConexion = entrada?.ConnectionString;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "No se pudo leer la cadena de conexión desde App.config.", ex);
            }
        }

        public static Acceso GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                        _instance = new Acceso();
                }
            }
            return _instance;
        }

        public bool VerificarConexion()
        {
            if (string.IsNullOrWhiteSpace(_cadenaConexion)) return false;
            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    cn.Open();
                    return true;
                }
            }
            catch { return false; }
        }

        public DataTable Leer(string consulta, SqlParameter[] parametros = null)
        {
            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                using (var cmd = new SqlCommand(consulta, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    cn.Open();
                    var tabla = new DataTable();
                    using (var adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(tabla);
                    return tabla;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al leer: {ex.Message}", ex);
            }
        }

        public int Escribir(string consulta, SqlParameter[] parametros = null)
        {
            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                using (var cmd = new SqlCommand(consulta, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    cn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al escribir: {ex.Message}", ex);
            }
        }

        public int EscribirYObtenerID(string consulta, SqlParameter[] parametros = null)
        {
            string consultaConId = consulta.TrimEnd(';', ' ')
                                   + "; SELECT SCOPE_IDENTITY();";
            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                using (var cmd = new SqlCommand(consultaConId, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    cn.Open();
                    object resultado = cmd.ExecuteScalar();
                    if (resultado == null || resultado == DBNull.Value)
                        throw new Exception("La BD no devolvió un ID tras el INSERT.");
                    return Convert.ToInt32(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar y obtener ID: {ex.Message}", ex);
            }
        }
    }
}
