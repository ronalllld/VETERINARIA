using System.Collections.Generic;
using System.Linq;
using VeterinariaApi.Models;

namespace VeterinariaApi.Services
{
    public class MascotaService
    {
        private readonly VeterinariaDbContext _context;

        public MascotaService(VeterinariaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Mascota> GetAllMascotas()
        {
            return _context.Mascotas.ToList();
        }

        public Mascota GetMascotaById(int id)
        {
            return _context.Mascotas.Find(id);
        }

        public Mascota CreateMascota(Mascota mascota)
        {
            _context.Mascotas.Add(mascota);
            _context.SaveChanges();
            return mascota;
        }

        public Mascota UpdateMascota(Mascota mascota)
        {
            _context.Mascotas.Update(mascota);
            _context.SaveChanges();
            return mascota;
        }

        public void DeleteMascota(int id)
        {
            var mascota = _context.Mascotas.Find(id);
            if (mascota != null)
            {
                _context.Mascotas.Remove(mascota);
                _context.SaveChanges();
            }
        }
    }
}
