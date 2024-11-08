using VeterinariaApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace VeterinariaApi.Services
{
    public class ClienteService
    {
        private readonly VeterinariaDbContext _context;

        public ClienteService(VeterinariaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _context.Clientes.AsNoTracking().ToList();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Clientes.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public void CreateCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void UpdateCliente(Cliente cliente)
        {
            // Obtiene la entidad actual desde la base de datos para evitar el error de rastreo duplicado
            var existingCliente = _context.Clientes.Find(cliente.Id);
            if (existingCliente != null)
            {
                // Actualiza las propiedades necesarias
                existingCliente.Nombre = cliente.Nombre;
                existingCliente.Direccion = cliente.Direccion;
                existingCliente.Telefono = cliente.Telefono;

                // Guarda los cambios
                _context.SaveChanges();
            }
        }

        public void DeleteCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
