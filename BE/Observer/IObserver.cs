namespace BE
{
    public interface IObserver
    {
        string NombrePostor { get; }
        string Email { get; }
        void Actualizar(string mensaje);
    }
}
