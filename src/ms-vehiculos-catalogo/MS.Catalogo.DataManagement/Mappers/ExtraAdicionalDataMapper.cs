using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Mappers
{
    public static class ExtraAdicionalDataMapper
    {
        public static ExtraAdicionalDataModel ToDataModel(this ExtraAdicionalEntity entity)
        {
            if (entity == null) return null!;

            return new ExtraAdicionalDataModel
            {
                EXT_id = entity.EXT_id,
                EXT_nombre = entity.EXT_nombre,
                EXT_costo = entity.EXT_costo,
                EXT_usuarioCreacion = entity.EXT_usuarioCreacion,
                EXT_fechaCreacion = entity.EXT_fechaCreacion ?? DateTime.UtcNow,
                EXT_usuarioModificacion = entity.EXT_usuarioModificacion,
                EXT_fechaModificacion = entity.EXT_fechaModificacion
            };
        }

        public static ExtraAdicionalEntity ToEntity(this ExtraAdicionalDataModel model)
        {
            if (model == null) return null!;

            return new ExtraAdicionalEntity
            {
                EXT_id = model.EXT_id,
                EXT_nombre = model.EXT_nombre,
                EXT_costo = model.EXT_costo,
                EXT_usuarioCreacion = model.EXT_usuarioCreacion,
                EXT_fechaCreacion = model.EXT_fechaCreacion,
                EXT_usuarioModificacion = model.EXT_usuarioModificacion,
                EXT_fechaModificacion = model.EXT_fechaModificacion
            };
        }
    }
}