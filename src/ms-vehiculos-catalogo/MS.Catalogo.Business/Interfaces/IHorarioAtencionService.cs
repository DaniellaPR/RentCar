using MS.Catalogo.Business.DTOs.HorarioAtencion;

namespace MS.Catalogo.Business.Interfaces
{
    public interface IHorarioAtencionService
    {
        Task<IEnumerable<HorarioAtencionResponse>> GetAllAsync();
        Task<HorarioAtencionResponse> GetByIdAsync(Guid id);
        Task<HorarioAtencionResponse> CreateAsync(CrearHorarioAtencionRequest request);
        Task<HorarioAtencionResponse> UpdateAsync(Guid id, ActualizarHorarioAtencionRequest request);
        Task DeleteAsync(Guid id, string usuarioModificacion);
    }
}
