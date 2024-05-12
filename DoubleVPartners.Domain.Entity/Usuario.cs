namespace DoubleVPartners.Domain.Entity
{
    public class Usuario
    {
        public int Identificador { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
