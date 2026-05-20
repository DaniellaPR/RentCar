using MS.Catalogo.Business.DTOs.Mantenimiento;
namespace MS.Catalogo.Business.Interfaces;

public interface IMantenimientoService
{
    Task<MantenimientoResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<MantenimientoResponse>> GetAllAsync();
    Task<MantenimientoResponse> CreateAsync(CrearMantenimientoRequest request);
    Task<MantenimientoResponse> UpdateAsync(Guid id, ActualizarMantenimientoRequest request);
    Task DeleteAsync(Guid id, string usuarioModificacion);
}
