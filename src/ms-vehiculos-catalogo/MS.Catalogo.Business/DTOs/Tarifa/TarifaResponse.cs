// PARTE 5 — MS.Catalogo.Business/DTOs/Tarifa/TarifaResponse.cs
// CORRECCIÓN CRÍTICA: TarifaDataModel tiene UN SOLO campo precio: TAR_precioDiario.
//                    Los campos TAR_precioDia/Semana/Mes del DTO original NO existen en la BD.
//                    TarifaBusinessMapper.ToResponse() ya usa TAR_precioDiario y TAR_estado.

namespace MS.Catalogo.Business.DTOs.Tarifa;

public class TarifaResponse
{
    public Guid TAR_id { get; set; }
    public Guid CAT_id { get; set; }
    /// <summary>Precio único diario (la BD solo almacena un precio base por tarifa).</summary>
    public decimal TAR_precioDiario { get; set; }
    public string TAR_estado { get; set; } = "ACTIVO";
}
