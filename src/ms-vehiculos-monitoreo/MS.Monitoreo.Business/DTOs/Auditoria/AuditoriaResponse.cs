// PARTE 5 — MS.Monitoreo.Business/DTOs/Auditoria/AuditoriaResponse.cs
// CORRECCIÓN: AuditoriaDataModel usa AUD_id, AUD_nombreTabla, AUD_operacion, AUD_usuario,
//             AUD_fecha, AUD_detalleJsonb. El DTO anterior usaba AudId, AudNombreTabla etc.

namespace MS.Monitoreo.Business.DTOs.Auditoria;

public class AuditoriaResponse
{
    public Guid AUD_id { get; set; }
    public string AUD_nombreTabla { get; set; } = null!;
    public string AUD_operacion { get; set; } = null!;
    public string? AUD_usuario { get; set; }
    public DateTime AUD_fecha { get; set; }
    public string? AUD_detalleJsonb { get; set; }
}