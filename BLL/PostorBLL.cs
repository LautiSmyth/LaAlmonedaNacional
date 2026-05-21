using BE;
using DAL;
using Servicios;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BLL
{
    public class PostorBLL
    {
        private readonly PostorDAL _dal = new PostorDAL();

        public Postor RegistrarPostor(string nombre, string email, string telefono)
        {
            ValidarNombre(nombre);
            ValidarEmail(email);
            if (_dal.ObtenerPorEmail(email) != null)
                throw new InvalidOperationException($"Ya existe un postor con el email '{email}'.");
            var postor = new Postor(nombre, email, telefono);
            _dal.RegistrarPostor(postor);
            AuditoriaServicio.RegistrarLog($"Postor registrado: '{nombre}' <{email}> Id={postor.Id}");
            return postor;
        }

        public void ActualizarPostor(Postor postor)
        {
            if (postor == null) throw new ArgumentNullException(nameof(postor));
            ValidarNombre(postor.NombrePostor);
            ValidarEmail(postor.Email);
            Postor existente = _dal.ObtenerPorEmail(postor.Email);
            if (existente != null && existente.Id != postor.Id)
                throw new InvalidOperationException($"El email '{postor.Email}' ya está en uso por otro postor.");
            _dal.ActualizarPostor(postor);
            AuditoriaServicio.RegistrarLog($"Postor actualizado: Id={postor.Id}");
        }

        public void EliminarPostor(int id)
        {
            if (id <= 0) throw new ArgumentException("Id inválido.");
            _dal.EliminarPostor(id);
            AuditoriaServicio.RegistrarLog($"Postor eliminado: Id={id}");
        }

        public Postor ObtenerPorId(int id) => _dal.ObtenerPorId(id);

        public List<Postor> ObtenerTodos() => _dal.ObtenerTodos();

        public List<Postor> ObtenerSuscriptores(int subastaId) => _dal.ObtenerSuscriptores(subastaId);

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del postor no puede estar vacío.");
        }

        private void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El email no puede estar vacío.");
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException($"El email '{email}' no tiene un formato válido.");
        }
    }
}
