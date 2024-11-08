using System.Collections.Generic;
using System.Linq;
using VeterinariaApi.Models;

namespace VeterinariaApi.Services
{
    public class ServicioService
    {
        private readonly VeterinariaDbContext _context;

        public ServicioService(VeterinariaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Servicio> GetAllServicios()
        {
            return _context.Servicios.ToList();
        }

        public Servicio GetServicioById(int id)
        {
            return _context.Servicios.Find(id);
        }

        public Servicio CreateServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            _context.SaveChanges();
            return servicio;
        }

        public Servicio UpdateServicio(Servicio servicio)
        {
            _context.Servicios.Update(servicio);
            _context.SaveChanges();
            return servicio;
        }

        public void DeleteServicio(int id)
        {
            var servicio = _context.Servicios.Find(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                _context.SaveChanges();
            }
        }
    }
}
