// PARTE 5 � MS.Catalogo.Business/DTOs/Tarifa/CrearTarifaRequest.cs
// CORRECCI�N: TarifaDataModel tiene solo TAR_precioDiario.
//             TarifaBusinessMapper.ToDataModel() usa TAR_precioDiario.
//             Se elimina TAR_precioDia/Semana/Mes/fechaVigencia que no existen en la BD.

using System.Text.Json.Serialization;

namespace MS.Catalogo.Business.DTOs.Tarifa;

public class CrearTarifaRequest
{
    public Guid CAT_id { get; set; }
    public decimal TAR_precioDiario { get; set; }

    // Auditor�a
    [JsonIgnore] public string? TAR_usuarioCreacion { get; set; }
}
