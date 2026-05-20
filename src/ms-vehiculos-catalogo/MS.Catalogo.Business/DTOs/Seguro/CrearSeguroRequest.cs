// PARTE 5 � MS.Catalogo.Business/DTOs/Seguro/CrearSeguroRequest.cs
// CORRECCI�N: SEG_descripcion ? SEG_cobertura (nombre real en DataModel y mapper).

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Seguro;

public class CrearSeguroRequest
{
    public string SEG_nombre { get; set; } = null!;
    public string? SEG_cobertura { get; set; }
    public decimal SEG_costoDiario { get; set; }

    // Auditor�a
    [JsonIgnore] public string? SEG_usuarioCreacion { get; set; }
}
