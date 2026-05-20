// PARTE 5 — MS.Catalogo.Business/DTOs/ExtraAdicional/ExtraAdicionalResponse.cs
// CORRECCIÓN: ExtraAdicionalDataModel tiene EXT_costo (no EXT_costoDiario).
//             ExtraAdicionalBusinessMapper.ToResponse() usa EXT_costo y EXT_estado.

namespace MS.Catalogo.Business.DTOs.ExtraAdicional;

public class ExtraAdicionalResponse
{
    public Guid EXT_id { get; set; }
    public string EXT_nombre { get; set; } = null!;
    /// <summary>Campo real en la BD: EXT_costo (no EXT_costoDiario).</summary>
    public decimal EXT_costo { get; set; }
    public string EXT_estado { get; set; } = "ACTIVO";
}
