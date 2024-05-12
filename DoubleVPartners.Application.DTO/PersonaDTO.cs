namespace DoubleVPartners.Application.DTO
{
    public class PersonaDTO
    {
        private string? _NumeroConIdentificacion;
        private string? _NombresApellidos;

        public int Identificador { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int TipoIdentificacion { get; set; }
        public string? NumeroIdentificacion { get; set; }
        public string? Email { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string? NumeroConIdentificacion
        {
            get
            {
                this._NumeroConIdentificacion = $"{TipoIdentificacion.ToString()}-{NumeroIdentificacion}";
                return this._NumeroConIdentificacion;
            }
            set
            {
                this._NumeroConIdentificacion = value;
            }
        }

        public string? NombresApellidos
        {
            get
            {
                this._NombresApellidos = $"{Nombres} {Apellidos}";
                return this._NombresApellidos;
            }
            set
            {
                this._NombresApellidos = value;
            }
        }

    }
}
