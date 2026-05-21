using System;

namespace BE
{
    public class Postor : IObserver
    {
        public int Id { get; set; }
        public string NombrePostor { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }

        public Action<string> OnNotificacion { get; set; }

        public Postor(int id, string nombrePostor, string email, string telefono = null)
        {
            Id = id;
            NombrePostor = nombrePostor ?? throw new ArgumentNullException(nameof(nombrePostor));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Telefono = telefono;
        }
        public Postor(string nombrePostor, string email, string telefono = null) : this(0, nombrePostor, email, telefono) { }

        public void Actualizar(string mensaje)
        {
            if (OnNotificacion != null)
                OnNotificacion.Invoke(mensaje);
            else
                Console.WriteLine($"[{NombrePostor}] {mensaje}");
        }

        public override string ToString() => $"{NombrePostor} ({Email})";
    }
}
