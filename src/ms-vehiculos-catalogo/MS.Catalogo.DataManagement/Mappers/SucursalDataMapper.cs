using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Mappers
{
    public static class SucursalDataMapper
    {
        public static SucursalDataModel ToDataModel(this SucursalEntity entity)
        {
            if (entity == null) return null!;

            return new SucursalDataModel
            {
                SUC_id = entity.SUC_id,
                SUC_nombre = entity.SUC_nombre,
                SUC_ciudad = entity.SUC_ciudad,
                SUC_direccion = entity.SUC_direccion,
                SUC_coordenadas = entity.SUC_coordenadas,
                SUC_usuarioCreacion = entity.SUC_usuarioCreacion,
                SUC_fechaCreacion = entity.SUC_fechaCreacion ?? DateTime.UtcNow,
                SUC_usuarioModificacion = entity.SUC_usuarioModificacion,
                SUC_fechaModificacion = entity.SUC_fechaModificacion
            };
        }

        public static SucursalEntity ToEntity(this SucursalDataModel model)
        {
            if (model == null) return null!;

            return new SucursalEntity
            {
                SUC_id = model.SUC_id,
                SUC_nombre = model.SUC_nombre,
                SUC_ciudad = model.SUC_ciudad,
                SUC_direccion = model.SUC_direccion,
                SUC_coordenadas = model.SUC_coordenadas,
                SUC_usuarioCreacion = model.SUC_usuarioCreacion,
                SUC_fechaCreacion = model.SUC_fechaCreacion,
                SUC_usuarioModificacion = model.SUC_usuarioModificacion,
                SUC_fechaModificacion = model.SUC_fechaModificacion
            };
        }
    }
}