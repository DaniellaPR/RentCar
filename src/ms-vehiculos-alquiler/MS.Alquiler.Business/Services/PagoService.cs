// PARTE 5 — MS.Alquiler.Business/Services/PagoService.cs
// CORRECCIÓN: Usa PAG_id/RES_id/PAG_monto/PAG_metodo/PAG_estado del DataModel.
//             Usa ApplyUpdate del mapper en lugar de asignación manual.
//             GetAllAsync() → GetPagedAsync() que es lo que IPagoDataService expone.

using MS.Alquiler.Business.DTOs.Pago;
using MS.Alquiler.Business.Exceptions;
using MS.Alquiler.Business.Interfaces;
using MS.Alquiler.Business.Mappers;
using MS.Alquiler.Business.Validators;
using MS.Alquiler.DataManagement.Interfaces;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.Business.Services;

public class PagoService : IPagoService
{
    private readonly IUnitOfWork _unitOfWork;

    public PagoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<PagoResponse> GetByIdAsync(Guid id)
    {
        var pago = await _unitOfWork.Pagos.GetByIdAsync(id)
            ?? throw new NotFoundException("Pago", id);
        return pago.ToResponse();
    }

    public async Task<IEnumerable<PagoResponse>> GetAllByReservaIdAsync(Guid reservaId)
    {
        var filtro = new PagoFiltroDataModel { ReservaIdFiltro = reservaId, PageSize = 100 };
        var result = await _unitOfWork.Pagos.GetPagedAsync(filtro);
        return result.Items.Select(p => p.ToResponse());
    }

    public async Task<PagoResponse> CreateAsync(CrearPagoRequest request)
    {
        PagoValidator.ValidarCreacion(request);

        // Validar que la reserva exista antes de registrar el pago
        var reserva = await _unitOfWork.Reservas.GetByIdAsync(request.RES_id)
            ?? throw new NotFoundException("Reserva", request.RES_id);

        if (reserva.RES_estado == "CANCELADA")
            throw new BusinessException("No se puede registrar un pago sobre una reserva cancelada.");

        var dataModel = request.ToDataModel();
        await _unitOfWork.Pagos.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }

    public async Task<PagoResponse> UpdateAsync(Guid id, ActualizarPagoRequest request)
    {
        request.PAG_id = id;
        PagoValidator.ValidarActualizacion(request);

        var pago = await _unitOfWork.Pagos.GetByIdAsync(id)
            ?? throw new NotFoundException("Pago", id);

        pago.ApplyUpdate(request);
        await _unitOfWork.Pagos.UpdateAsync(pago);
        await _unitOfWork.CommitAsync();

        return pago.ToResponse();
    }
}