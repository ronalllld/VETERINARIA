namespace VeterinariaApi.Models
{
    public class MascotaServicio
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; } = new Mascota();
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; } = new Servicio();
        public DateTime Fecha { get; set; }
    }
}
