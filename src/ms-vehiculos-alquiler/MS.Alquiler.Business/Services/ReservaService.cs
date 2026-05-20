// MS.Alquiler.Business/Services/ReservaService.cs
// FIX completo:
//   - Llama ReservaBusinessMapper.XXX() explícito para evitar ambigüedad con ReservaDetalleBusinessMapper
//   - Implementa DeleteAsync que faltaba
//   - PageNumber siempre inicializado

using MS.Alquiler.Business.DTOs.Reserva;
using MS.Alquiler.Business.Exceptions;
using MS.Alquiler.Business.Interfaces;
using MS.Alquiler.Business.Mappers;
using MS.Alquiler.Business.Validators;
using MS.Alquiler.DataManagement.Interfaces;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.Business.Services;

public class ReservaService : IReservaService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReservaService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    // ── Lectura ───────────────────────────────────────────────────────────────

    public async Task<IEnumerable<ReservaResponse>> GetAllAsync()
    {
        var filtro = new ReservaFiltroDataModel { PageNumber = 1, PageSize = 1000 };
        var result = await _unitOfWork.Reservas.GetPagedAsync(filtro);
        return result.Items.Select(r => ReservaBusinessMapper.ToResponse(r));
    }

    public async Task<ReservaResponse> GetByIdAsync(Guid id)
    {
        var reserva = await _unitOfWork.Reservas.GetByIdAsync(id)
            ?? throw new NotFoundException("Reserva", id);
        return ReservaBusinessMapper.ToResponse(reserva);
    }

    public async Task<IEnumerable<ReservaResponse>> GetByClienteAsync(Guid clienteId)
    {
        var filtro = new ReservaFiltroDataModel
        {
            ClienteIdFiltro = clienteId,
            PageNumber = 1,
            PageSize = 1000
        };
        var result = await _unitOfWork.Reservas.GetPagedAsync(filtro);
        return result.Items.Select(r => ReservaBusinessMapper.ToResponse(r));
    }

    // ── Contrato Booking: GET /vehiculos/{id}/disponibilidad ─────────────────

    public async Task<bool> GetDisponibilidadAsync(
        Guid vehiculoId, DateTime fechaRetiro, DateTime fechaEntrega)
    {
        var conflictos = await _unitOfWork.Reservas
            .GetByVehiculoEnRangoAsync(vehiculoId, fechaRetiro, fechaEntrega);
        return !conflictos.Any();
    }

    // ── Escritura ─────────────────────────────────────────────────────────────

    public async Task<ReservaResponse> CreateAsync(CrearReservaRequest request)
    {
        ReservaValidator.ValidarCreacion(request);

        var conflictos = await _unitOfWork.Reservas.GetByVehiculoEnRangoAsync(
            request.VEH_id, request.RES_fechaRetiro, request.RES_fechaEntrega);

        if (conflictos.Any())
            throw new BusinessException(
                "El vehículo ya se encuentra reservado en las fechas solicitadas.");

        var dataModel = ReservaBusinessMapper.ToDataModel(request);
        await _unitOfWork.Reservas.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return ReservaBusinessMapper.ToResponse(dataModel);
    }

    public async Task<ReservaResponse> UpdateAsync(Guid id, ActualizarReservaRequest request)
    {
        request.RES_id = id;
        ReservaValidator.ValidarActualizacion(request);

        var reserva = await _unitOfWork.Reservas.GetByIdAsync(id)
            ?? throw new NotFoundException("Reserva", id);

        if (reserva.RES_estado == "CANCELADA")
            throw new BusinessException("No se puede modificar una reserva cancelada.");

        var updated = ReservaBusinessMapper.ApplyUpdate(reserva, request);
        await _unitOfWork.Reservas.UpdateAsync(updated);
        await _unitOfWork.CommitAsync();

        return ReservaBusinessMapper.ToResponse(updated);
    }

    public async Task CancelarReservaAsync(Guid id)
    {
        var reserva = await _unitOfWork.Reservas.GetByIdAsync(id)
            ?? throw new NotFoundException("Reserva", id);

        if (reserva.RES_estado == "COMPLETADA")
            throw new BusinessException(
                "No se puede cancelar una reserva que ya fue completada.");

        reserva.RES_estado = "CANCELADA";
        reserva.RES_fechaModificacion = DateTime.UtcNow;

        await _unitOfWork.Reservas.UpdateAsync(reserva);
        await _unitOfWork.CommitAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var result = await _unitOfWork.Reservas.DeleteAsync(id);
        if (!result) throw new NotFoundException("Reserva", id);
        await _unitOfWork.CommitAsync();
        return true;
    }
}
