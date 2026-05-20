using MS.Alquiler.DataAccess.Entities;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Mappers
{
    public static class PagoDataMapper
    {
        public static PagoDataModel ToDataModel(this PagoEntity entity)
        {
            if (entity == null) return null!;

            return new PagoDataModel
            {
                PAG_id = entity.PAG_id,
                RES_id = entity.RES_id,
                PAG_monto = entity.PAG_monto,
                PAG_metodo = entity.PAG_metodo,
                PAG_estado = entity.PAG_estado,
                PAG_fechaPago = entity.PAG_fechaPago ?? DateTime.UtcNow
            };
        }

        public static PagoEntity ToEntity(this PagoDataModel model)
        {
            if (model == null) return null!;

            return new PagoEntity
            {
                PAG_id = model.PAG_id,
                RES_id = model.RES_id,
                PAG_monto = model.PAG_monto,
                PAG_metodo = model.PAG_metodo,
                PAG_estado = model.PAG_estado,
                PAG_fechaPago = model.PAG_fechaPago
            };
        }
    }
}