using MS.Identidad.DataAccess.Entities;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Mappers
{
    /// <summary>
    /// NOTA: La UsuarioAppEntity tiene:
    ///   USU_correo (string), USU_estado (bool), USU_nombre (string)
    /// El UsuarioAppDataModel (Parte 1) usa:
    ///   USU_email (string), USU_estado (string "ACTIVO"/"INACTIVO")
    /// Este mapper hace la conversión entre ambas convenciones.
    /// </summary>
    public static class UsuarioAppDataMapper
    {
        public static UsuarioAppDataModel ToDataModel(this UsuarioAppEntity entity)
        {
            if (entity == null) return null!;

            return new UsuarioAppDataModel
            {
                USU_id = entity.USU_id,
                ROL_id = entity.ROL_id,
                USU_email = entity.USU_email,
                USU_passwordHash = entity.USU_passwordHash,
                USU_usuarioCreacion = entity.USU_usuarioCreacion,
                USU_fechaCreacion = entity.USU_fechaCreacion ?? DateTime.UtcNow,
                USU_usuarioModificacion = entity.USU_usuarioModificacion,
                USU_fechaModificacion = entity.USU_fechaModificacion
            };
        }

        public static UsuarioAppEntity ToEntity(this UsuarioAppDataModel model)
        {
            if (model == null) return null!;

            return new UsuarioAppEntity
            {
                USU_id = model.USU_id,
                ROL_id = model.ROL_id,
                USU_email = model.USU_email,
                USU_passwordHash = model.USU_passwordHash,
                USU_usuarioCreacion = model.USU_usuarioCreacion,
                USU_fechaCreacion = model.USU_fechaCreacion,
                USU_usuarioModificacion = model.USU_usuarioModificacion,
                USU_fechaModificacion = model.USU_fechaModificacion
            };
        }
    }
}