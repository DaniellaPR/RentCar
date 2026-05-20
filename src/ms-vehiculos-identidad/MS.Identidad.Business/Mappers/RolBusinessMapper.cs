using MS.Identidad.Business.DTOs.Rol;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.Business.Mappers;

public static class RolBusinessMapper
{
    public static RolDataModel ToDataModel(this CrearRolRequest request)
    {
        return new RolDataModel
        {
            ROL_id = Guid.NewGuid(),
            ROL_nombre = request.ROL_nombre,

        };
    }

    public static RolResponse ToResponse(this RolDataModel model)
    {
        return new RolResponse
        {
            ROL_id = model.ROL_id,
            ROL_nombre = model.ROL_nombre,

        };
    }
}
