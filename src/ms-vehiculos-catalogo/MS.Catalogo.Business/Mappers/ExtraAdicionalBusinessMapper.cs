using MS.Catalogo.Business.DTOs.ExtraAdicional;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Mappers;

public static class ExtraAdicionalBusinessMapper
{
    public static ExtraAdicionalDataModel ToDataModel(this CrearExtraAdicionalRequest request)
    {
        return new ExtraAdicionalDataModel
        {
            EXT_id = Guid.NewGuid(),
            EXT_nombre = request.EXT_nombre,
            EXT_costo = request.EXT_costo,      // campo real en la BD
            EXT_usuarioCreacion = request.EXT_usuarioCreacion,
            EXT_fechaCreacion = DateTime.UtcNow
        };
    }

    public static ExtraAdicionalResponse ToResponse(this ExtraAdicionalDataModel model)
    {
        return new ExtraAdicionalResponse
        {
            EXT_id = model.EXT_id,
            EXT_nombre = model.EXT_nombre,
            EXT_costo = model.EXT_costo,
        };
    }
}
