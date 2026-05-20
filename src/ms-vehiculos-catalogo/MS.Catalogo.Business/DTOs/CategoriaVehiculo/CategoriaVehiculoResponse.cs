// PARTE 5 — MS.Catalogo.Business/DTOs/CategoriaVehiculo/CategoriaVehiculoResponse.cs
// CORRECCIÓN: Añadidos CAT_capacidadPasajeros, CAT_capacidadMaletas, CAT_tipoTransmision, CAT_estado
//             que CategoriaVehiculoDataModel tiene y el mapper debe poder mapear.

namespace MS.Catalogo.Business.DTOs.CategoriaVehiculo;

public class CategoriaVehiculoResponse
{
    public Guid CAT_id { get; set; }
    public string CAT_nombre { get; set; } = null!;
    public string? CAT_descripcion { get; set; }
    public decimal CAT_costoBase { get; set; }
    public int CAT_capacidadPasajeros { get; set; }
    public int CAT_capacidadMaletas { get; set; }
    public string? CAT_tipoTransmision { get; set; }
    public string CAT_estado { get; set; } = "ACTIVO";
}
