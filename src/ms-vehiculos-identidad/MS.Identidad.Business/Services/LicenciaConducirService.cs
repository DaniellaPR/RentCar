using MS.Identidad.Business.DTOs.LicenciaConducir;
using MS.Identidad.Business.Exceptions;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.Mappers;
using MS.Identidad.Business.Validators;
using MS.Identidad.DataManagement.Interfaces;

namespace MS.Identidad.Business.Services;

public class LicenciaConducirService : ILicenciaConducirService
{
    private readonly IUnitOfWork _unitOfWork;

    public LicenciaConducirService(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<IEnumerable<LicenciaConducirResponse>> GetAllByClienteIdAsync(Guid clienteId)
    {
        var licencias = (await _unitOfWork.LicenciasConducir.GetPagedAsync(new MS.Identidad.DataManagement.Models.LicenciaConducirFiltroDataModel { PageSize = 1000 })).Items;
        return licencias.Where(l => l.CLI_id == clienteId).Select(l => l.ToResponse());
    }

    public async Task<LicenciaConducirResponse> GetByIdAsync(Guid id)
    {
        var licencia = await _unitOfWork.LicenciasConducir.GetByIdAsync(id);
        if (licencia == null) throw new NotFoundException("Licencia", id);
        return licencia.ToResponse();
    }

    public async Task<LicenciaConducirResponse> CreateAsync(CrearLicenciaConducirRequest request)
    {
        LicenciaConducirValidator.ValidarCreacion(request);

        // Opcional: Validar que el cliente exista
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(request.CLI_id);
        if (cliente == null) throw new NotFoundException("Cliente", request.CLI_id);

        var dataModel = request.ToDataModel();

        await _unitOfWork.LicenciasConducir.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }

    public async Task<LicenciaConducirResponse> UpdateAsync(Guid id, ActualizarLicenciaConducirRequest request)
    {
        request.LIC_id = id;
        LicenciaConducirValidator.ValidarActualizacion(request);

        var licencia = await _unitOfWork.LicenciasConducir.GetByIdAsync(id);
        if (licencia == null) throw new NotFoundException("Licencia", id);

        licencia.CLI_id = request.CLI_id;
        licencia.LIC_numero = request.LIC_numero;
        licencia.LIC_categoria = request.LIC_categoria;
        licencia.LIC_vigencia = request.LIC_vigencia;

        await _unitOfWork.LicenciasConducir.UpdateAsync(licencia);
        await _unitOfWork.CommitAsync();

        return licencia.ToResponse();
    }

    public async Task<IEnumerable<LicenciaConducirResponse>> GetAllAsync()
    {
        var licencias = (await _unitOfWork.LicenciasConducir.GetPagedAsync(new MS.Identidad.DataManagement.Models.LicenciaConducirFiltroDataModel { PageSize = 1000 })).Items;
        return licencias.Select(l => l.ToResponse());
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var licencia = await _unitOfWork.LicenciasConducir.GetByIdAsync(id) ?? throw new NotFoundException("Licencia", id);
        await _unitOfWork.LicenciasConducir.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return true;
    }
}
