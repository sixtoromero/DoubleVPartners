namespace DoubleVPartners.Application.DTO
{
    public class UsuarioDTO
    {
        public int Identificador { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Token { get; set; }
    }
}
