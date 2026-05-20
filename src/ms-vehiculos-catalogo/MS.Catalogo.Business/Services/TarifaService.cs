using MS.Catalogo.Business.DTOs.Tarifa;
using MS.Catalogo.Business.Exceptions;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Mappers;
using MS.Catalogo.Business.Validators;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Services;

public class TarifaService : ITarifaService
{
    private readonly IUnitOfWork _unitOfWork;
    public TarifaService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<TarifaResponse>> GetAllAsync()
    {
        var result = await _unitOfWork.Tarifas.GetPagedAsync(new TarifaFiltroDataModel { PageSize = 1000 });
        return result.Items.Select(t => t.ToResponse());
    }

    public async Task<TarifaResponse> GetByIdAsync(Guid id)
    {
        var t = await _unitOfWork.Tarifas.GetByIdAsync(id) ?? throw new NotFoundException("Tarifa", id);
        return t.ToResponse();
    }

    public async Task<TarifaResponse> CreateAsync(CrearTarifaRequest request)
    {
        TarifaValidator.ValidarCreacion(request);
        var dm = request.ToDataModel();
        await _unitOfWork.Tarifas.AddAsync(dm);
        await _unitOfWork.CommitAsync();
        return dm.ToResponse();
    }

    public async Task<TarifaResponse> UpdateAsync(Guid id, ActualizarTarifaRequest request)
    {
        TarifaValidator.ValidarActualizacion(request);
        var t = await _unitOfWork.Tarifas.GetByIdAsync(id) ?? throw new NotFoundException("Tarifa", id);
        t.CAT_id = request.CAT_id;
        t.TAR_precioDiario = request.TAR_precioDiario;
        t.TAR_usuarioModificacion = request.TAR_usuarioModificacion;
        t.TAR_fechaModificacion = DateTime.UtcNow;
        await _unitOfWork.Tarifas.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return t.ToResponse();
    }

    public async Task DeleteAsync(Guid id, string usuarioModificacion)
    {
        var t = await _unitOfWork.Tarifas.GetByIdAsync(id) ?? throw new NotFoundException("Tarifa", id);

        t.TAR_usuarioModificacion = usuarioModificacion;
        t.TAR_fechaModificacion = DateTime.UtcNow;
        await _unitOfWork.Tarifas.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
