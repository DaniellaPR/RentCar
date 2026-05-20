using MS.Catalogo.Business.DTOs.Mantenimiento;
using MS.Catalogo.Business.Exceptions;
using MS.Catalogo.Business.Interfaces;
using MS.Catalogo.Business.Mappers;
using MS.Catalogo.Business.Validators;
using MS.Catalogo.DataManagement.Interfaces;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.Business.Services;

public class MantenimientoService : IMantenimientoService
{
    private readonly IUnitOfWork _unitOfWork;
    public MantenimientoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<IEnumerable<MantenimientoResponse>> GetAllAsync()
    {
        var result = await _unitOfWork.Mantenimientos.GetPagedAsync(new MantenimientoFiltroDataModel { PageSize = 1000 });
        return result.Items.Select(m => m.ToResponse());
    }

    public async Task<MantenimientoResponse> GetByIdAsync(Guid id)
    {
        var m = await _unitOfWork.Mantenimientos.GetByIdAsync(id) ?? throw new NotFoundException("Mantenimiento", id);
        return m.ToResponse();
    }

    public async Task<MantenimientoResponse> CreateAsync(CrearMantenimientoRequest request)
    {
        MantenimientoValidator.ValidarCreacion(request);
        var dm = request.ToDataModel();

        await _unitOfWork.Mantenimientos.AddAsync(dm);

        // Bloquear disponibilidad del vehículo mientras está en mantenimiento
        var vehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(request.VEH_id);
        if (vehiculo != null)
        {
            vehiculo.VEH_estado = "Mantenimiento";
            await _unitOfWork.Vehiculos.UpdateAsync(vehiculo);
        }

        await _unitOfWork.CommitAsync();
        return dm.ToResponse();
    }

    public async Task<MantenimientoResponse> UpdateAsync(Guid id, ActualizarMantenimientoRequest request)
    {
        MantenimientoValidator.ValidarActualizacion(request);
        var m = await _unitOfWork.Mantenimientos.GetByIdAsync(id) ?? throw new NotFoundException("Mantenimiento", id);

        m.VEH_id = request.VEH_id;
        m.MAN_fecha = request.MAN_fecha;
        m.MAN_descripcion = request.MAN_descripcion;
        m.MAN_costo = request.MAN_costo;
        m.MAN_usuarioModificacion = request.MAN_usuarioModificacion;
        m.MAN_fechaModificacion = DateTime.UtcNow;

        await _unitOfWork.Mantenimientos.UpdateAsync(m);
        await _unitOfWork.CommitAsync();
        return m.ToResponse();
    }

    public async Task DeleteAsync(Guid id, string usuarioModificacion)
    {
        var m = await _unitOfWork.Mantenimientos.GetByIdAsync(id) ?? throw new NotFoundException("Mantenimiento", id);

        // Al eliminar el mantenimiento, el vehículo vuelve a estar disponible
        var vehiculo = await _unitOfWork.Vehiculos.GetByIdAsync(m.VEH_id);
        if (vehiculo != null)
        {
            vehiculo.VEH_estado = "Disponible";
            await _unitOfWork.Vehiculos.UpdateAsync(vehiculo);
        }

        await _unitOfWork.Mantenimientos.DeleteAsync(id);
        await _unitOfWork.CommitAsync();
    }
}
