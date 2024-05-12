namespace DoubleVPartners.Domain.Entity
{
    public class Persona
    {
        public int Identificador { get; set; }
        public string? Nombres { get; set;}
        public string? Apellidos { get; set; }
        public int TipoIdentificacion { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? Email { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
