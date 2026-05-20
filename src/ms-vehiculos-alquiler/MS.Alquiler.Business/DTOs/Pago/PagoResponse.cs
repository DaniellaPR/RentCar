// PARTE 5 — MS.Alquiler.Business/DTOs/Pago/PagoResponse.cs
// CORRECCIÓN: PagoDataModel usa PAG_id, RES_id, PAG_fechaPago, PAG_monto, PAG_metodo, PAG_estado.
//             El mapper PagoBusinessMapper.ToResponse() usa esos campos.

namespace MS.Alquiler.Business.DTOs.Pago;

public class PagoResponse
{
    public Guid PAG_id { get; set; }
    public Guid RES_id { get; set; }
    public DateTime PAG_fechaPago { get; set; }
    public decimal PAG_monto { get; set; }
    public string PAG_metodo { get; set; } = null!;
    public string PAG_estado { get; set; } = null!;
}