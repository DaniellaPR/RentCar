using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Mappers
{
    public static class SeguroDataMapper
    {
        public static SeguroDataModel ToDataModel(this SeguroEntity entity)
        {
            if (entity == null) return null;

            return new SeguroDataModel
            {
                SEG_id = entity.SEG_id,
                SEG_nombre = entity.SEG_nombre,
                SEG_costoDiario = entity.SEG_costoDiario,
                SEG_cobertura = entity.SEG_cobertura
            };
        }

        public static SeguroEntity ToEntity(this SeguroDataModel model)
        {
            if (model == null) return null;

            return new SeguroEntity
            {
                SEG_id = model.SEG_id,
                SEG_nombre = model.SEG_nombre,
                SEG_costoDiario = model.SEG_costoDiario,
                SEG_cobertura = model.SEG_cobertura
            };
        }
    }
}