// PARTE 5 — MS.Catalogo.Business/DTOs/Seguro/SeguroResponse.cs
// CORRECCIÓN: SeguroDataModel tiene SEG_cobertura (no SEG_descripcion).
//             SeguroBusinessMapper.ToResponse() usa SEG_cobertura y SEG_costoDiario.

namespace MS.Catalogo.Business.DTOs.Seguro;

public class SeguroResponse
{
    public Guid SEG_id { get; set; }
    public string SEG_nombre { get; set; } = null!;
    /// <summary>Texto de cobertura — campo real en la BD (no SEG_descripcion).</summary>
    public string? SEG_cobertura { get; set; }
    public decimal SEG_costoDiario { get; set; }
    public string SEG_estado { get; set; } = "ACTIVO";
}
