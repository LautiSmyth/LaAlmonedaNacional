using System;

namespace BE
{
    public class Postor : IObserver
    {
        public int Id { get; set; }
        public string NombrePostor { get; private set; }
        public string Email { get; private set; }

        public Postor(int id, string nombrePostor, string email)
        {
            Id = id;
            NombrePostor = nombrePostor;
            Email = email;
        }

        public void Actualizar(string mensaje)
        {

            Console.WriteLine($"[NOTIFICACIÓN ENVIADA A {NombrePostor}, Email: {Email}]: {mensaje}");
        }
    }
}
