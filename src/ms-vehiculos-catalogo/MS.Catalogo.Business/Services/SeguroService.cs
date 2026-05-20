using MS.Catalogo.Business.DTOs.Seguro;
using MS.Catalogo.Business.Exceptions;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Mappers;
using MS.Catalogo.Business.Validators;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Services;

public class SeguroService : ISeguroService
{
    private readonly IUnitOfWork _unitOfWork;
    public SeguroService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<SeguroResponse>> GetAllAsync()
    {
        var result = await _unitOfWork.Seguros.GetPagedAsync(new SeguroFiltroDataModel { PageSize = 1000 });
        return result.Items.Select(s => s.ToResponse());
    }

    public async Task<SeguroResponse> GetByIdAsync(Guid id)
    {
        var s = await _unitOfWork.Seguros.GetByIdAsync(id) ?? throw new NotFoundException("Seguro", id);
        return s.ToResponse();
    }

    public async Task<SeguroResponse> CreateAsync(CrearSeguroRequest request)
    {
        SeguroValidator.ValidarCreacion(request);
        var dm = request.ToDataModel();
        await _unitOfWork.Seguros.AddAsync(dm);
        await _unitOfWork.CommitAsync();
        return dm.ToResponse();
    }

    public async Task<SeguroResponse> UpdateAsync(Guid id, ActualizarSeguroRequest request)
    {
        SeguroValidator.ValidarActualizacion(request);
        var s = await _unitOfWork.Seguros.GetByIdAsync(id) ?? throw new NotFoundException("Seguro", id);
        s.SEG_nombre = request.SEG_nombre;
        s.SEG_cobertura = request.SEG_cobertura;
        s.SEG_costoDiario = request.SEG_costoDiario;
        s.SEG_usuarioModificacion = request.SEG_usuarioModificacion;
        s.SEG_fechaModificacion = DateTime.UtcNow;
        await _unitOfWork.Seguros.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return s.ToResponse();
    }

    public async Task DeleteAsync(Guid id, string usuarioModificacion)
    {
        var s = await _unitOfWork.Seguros.GetByIdAsync(id) ?? throw new NotFoundException("Seguro", id);

        s.SEG_usuarioModificacion = usuarioModificacion;
        s.SEG_fechaModificacion = DateTime.UtcNow;
        await _unitOfWork.Seguros.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
