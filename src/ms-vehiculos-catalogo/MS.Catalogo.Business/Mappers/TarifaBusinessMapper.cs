using MS.Catalogo.Business.DTOs.Tarifa;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Mappers;

public static class TarifaBusinessMapper
{
    public static TarifaDataModel ToDataModel(this CrearTarifaRequest request)
    {
        return new TarifaDataModel
        {
            TAR_id = Guid.NewGuid(),
            CAT_id = request.CAT_id,
            TAR_precioDiario = request.TAR_precioDiario,   // único campo precio en la BD
            TAR_usuarioCreacion = request.TAR_usuarioCreacion,
            TAR_fechaCreacion = DateTime.UtcNow
        };
    }

    public static TarifaResponse ToResponse(this TarifaDataModel model)
    {
        return new TarifaResponse
        {
            TAR_id = model.TAR_id,
            CAT_id = model.CAT_id,
            TAR_precioDiario = model.TAR_precioDiario,
        };
    }
}
