using System;

namespace Servicios
{
    public static class AuditoriaService
    {
        public static void RegistrarLog(string accion)
        {
            Console.WriteLine($"[AUDITORÍA DE SEGURIDAD - {DateTime.Now:dd/MM/yyyy HH:mm:ss.fff}] {accion}");
        }
    }
}
