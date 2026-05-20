using MS.Catalogo.Business.DTOs.Mantenimiento;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Mappers;

public static class MantenimientoBusinessMapper
{
    public static MantenimientoDataModel ToDataModel(this CrearMantenimientoRequest request)
    {
        return new MantenimientoDataModel
        {
            MAN_id = Guid.NewGuid(),
            VEH_id = request.VEH_id,
            MAN_fecha = request.MAN_fecha,          // único campo fecha en la BD
            MAN_descripcion = request.MAN_descripcion,
            MAN_costo = request.MAN_costo,
            MAN_usuarioCreacion = request.MAN_usuarioCreacion,
            MAN_fechaCreacion = DateTime.UtcNow
        };
    }

    public static MantenimientoResponse ToResponse(this MantenimientoDataModel model)
    {
        return new MantenimientoResponse
        {
            MAN_id = model.MAN_id,
            VEH_id = model.VEH_id,
            MAN_fecha = model.MAN_fecha,
            MAN_descripcion = model.MAN_descripcion,
            MAN_costo = model.MAN_costo ?? 0m
        };
    }
}
