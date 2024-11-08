namespace VeterinariaApi.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; } = new Mascota();
    }
}
