using System.Collections.Generic;
using System.Linq;
using VeterinariaApi.Models;

namespace VeterinariaApi.Services
{
    public class CitaService
    {
        private readonly VeterinariaDbContext _context;

        public CitaService(VeterinariaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cita> GetAllCitas()
        {
            return _context.Citas.ToList();
        }

        public Cita GetCitaById(int id)
        {
            return _context.Citas.Find(id);
        }

        public Cita CreateCita(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
            return cita;
        }

        public Cita UpdateCita(Cita cita)
        {
            _context.Citas.Update(cita);
            _context.SaveChanges();
            return cita;
        }

        public void DeleteCita(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                _context.SaveChanges();
            }
        }
    }
}
