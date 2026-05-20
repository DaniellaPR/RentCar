using MS.Identidad.DataAccess.Entities;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Mappers
{
    public static class RolDataMapper
    {
        public static RolDataModel ToDataModel(this RolEntity entity)
        {
            if (entity == null) return null!;

            return new RolDataModel
            {
                ROL_id = entity.ROL_id,
                ROL_nombre = entity.ROL_nombre,
                ROL_usuarioCreacion = entity.ROL_usuarioCreacion,
                ROL_fechaCreacion = entity.ROL_fechaCreacion ?? DateTime.UtcNow,
                ROL_usuarioModificacion = entity.ROL_usuarioModificacion,
                ROL_fechaModificacion = entity.ROL_fechaModificacion
            };
        }

        public static RolEntity ToEntity(this RolDataModel model)
        {
            if (model == null) return null!;

            return new RolEntity
            {
                ROL_id = model.ROL_id,
                ROL_nombre = model.ROL_nombre,
                ROL_descripcion = null,            // No almacenado en DataModel
                ROL_usuarioCreacion = model.ROL_usuarioCreacion,
                ROL_fechaCreacion = model.ROL_fechaCreacion,
                ROL_usuarioModificacion = model.ROL_usuarioModificacion,
                ROL_fechaModificacion = model.ROL_fechaModificacion
            };
        }
    }
}