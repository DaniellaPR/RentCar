using MS.Catalogo.Business.DTOs.ExtraAdicional;

namespace MS.Catalogo.Business.Interfaces;

public interface IExtraAdicionalService
{
    Task<ExtraAdicionalResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<ExtraAdicionalResponse>> GetAllAsync();
    Task<ExtraAdicionalResponse> CreateAsync(CrearExtraAdicionalRequest request);
    Task<ExtraAdicionalResponse> UpdateAsync(Guid id, ActualizarExtraAdicionalRequest request);
    Task DeleteAsync(Guid id, string usuarioModificacion);
}
