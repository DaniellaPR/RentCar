// PARTE 5 � MS.Catalogo.Business/DTOs/Tarifa/ActualizarTarifaRequest.cs
// CORRECCI�N: Solo TAR_precioDiario (no TAR_precioDia/Semana/Mes).

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Tarifa;

public class ActualizarTarifaRequest
{
    [JsonIgnore] public Guid TAR_id { get; set; }
    public Guid CAT_id { get; set; }
    public decimal TAR_precioDiario { get; set; }

    // Auditor�a
    [JsonIgnore] public string? TAR_usuarioModificacion { get; set; }
}
