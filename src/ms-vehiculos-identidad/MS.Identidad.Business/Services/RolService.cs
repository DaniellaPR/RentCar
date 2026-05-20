using MS.Identidad.Business.DTOs.Rol;
using MS.Identidad.Business.Exceptions;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.Mappers;
using MS.Identidad.Business.Validators;
using MS.Identidad.DataManagement.Interfaces;

namespace MS.Identidad.Business.Services;

public class RolService : IRolService
{
    private readonly IUnitOfWork _unitOfWork;

    public RolService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<IEnumerable<RolResponse>> GetAllAsync()
    {
        var roles = (await _unitOfWork.Roles.GetPagedAsync(new MS.Identidad.DataManagement.Models.RolFiltroDataModel { PageSize = 1000 })).Items;
        return roles.Select(r => r.ToResponse());
    }

    public async Task<RolResponse> GetByIdAsync(Guid id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null) throw new NotFoundException("Rol", id);
        return rol.ToResponse();
    }

    public async Task<RolResponse> CreateAsync(CrearRolRequest request)
    {
        RolValidator.ValidarCreacion(request);
        var dataModel = request.ToDataModel();

        await _unitOfWork.Roles.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }

    public async Task<RolResponse> UpdateAsync(Guid id, ActualizarRolRequest request)
    {
        request.ROL_id = id;
        RolValidator.ValidarActualizacion(request);

        var rol = await _unitOfWork.Roles.GetByIdAsync(id);
        if (rol == null) throw new NotFoundException("Rol", id);

        rol.ROL_nombre = request.ROL_nombre;


        await _unitOfWork.Roles.UpdateAsync(rol);
        await _unitOfWork.CommitAsync();

        return rol.ToResponse();
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var rol = await _unitOfWork.Roles.GetByIdAsync(id) ?? throw new NotFoundException("Rol", id);
        await _unitOfWork.Roles.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return true;
    }
}
