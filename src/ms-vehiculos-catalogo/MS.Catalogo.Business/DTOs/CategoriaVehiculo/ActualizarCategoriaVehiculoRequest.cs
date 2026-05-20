// PARTE 5 � MS.Catalogo.Business/DTOs/CategoriaVehiculo/ActualizarCategoriaVehiculoRequest.cs
// CORRECCI�N: Completo con todos los campos del DataModel.

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.CategoriaVehiculo;

public class ActualizarCategoriaVehiculoRequest
{
    [JsonIgnore] public Guid CAT_id { get; set; }
    public string CAT_nombre { get; set; } = null!;
    public string? CAT_descripcion { get; set; }
    public decimal CAT_costoBase { get; set; }
    public int CAT_capacidadPasajeros { get; set; }
    public int CAT_capacidadMaletas { get; set; }
    public string? CAT_tipoTransmision { get; set; }

    // Auditor�a
    [JsonIgnore] public string? CAT_usuarioModificacion { get; set; }
}
