// PARTE 5 — MS.Monitoreo.Business/DTOs/Auditoria/CrearAuditoriaRequest.cs
// CORRECCIÓN: AUD_ prefijos para consistencia con DataModel.

namespace MS.Monitoreo.Business.DTOs.Auditoria;

public class CrearAuditoriaRequest
{
    public string AUD_nombreTabla { get; set; } = null!;
    public string AUD_operacion { get; set; } = null!;
    public string? AUD_usuario { get; set; }
    public string? AUD_detalleJsonb { get; set; }
}