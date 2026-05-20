namespace MS.Identidad.DataManagement.Models
{
    public class UsuarioAppDataModel
    {
        public Guid USU_id { get; set; }
        public Guid ROL_id { get; set; }
        public string USU_email { get; set; } = string.Empty;
        public string USU_passwordHash { get; set; } = string.Empty;
        public string USU_estado { get; set; } = "ACTIVO";

        public string? USU_usuarioCreacion { get; set; }
        public DateTime USU_fechaCreacion { get; set; }
        public string? USU_usuarioModificacion { get; set; }
        public DateTime? USU_fechaModificacion { get; set; }
    }
}
