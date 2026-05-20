namespace MS.Monitoreo.DataManagement.Models
{
    public class AuditoriaDataModel
    {
        public Guid AUD_id { get; set; }
        public string AUD_nombreTabla { get; set; } = string.Empty;
        public string AUD_operacion { get; set; } = string.Empty;
        public string? AUD_usuario { get; set; }
        public DateTime AUD_fecha { get; set; }
        public string? AUD_detalleJsonb { get; set; }
    }
}
