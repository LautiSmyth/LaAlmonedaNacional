namespace BE
{
    public interface IObserver
    {
        int Id { get; }
        string NombrePostor { get; }
        string Email { get; }

        void Actualizar(string mensaje);
    }
}