namespace MS.Catalogo.DataManagement.Models
{
    public class SucursalDataModel
    {
        public Guid SUC_id { get; set; }
        public string SUC_nombre { get; set; } = string.Empty;
        public string SUC_ciudad { get; set; } = string.Empty;
        public string SUC_direccion { get; set; } = string.Empty;
        public string? SUC_coordenadas { get; set; }

        public string? SUC_usuarioCreacion { get; set; }
        public DateTime SUC_fechaCreacion { get; set; }
        public string? SUC_usuarioModificacion { get; set; }
        public DateTime? SUC_fechaModificacion { get; set; }
    }
}
