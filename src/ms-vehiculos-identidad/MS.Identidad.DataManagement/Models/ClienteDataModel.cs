namespace MS.Identidad.DataManagement.Models
{
    public class ClienteDataModel
    {
        public Guid CLI_id { get; set; }
        public string CLI_nombres { get; set; } = string.Empty;
        public string CLI_apellidos { get; set; } = string.Empty;
        public string CLI_cedula { get; set; } = string.Empty;
        public string? CLI_telefono { get; set; }

        public string? CLI_usuarioCreacion { get; set; }
        public DateTime CLI_fechaCreacion { get; set; }
        public string? CLI_usuarioModificacion { get; set; }
        public DateTime? CLI_fechaModificacion { get; set; }
    }
}
