// PARTE 5 — MS.Alquiler.Business/DTOs/Pago/ActualizarPagoRequest.cs

using System.Text.Json.Serialization;

namespace MS.Alquiler.Business.DTOs.Pago;

public class ActualizarPagoRequest
{
    [JsonIgnore] public Guid PAG_id { get; set; }
    public decimal PAG_monto { get; set; }
    public string PAG_metodo { get; set; } = null!;
    public string PAG_estado { get; set; } = null!;
}