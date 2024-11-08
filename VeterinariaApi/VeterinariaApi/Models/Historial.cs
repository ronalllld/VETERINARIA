namespace VeterinariaApi.Models
{
    public class Historial
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; } = new Mascota();
    }
}
