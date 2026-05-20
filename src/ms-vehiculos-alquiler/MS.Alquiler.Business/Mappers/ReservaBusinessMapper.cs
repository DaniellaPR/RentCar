// MS.Alquiler.Business/Mappers/ReservaBusinessMapper.cs
using MS.Alquiler.Business.DTOs.Reserva;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.Business.Mappers;   // ← mismo namespace que los otros

public static class ReservaBusinessMapper
{
    public static ReservaDataModel ToDataModel(this CrearReservaRequest request)
    {
        return new ReservaDataModel
        {
            RES_id = Guid.NewGuid(),
            CLI_id = request.CLI_id,
            VEH_id = request.VEH_id,
            RES_sucursalRetiroId = request.RES_sucursalRetiroId,
            RES_sucursalEntregaId = request.RES_sucursalEntregaId,
            RES_fechaRetiro = request.RES_fechaRetiro,
            RES_fechaEntrega = request.RES_fechaEntrega,
            RES_usuarioCreacion = request.RES_usuarioCreacion,
            RES_fechaCreacion = DateTime.UtcNow
        };
    }

    public static ReservaDataModel ApplyUpdate(
        this ReservaDataModel model, ActualizarReservaRequest request)
    {
        model.CLI_id = request.CLI_id;
        model.VEH_id = request.VEH_id;
        model.RES_sucursalRetiroId = request.RES_sucursalRetiroId;
        model.RES_sucursalEntregaId = request.RES_sucursalEntregaId;
        model.RES_fechaRetiro = request.RES_fechaRetiro;
        model.RES_fechaEntrega = request.RES_fechaEntrega;
        model.RES_usuarioModificacion = request.RES_usuarioModificacion;
        model.RES_fechaModificacion = DateTime.UtcNow;
        return model;
    }

    public static ReservaResponse ToResponse(this ReservaDataModel model)
    {
        return new ReservaResponse
        {
            RES_id = model.RES_id,
            CLI_id = model.CLI_id,
            VEH_id = model.VEH_id,
            RES_sucursalRetiroId = model.RES_sucursalRetiroId,
            RES_sucursalEntregaId = model.RES_sucursalEntregaId,
            RES_fechaRetiro = model.RES_fechaRetiro,
            RES_fechaEntrega = model.RES_fechaEntrega,
            RES_total = 0, // Calculado en negocio
            RES_fechaCreacion = model.RES_fechaCreacion
        };
    }
}