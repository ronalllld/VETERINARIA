using Microsoft.EntityFrameworkCore;

namespace VeterinariaApi.Models
{
    public class VeterinariaDbContext : DbContext
    {
        public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Historial> Historial { get; set; }
        public DbSet<MascotaServicio> MascotaServicios { get; set; }
    }
}
