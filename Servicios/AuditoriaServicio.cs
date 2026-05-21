using System;
using System.IO;

namespace Servicios
{
    public static class AuditoriaServicio
    {
        private static readonly string _archivoLog =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "auditoria.log");

        public static void RegistrarLog(string accion)
        {
            string entrada = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss.fff}] {accion}";
            Console.WriteLine(entrada);
            try
            {
                File.AppendAllText(_archivoLog, entrada + Environment.NewLine);
            }
            catch { }
        }

        public static void RegistrarError(string contexto, Exception ex)
        {
            RegistrarLog($"[ERROR] {contexto}: {ex.Message}\n  Stack: {ex.StackTrace}");
        }
    }
}