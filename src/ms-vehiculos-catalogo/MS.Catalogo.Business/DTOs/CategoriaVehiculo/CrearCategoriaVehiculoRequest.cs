// PARTE 5 � MS.Catalogo.Business/DTOs/CategoriaVehiculo/CrearCategoriaVehiculoRequest.cs
// CORRECCI�N: A�adidos CAT_capacidadPasajeros, CAT_capacidadMaletas, CAT_tipoTransmision
//             que CategoriaVehiculoDataModel requiere. Se eliminan Data Annotations innecesarias
//             (la validaci�n vive en CategoriaVehiculoValidator).

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.CategoriaVehiculo;

public class CrearCategoriaVehiculoRequest
{
    public string CAT_nombre { get; set; } = null!;
    public string? CAT_descripcion { get; set; }
    public decimal CAT_costoBase { get; set; }
    public int CAT_capacidadPasajeros { get; set; }
    public int CAT_capacidadMaletas { get; set; }
    public string? CAT_tipoTransmision { get; set; }

    // Auditor�a
    [JsonIgnore] public string? CAT_usuarioCreacion { get; set; }
}
