using MS.Identidad.Business.DTOs.Cliente;
using MS.Identidad.Business.Exceptions;
using MS.Identidad.Business.Interfaces;
using MS.Identidad.Business.Mappers;
using MS.Identidad.Business.Validators;
using MS.Identidad.DataManagement.Interfaces;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.Business.Services;

public class ClienteService : IClienteService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<ClienteResponse>> GetAllAsync()
    {
        var filtro = new ClienteFiltroDataModel { PageSize = 1000 };
        var result = await _unitOfWork.Clientes.GetPagedAsync(filtro);
        return result.Items.Select(c => c.ToResponse());
    }

    public async Task<ClienteResponse> GetByIdAsync(Guid id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id)
            ?? throw new NotFoundException("Cliente", id);
        return cliente.ToResponse();
    }

    public async Task<ClienteResponse> CreateAsync(CrearClienteRequest request)
    {
        ClienteValidator.ValidarCreacion(request);

        var filtro = new ClienteFiltroDataModel { CedulaFiltro = request.CLI_cedula };
        var existentes = await _unitOfWork.Clientes.GetPagedAsync(filtro);
        if (existentes.Items.Any())
            throw new BusinessException($"Ya existe un cliente con la cédula {request.CLI_cedula}.");

        var dataModel = request.ToDataModel();
        await _unitOfWork.Clientes.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }

    public async Task<ClienteResponse> UpdateAsync(Guid id, ActualizarClienteRequest request)
    {
        request.CLI_id = id;
        ClienteValidator.ValidarActualizacion(request);

        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id)
            ?? throw new NotFoundException("Cliente", id);

        cliente.ApplyUpdate(request);
        await _unitOfWork.Clientes.UpdateAsync(cliente);
        await _unitOfWork.CommitAsync();

        return cliente.ToResponse();
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var cliente = await _unitOfWork.Clientes.GetByIdAsync(id) ?? throw new NotFoundException("Cliente", id);
        await _unitOfWork.Clientes.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
        return true;
    }
}
