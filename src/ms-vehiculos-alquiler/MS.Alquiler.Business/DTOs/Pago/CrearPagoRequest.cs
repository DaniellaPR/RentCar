// PARTE 5 — MS.Alquiler.Business/DTOs/Pago/CrearPagoRequest.cs
// CORRECCIÓN: RES_id en lugar de ResId. PAG_monto/PAG_metodo alineados con DataModel.

namespace MS.Alquiler.Business.DTOs.Pago;

public class CrearPagoRequest
{
    public Guid RES_id { get; set; }
    public decimal PAG_monto { get; set; }
    /// <summary>Ej: 'TARJETA', 'PAYPAL', 'TRANSFERENCIA'.</summary>
    public string PAG_metodo { get; set; } = null!;
}