// PARTE 5 � MS.Catalogo.Business/DTOs/ExtraAdicional/ActualizarExtraAdicionalRequest.cs

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.ExtraAdicional;

public class ActualizarExtraAdicionalRequest
{
    [JsonIgnore] public Guid EXT_id { get; set; }
    public string EXT_nombre { get; set; } = null!;
    public decimal EXT_costo { get; set; }

    // Auditor�a
    [JsonIgnore] public string? EXT_usuarioModificacion { get; set; }
}
