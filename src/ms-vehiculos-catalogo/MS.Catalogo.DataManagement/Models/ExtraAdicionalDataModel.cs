namespace MS.Catalogo.DataManagement.Models
{
    public class ExtraAdicionalDataModel
    {
        public Guid EXT_id { get; set; }
        public string EXT_nombre { get; set; } = string.Empty;
        public decimal EXT_costo { get; set; }

        public string? EXT_usuarioCreacion { get; set; }
        public DateTime EXT_fechaCreacion { get; set; }
        public string? EXT_usuarioModificacion { get; set; }
        public DateTime? EXT_fechaModificacion { get; set; }
    }
}
