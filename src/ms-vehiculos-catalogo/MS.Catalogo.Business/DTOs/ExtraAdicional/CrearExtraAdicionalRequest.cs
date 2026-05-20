// PARTE 5 � MS.Catalogo.Business/DTOs/ExtraAdicional/CrearExtraAdicionalRequest.cs
// CORRECCI�N: EXT_costoDiario ? EXT_costo (nombre real en DataModel y mapper).

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.ExtraAdicional;

public class CrearExtraAdicionalRequest
{
    public string EXT_nombre { get; set; } = null!;
    public decimal EXT_costo { get; set; }

    // Auditor�a
    [JsonIgnore] public string? EXT_usuarioCreacion { get; set; }
}
