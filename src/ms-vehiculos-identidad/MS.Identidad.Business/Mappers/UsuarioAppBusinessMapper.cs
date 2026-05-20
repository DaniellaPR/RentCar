// PARTE 5 — MS.Identidad.Business/Mappers/UsuarioAppBusinessMapper.cs

//                    que NO existen en UsuarioAppDataModel.


using MS.Identidad.Business.DTOs.UsuarioApp;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.Business.Mappers;

public static class UsuarioAppBusinessMapper
{
    public static UsuarioAppDataModel ToDataModel(this CrearUsuarioAppRequest request, string passwordHash)
    {
        return new UsuarioAppDataModel
        {
            USU_id = Guid.NewGuid(),
            ROL_id = request.ROL_id,
            USU_email = request.USU_email.ToLowerInvariant(),
            USU_passwordHash = passwordHash,

            USU_usuarioCreacion = request.USU_usuarioCreacion,
            USU_fechaCreacion = DateTime.UtcNow
        };
    }

    public static UsuarioAppDataModel ApplyUpdate(this UsuarioAppDataModel model, ActualizarUsuarioAppRequest request)
    {
        model.ROL_id = request.ROL_id;
        model.USU_email = request.USU_email.ToLowerInvariant();

        model.USU_usuarioModificacion = request.USU_usuarioModificacion;
        model.USU_fechaModificacion = DateTime.UtcNow;
        return model;
    }

    public static UsuarioAppResponse ToResponse(this UsuarioAppDataModel model)
    {
        return new UsuarioAppResponse
        {
            USU_id = model.USU_id,
            ROL_id = model.ROL_id,
            USU_email = model.USU_email,

            // NUNCA se incluye USU_passwordHash
        };
    }
}
