using MS.Identidad.Business.DTOs.LicenciaConducir;

namespace MS.Identidad.Business.Interfaces;

public interface ILicenciaConducirService
{
    Task<LicenciaConducirResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<LicenciaConducirResponse>> GetAllByClienteIdAsync(Guid clienteId);
    Task<IEnumerable<LicenciaConducirResponse>> GetAllAsync();
    Task<LicenciaConducirResponse> CreateAsync(CrearLicenciaConducirRequest request);
    Task<LicenciaConducirResponse> UpdateAsync(Guid id, ActualizarLicenciaConducirRequest request);
    Task<bool> DeleteAsync(Guid id);
}
