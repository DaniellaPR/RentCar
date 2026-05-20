// MS.Catalogo.Business/Services/VehiculoService.cs
using MS.Catalogo.Business.DTOs.Vehiculo;
using MS.Catalogo.Business.Exceptions;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Mappers;
using MS.Catalogo.Business.Validators;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Services;

public class VehiculoService : IVehiculoService
{
    private readonly IUnitOfWork _unitOfWork;

    public VehiculoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<VehiculoResponse>> GetAllAsync()
    {
        var filtro = new VehiculoFiltroDataModel { PageSize = 1000, PageNumber = 1, EstadoFiltro = "ACTIVO" };
        var result = await _unitOfWork.Vehiculos.GetPagedAsync(filtro);

        var responses = new List<VehiculoResponse>();
        foreach (var v in result.Items)
        {
            var response = v.ToResponse();
            await EnrichWithTarifaAsync(response, v.CAT_id);
            await EnrichWithNombresAsync(response, v.CAT_id, v.SUC_id);
            responses.Add(response);
        }
        return responses;
    }

    public async Task<IEnumerable<VehiculoResponse>> GetDisponiblesAsync()
    {
        var todos = await GetAllAsync();
        return todos.Where(v => v.VEH_disponibilidad);
    }

    public async Task<VehiculoResponse> GetByIdAsync(Guid id)
    {
        var vehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(id)
            ?? throw new NotFoundException("Vehículo", id);

        if (vehiculo.VEH_estado != "ACTIVO")
            throw new NotFoundException("Vehículo", id);

        var response = vehiculo.ToResponse();
        await EnrichWithTarifaAsync(response, vehiculo.CAT_id);
        await EnrichWithNombresAsync(response, vehiculo.CAT_id, vehiculo.SUC_id);
        return response;
    }

    /// <summary>
    /// Verifica disponibilidad consultando solapamiento de reservas.
    /// En Reto 2: usa VEH_disponibilidad como flag rápido.
    /// En Reto 3: llamada gRPC a ms-alquiler para validación exacta por fechas.
    /// </summary>
    public async Task<bool> GetDisponibilidadAsync(Guid vehiculoId, DateTime fechaInicio, DateTime fechaFin)
    {
        var vehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(vehiculoId);
        if (vehiculo == null || vehiculo.VEH_estado != "ACTIVO")
            return false;

        // Reto 2: El flag VEH_disponibilidad es la fuente de verdad simple.
        // El ms-alquiler actualiza este flag al crear/cancelar reservas.
        return vehiculo.VEH_disponibilidad;
    }

    public async Task<VehiculoResponse> CreateAsync(CrearVehiculoRequest request)
    {
        VehiculoValidator.ValidarCreacion(request);

        var filtro = new VehiculoFiltroDataModel { PlacaFiltro = request.VEH_placa, EstadoFiltro = "ACTIVO" };
        var existentes = await _unitOfWork.Vehiculos.GetPagedAsync(filtro);
        if (existentes.Items.Any())
            throw new BusinessException($"Ya existe un vehículo activo con la placa {request.VEH_placa}.");

        var dataModel = request.ToDataModel();
        await _unitOfWork.Vehiculos.AddAsync(dataModel);
        await _unitOfWork.CommitAsync();

        var response = dataModel.ToResponse();
        await EnrichWithTarifaAsync(response, dataModel.CAT_id);
        return response;
    }

    public async Task<VehiculoResponse> UpdateAsync(Guid id, ActualizarVehiculoRequest request)
    {
        VehiculoValidator.ValidarActualizacion(request);

        var vehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(id)
            ?? throw new NotFoundException("Vehículo", id);

        vehiculo.CAT_id                      = request.CAT_id;
        vehiculo.SUC_id                      = request.SUC_id;
        vehiculo.VEH_placa                   = request.VEH_placa;
        vehiculo.VEH_marca                   = request.VEH_marca;
        vehiculo.VEH_modelo                  = request.VEH_modelo;
        vehiculo.VEH_anio                    = request.VEH_anio;
        vehiculo.VEH_color                   = request.VEH_color;
        vehiculo.VEH_kilometraje             = request.VEH_kilometraje;
        vehiculo.VEH_disponibilidad          = request.VEH_disponibilidad;
        vehiculo.VEH_imagenUrl               = request.VEH_imagenUrl;
        vehiculo.VEH_usuarioModificacion     = request.VEH_usuarioModificacion;
        vehiculo.VEH_modificadoDesdeIp       = request.VEH_modificadoDesdeIp;
        vehiculo.VEH_modificadoDesdeServicio = request.VEH_modificadoDesdeServicio;
        vehiculo.VEH_modificadoDesdeEquipo   = request.VEH_modificadoDesdeEquipo;
        vehiculo.VEH_fechaModificacion       = DateTime.UtcNow;

        await _unitOfWork.Vehiculos.UpdateAsync(vehiculo);
        await _unitOfWork.CommitAsync();

        return vehiculo.ToResponse();
    }

    public async Task DeleteAsync(Guid id, string usuarioModificacion)
    {
        var vehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(id)
            ?? throw new NotFoundException("Vehículo", id);

        vehiculo.VEH_estado              = "INACTIVO";
        vehiculo.VEH_disponibilidad      = false;
        vehiculo.VEH_usuarioModificacion = usuarioModificacion;
        vehiculo.VEH_fechaModificacion   = DateTime.UtcNow;

        await _unitOfWork.Vehiculos.UpdateAsync(vehiculo);
        await _unitOfWork.CommitAsync();
    }

    // ─── Helpers de enriquecimiento ──────────────────────────────────────────────

    private async Task EnrichWithTarifaAsync(VehiculoResponse response, Guid categoriaId)
    {
        var tarifaFiltro = new TarifaFiltroDataModel { CategoriaIdFiltro = categoriaId, PageSize = 1 };
        var tarifas = await _unitOfWork.Tarifas.GetPagedAsync(tarifaFiltro);
        var tarifa  = tarifas.Items.FirstOrDefault();
        response.PrecioPorDia = tarifa?.TAR_precioDiario ?? 0;
    }

    private async Task EnrichWithNombresAsync(VehiculoResponse response, Guid categoriaId, Guid sucursalId)
    {
        var categoria = await _unitOfWork.CategoriaVehiculos.GetByIdAsync(categoriaId);
        response.CategoriaNombre = categoria?.CAT_nombre ?? string.Empty;

        var sucursal = await _unitOfWork.Sucursales.GetByIdAsync(sucursalId);
        response.SucursalNombre = sucursal?.SUC_nombre ?? string.Empty;
    }
}
