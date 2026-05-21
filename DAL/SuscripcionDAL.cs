using System;
using System.Data.SqlClient;

namespace DAL
{
    public class SuscripcionDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public void Suscribir(int subastaId, int postorId)
        {
            try
            {
                string q = @"IF NOT EXISTS (SELECT 1 FROM Suscripciones
                                            WHERE SubastaId=@S AND PostorId=@P)
                             INSERT INTO Suscripciones (SubastaId, PostorId)
                             VALUES (@S, @P)";
                _acceso.Escribir(q, new[] {
                    new SqlParameter("@S", subastaId),
                    new SqlParameter("@P", postorId)
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al suscribir: {ex.Message}", ex);
            }
        }

        public void Desuscribir(int subastaId, int postorId)
        {
            try
            {
                string q = "DELETE FROM Suscripciones WHERE SubastaId=@S AND PostorId=@P";
                _acceso.Escribir(q, new[] {
                    new SqlParameter("@S", subastaId),
                    new SqlParameter("@P", postorId)
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al desuscribir: {ex.Message}", ex);
            }
        }

        public bool EstaSuscripto(int subastaId, int postorId)
        {
            try
            {
                string q = @"SELECT COUNT(1) FROM Suscripciones
                             WHERE SubastaId=@S AND PostorId=@P";
                var tabla = _acceso.Leer(q, new[] {
                    new SqlParameter("@S", subastaId),
                    new SqlParameter("@P", postorId)
                });
                return Convert.ToInt32(tabla.Rows[0][0]) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar suscripción: {ex.Message}", ex);
            }
        }
    }
}