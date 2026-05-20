using MS.Catalogo.Business.DTOs.Seguro;

namespace MS.Catalogo.Business.Interfaces;

public interface ISeguroService
{
    Task<SeguroResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<SeguroResponse>> GetAllAsync();
    Task<SeguroResponse> CreateAsync(CrearSeguroRequest request);
    Task<SeguroResponse> UpdateAsync(Guid id, ActualizarSeguroRequest request);
    Task DeleteAsync(Guid id, string usuarioModificacion);
}
