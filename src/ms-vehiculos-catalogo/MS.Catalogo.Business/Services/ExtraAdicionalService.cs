using MS.Catalogo.Business.DTOs.ExtraAdicional;
using MS.Catalogo.Business.Exceptions;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Mappers;
using MS.Catalogo.Business.Validators;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Services;

public class ExtraAdicionalService : IExtraAdicionalService
{
    private readonly IUnitOfWork _unitOfWork;
    public ExtraAdicionalService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<ExtraAdicionalResponse>> GetAllAsync()
    {
        var result = await _unitOfWork.ExtrasAdicionales.GetPagedAsync(new ExtraAdicionalFiltroDataModel { PageSize = 1000 });
        return result.Items.Select(e => e.ToResponse());
    }

    public async Task<ExtraAdicionalResponse> GetByIdAsync(Guid id)
    {
        var e = await _unitOfWork.ExtrasAdicionales.GetByIdAsync(id) ?? throw new NotFoundException("ExtraAdicional", id);
        return e.ToResponse();
    }

    public async Task<ExtraAdicionalResponse> CreateAsync(CrearExtraAdicionalRequest request)
    {
        ExtraAdicionalValidator.ValidarCreacion(request);
        var dm = request.ToDataModel();
        await _unitOfWork.ExtrasAdicionales.AddAsync(dm);
        await _unitOfWork.CommitAsync();
        return dm.ToResponse();
    }

    public async Task<ExtraAdicionalResponse> UpdateAsync(Guid id, ActualizarExtraAdicionalRequest request)
    {
        ExtraAdicionalValidator.ValidarActualizacion(request);
        var e = await _unitOfWork.ExtrasAdicionales.GetByIdAsync(id) ?? throw new NotFoundException("ExtraAdicional", id);
        e.EXT_nombre = request.EXT_nombre;
        e.EXT_costo = request.EXT_costo;
        e.EXT_usuarioModificacion = request.EXT_usuarioModificacion;
        e.EXT_fechaModificacion = DateTime.UtcNow;
        await _unitOfWork.ExtrasAdicionales.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return e.ToResponse();
    }

    public async Task DeleteAsync(Guid id, string usuarioModificacion)
    {
        var e = await _unitOfWork.ExtrasAdicionales.GetByIdAsync(id) ?? throw new NotFoundException("ExtraAdicional", id);

        e.EXT_usuarioModificacion = usuarioModificacion;
        e.EXT_fechaModificacion = DateTime.UtcNow;
        await _unitOfWork.ExtrasAdicionales.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
