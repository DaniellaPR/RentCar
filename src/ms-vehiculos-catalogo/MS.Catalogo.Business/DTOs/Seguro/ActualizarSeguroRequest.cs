// PARTE 5 � MS.Catalogo.Business/DTOs/Seguro/ActualizarSeguroRequest.cs

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Seguro;

public class ActualizarSeguroRequest
{
    [JsonIgnore] public Guid SEG_id { get; set; }
    public string SEG_nombre { get; set; } = null!;
    public string? SEG_cobertura { get; set; }
    public decimal SEG_costoDiario { get; set; }

    // Auditor�a
    [JsonIgnore] public string? SEG_usuarioModificacion { get; set; }
}
