// ═══════════════════════════════════════════════════════════════
// SucursalService.cs — MS.Catalogo.Business/Services/
// ═══════════════════════════════════════════════════════════════
using MS.Catalogo.Business.DTOs.Sucursal;
using MS.Catalogo.Business.Exceptions;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Mappers;
using MS.Catalogo.Business.Validators;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Services;

public class SucursalService : ISucursalService
{
    private readonly IUnitOfWork _unitOfWork;
    public SucursalService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<SucursalResponse>> GetAllAsync()
    {
        var result = await _unitOfWork.Sucursales.GetPagedAsync(new SucursalFiltroDataModel { PageSize = 1000 });
        return result.Items.Select(s => s.ToResponse());
    }

    public async Task<SucursalResponse> GetByIdAsync(Guid id)
    {
        var s = await _unitOfWork.Sucursales.GetByIdAsync(id) ?? throw new NotFoundException("Sucursal", id);
        return s.ToResponse();
    }

    public async Task<SucursalResponse> CreateAsync(CrearSucursalRequest request)
    {
        SucursalValidator.ValidarCreacion(request);
        var dm = request.ToDataModel();
        await _unitOfWork.Sucursales.AddAsync(dm);
        await _unitOfWork.CommitAsync();
        return dm.ToResponse();
    }

    public async Task<SucursalResponse> UpdateAsync(Guid id, ActualizarSucursalRequest request)
    {
        SucursalValidator.ValidarActualizacion(request);
        var s = await _unitOfWork.Sucursales.GetByIdAsync(id) ?? throw new NotFoundException("Sucursal", id);
        s.SUC_nombre = request.SUC_nombre;
        s.SUC_ciudad = request.SUC_ciudad;
        s.SUC_direccion = request.SUC_direccion;
        s.SUC_coordenadas = request.SUC_coordenadas;
        s.SUC_usuarioModificacion = request.SUC_usuarioModificacion;
        s.SUC_fechaModificacion = DateTime.UtcNow;
        await _unitOfWork.Sucursales.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return s.ToResponse();
    }

    public async Task DeleteAsync(Guid id, string usuarioModificacion)
    {
        var s = await _unitOfWork.Sucursales.GetByIdAsync(id) ?? throw new NotFoundException("Sucursal", id);

        s.SUC_usuarioModificacion = usuarioModificacion;
        s.SUC_fechaModificacion = DateTime.UtcNow;
        await _unitOfWork.Sucursales.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
