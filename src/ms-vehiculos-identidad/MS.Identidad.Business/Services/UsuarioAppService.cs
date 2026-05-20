using MS.Identidad.Business.DTOs.UsuarioApp;
using MS.Identidad.Business.Exceptions;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.Mappers;
using MS.Identidad.Business.Validators;
using MS.Identidad.DataManagement.Interfaces;

namespace MS.Identidad.Business.Services;

public class UsuarioAppService : IUsuarioAppService
{
    private readonly IUnitOfWork _unitOfWork;

    public UsuarioAppService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<IEnumerable<UsuarioAppResponse>> GetAllAsync()
    {
        var usuarios = (await _unitOfWork.UsuariosApp.GetPagedAsync(new MS.Identidad.DataManagement.Models.UsuarioAppFiltroDataModel { PageSize = 1000 })).Items;
        return usuarios.Select(u => u.ToResponse());
    }
    public async Task<UsuarioAppResponse> GetByIdAsync(Guid id)
    {
        var usuario = await _unitOfWork.UsuariosApp.GetByIdAsync(id)
            ?? throw new NotFoundException("Usuario", id);

        return usuario.ToResponse();
    }

    public async Task<UsuarioAppResponse> CreateAsync(CrearUsuarioAppRequest request)
    {
        UsuarioAppValidator.ValidarCreacion(request);

        var existentes = (await _unitOfWork.UsuariosApp.GetPagedAsync(new MS.Identidad.DataManagement.Models.UsuarioAppFiltroDataModel { PageSize = 1000 })).Items;
        if (existentes.Any(u => u.USU_email.ToLower() == request.USU_email.ToLower()))
            throw new BusinessException("El correo ya está en uso.");

        // Regla: Hashear el password (usaremos BCrypt.Net-Next en la implementación real)
        string hashPlaceholder = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var dataModel = request.ToDataModel(hashPlaceholder);
        await _unitOfWork.UsuariosApp.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }

    public async Task<UsuarioAppResponse> UpdateAsync(Guid id, ActualizarUsuarioAppRequest request)
    {
        request.USU_id = id;
        UsuarioAppValidator.ValidarActualizacion(request);

        var usuario = await _unitOfWork.UsuariosApp.GetByIdAsync(id);
        if (usuario == null) throw new NotFoundException("Usuario", id);

        usuario.ROL_id = request.ROL_id;

        usuario.USU_email = request.USU_email.ToLower();


        await _unitOfWork.UsuariosApp.UpdateAsync(usuario);
        await _unitOfWork.CommitAsync();

        return usuario.ToResponse();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var usuario = await _unitOfWork.UsuariosApp.GetByIdAsync(id) ?? throw new NotFoundException("Usuario", id);
        await _unitOfWork.UsuariosApp.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return true;
    }
}
