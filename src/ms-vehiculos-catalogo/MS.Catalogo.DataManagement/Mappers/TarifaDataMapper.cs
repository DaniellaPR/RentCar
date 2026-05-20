using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Mappers
{
    public static class TarifaDataMapper
    {
        public static TarifaDataModel ToDataModel(this TarifaEntity entity)
        {
            if (entity == null) return null!;

            return new TarifaDataModel
            {
                TAR_id = entity.TAR_id,
                CAT_id = entity.CAT_id,
                TAR_precioDiario = entity.TAR_precioDiario,
                TAR_usuarioCreacion = entity.TAR_usuarioCreacion,
                TAR_fechaCreacion = entity.TAR_fechaCreacion ?? DateTime.UtcNow,
                TAR_usuarioModificacion = entity.TAR_usuarioModificacion,
                TAR_fechaModificacion = entity.TAR_fechaModificacion
            };
        }

        public static TarifaEntity ToEntity(this TarifaDataModel model)
        {
            if (model == null) return null!;

            return new TarifaEntity
            {
                TAR_id = model.TAR_id,
                CAT_id = model.CAT_id,
                TAR_precioDiario = model.TAR_precioDiario,
                TAR_usuarioCreacion = model.TAR_usuarioCreacion,
                TAR_fechaCreacion = model.TAR_fechaCreacion,
                TAR_usuarioModificacion = model.TAR_usuarioModificacion,
                TAR_fechaModificacion = model.TAR_fechaModificacion
            };
        }
    }
}