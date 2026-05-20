using MS.Catalogo.Business.DTOs.CategoriaVehiculo;
using MS.Catalogo.Business.Exceptions;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Mappers;
using MS.Catalogo.Business.Validators;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Services;

public class CategoriaVehiculoService : ICategoriaVehiculoService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriaVehiculoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<CategoriaVehiculoResponse>> GetAllAsync()
    {
        var filtro = new CategoriaVehiculoFiltroDataModel { PageSize = 1000 };
        var result = await _unitOfWork.CategoriaVehiculos.GetPagedAsync(filtro);
        return result.Items
            
            .Select(c => c.ToResponse());
    }

    public async Task<CategoriaVehiculoResponse> GetByIdAsync(Guid id)
    {
        var categoria = await _unitOfWork.CategoriaVehiculos.GetByIdAsync(id)
            ?? throw new NotFoundException("CategoriaVehiculo", id);

        if (false)
            throw new NotFoundException("CategoriaVehiculo", id);

        return categoria.ToResponse();
    }

    public async Task<CategoriaVehiculoResponse> CreateAsync(CrearCategoriaVehiculoRequest request)
    {
        CategoriaVehiculoValidator.ValidarCreacion(request);

        var filtro = new CategoriaVehiculoFiltroDataModel { NombreFiltro = request.CAT_nombre };
        var existentes = await _unitOfWork.CategoriaVehiculos.GetPagedAsync(filtro);
        if (existentes.Items.Any(c => c.CAT_nombre.Trim().ToLower() == request.CAT_nombre.Trim().ToLower()))
            throw new BusinessException($"Ya existe una categora activa con el nombre {request.CAT_nombre}.");

        var dataModel = request.ToDataModel();
        await _unitOfWork.CategoriaVehiculos.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        return dataModel.ToResponse();
    }

    public async Task<CategoriaVehiculoResponse> UpdateAsync(Guid id, ActualizarCategoriaVehiculoRequest request)
    {
        var categoria = await _unitOfWork.CategoriaVehiculos.GetByIdAsync(id)
            ?? throw new NotFoundException("CategoriaVehiculo", id);

        categoria.CAT_nombre = request.CAT_nombre;
        categoria.CAT_descripcion = request.CAT_descripcion;
        categoria.CAT_costoBase = request.CAT_costoBase;
        categoria.CAT_capacidadPasajeros = request.CAT_capacidadPasajeros;
        categoria.CAT_capacidadMaletas = request.CAT_capacidadMaletas;
        categoria.CAT_tipoTransmision = request.CAT_tipoTransmision;
        categoria.CAT_usuarioModificacion = request.CAT_usuarioModificacion;
        categoria.CAT_fechaModificacion = DateTime.UtcNow;

        await _unitOfWork.CategoriaVehiculos.DeleteAsync(id);
        await _unitOfWork.CommitAsync();

        return categoria.ToResponse();
    }

    public async Task DeleteAsync(Guid id, string usuarioModificacion)
    {
        var categoria = await _unitOfWork.CategoriaVehiculos.GetByIdAsync(id)
            ?? throw new NotFoundException("CategoriaVehiculo", id);


        categoria.CAT_usuarioModificacion = usuarioModificacion;
        categoria.CAT_fechaModificacion = DateTime.UtcNow;

        await _unitOfWork.CategoriaVehiculos.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
