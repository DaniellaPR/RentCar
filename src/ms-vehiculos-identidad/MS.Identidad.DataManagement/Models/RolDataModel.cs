namespace MS.Identidad.DataManagement.Models
{
    public class RolDataModel
    {
        public Guid ROL_id { get; set; }
        public string ROL_nombre { get; set; } = string.Empty;

        public string? ROL_usuarioCreacion { get; set; }
        public DateTime ROL_fechaCreacion { get; set; }
        public string? ROL_usuarioModificacion { get; set; }
        public DateTime? ROL_fechaModificacion { get; set; }
    }
}
