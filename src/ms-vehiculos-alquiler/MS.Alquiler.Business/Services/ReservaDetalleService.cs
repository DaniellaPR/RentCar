// PARTE 5 — MS.Alquiler.Business/Services/ReservaDetalleService.cs
// CORRECCIÓN: Usa REX_id/RES_id/SEG_id/EXT_id/REX_cantidad del DataModel.

using MS.Alquiler.Business.DTOs.ReservaDetalle;
using MS.Alquiler.Business.Exceptions;
using MS.Alquiler.Business.Interfaces;
using MS.Alquiler.Business.Mappers;
using MS.Alquiler.Business.Validators;
using MS.Alquiler.DataManagement.Interfaces;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.Business.Services;

public class ReservaDetalleService : IReservaDetalleService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReservaDetalleService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<ReservaDetalleResponse> GetByIdAsync(Guid id)
    {
        var detalle = await _unitOfWork.ReservaDetalles.GetByIdAsync(id)
            ?? throw new NotFoundException("ReservaDetalle", id);
        return detalle.ToResponse();
    }

    public async Task<IEnumerable<ReservaDetalleResponse>> GetByReservaAsync(Guid reservaId)
    {
        var filtro = new ReservaDetalleFiltroDataModel { ReservaIdFiltro = reservaId, PageSize = 100 };
        var result = await _unitOfWork.ReservaDetalles.GetPagedAsync(filtro);
        return result.Items.Select(d => d.ToResponse());
    }

    public async Task<ReservaDetalleResponse> CreateAsync(CrearReservaDetalleRequest request)
    {
        ReservaDetalleValidator.ValidarCreacion(request);

        // Verificar que la reserva exista
        var reserva = await _unitOfWork.Reservas.GetByIdAsync(request.RES_id)
            ?? throw new NotFoundException("Reserva", request.RES_id);

        var dataModel = request.ToDataModel();
        await _unitOfWork.ReservaDetalles.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }

    public async Task<ReservaDetalleResponse> UpdateAsync(Guid id, ActualizarReservaDetalleRequest request)
    {
        request.REX_id = id;
        ReservaDetalleValidator.ValidarActualizacion(request);

        var detalle = await _unitOfWork.ReservaDetalles.GetByIdAsync(id)
            ?? throw new NotFoundException("ReservaDetalle", id);

        detalle.ApplyUpdate(request);
        await _unitOfWork.ReservaDetalles.UpdateAsync(detalle);
        await _unitOfWork.CommitAsync();

        return detalle.ToResponse();
    }

    public async Task DeleteAsync(Guid id)
    {
        var detalle = await _unitOfWork.ReservaDetalles.GetByIdAsync(id)
            ?? throw new NotFoundException("ReservaDetalle", id);

        await _unitOfWork.ReservaDetalles.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}