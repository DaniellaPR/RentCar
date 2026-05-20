namespace MS.Catalogo.DataManagement.Models
{
    public class SeguroDataModel
    {
        public Guid SEG_id { get; set; }
        public string SEG_nombre { get; set; } = string.Empty;
        public string? SEG_cobertura { get; set; }
        public decimal SEG_costoDiario { get; set; }

        public string? SEG_usuarioCreacion { get; set; }
        public DateTime SEG_fechaCreacion { get; set; }
        public string? SEG_usuarioModificacion { get; set; }
        public DateTime? SEG_fechaModificacion { get; set; }
    }
}
