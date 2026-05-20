// PARTE 5 — MS.Monitoreo.Business/Services/AuditoriaService.cs
// CORRECCIÓN: GetAllAsync() → GetPagedAsync() (IAuditoriaDataService no tiene GetAllAsync).
//             Usa AUD_ prefijos del DataModel en la lógica.

using MS.Monitoreo.Business.DTOs.Auditoria;
using MS.Monitoreo.Business.Exceptions;
using MS.Monitoreo.Business.Interfaces;
using MS.Monitoreo.Business.Mappers;
using MS.Monitoreo.Business.Validators;
using MS.Monitoreo.DataManagement.Interfaces;
using MS.Monitoreo.DataManagement.Models;

namespace MS.Monitoreo.Business.Services;

public class AuditoriaService : IAuditoriaService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuditoriaService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<AuditoriaResponse>> GetAllAsync()
    {
        var filtro = new AuditoriaFiltroDataModel { PageSize = 500, PageNumber = 1 };
        var result = await _unitOfWork.Auditorias.GetPagedAsync(filtro);
        return result.Items
            .OrderByDescending(a => a.AUD_fecha)
            .Select(a => a.ToResponse());
    }

    public async Task<AuditoriaResponse> GetByIdAsync(Guid id)
    {
        var auditoria = await _unitOfWork.Auditorias.GetByIdAsync(id)
            ?? throw new NotFoundException("Auditoria", id);
        return auditoria.ToResponse();
    }

    public async Task<AuditoriaResponse> CreateAsync(CrearAuditoriaRequest request)
    {
        AuditoriaValidator.ValidarCreacion(request);

        var dataModel = request.ToDataModel();
        await _unitOfWork.Auditorias.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }
}