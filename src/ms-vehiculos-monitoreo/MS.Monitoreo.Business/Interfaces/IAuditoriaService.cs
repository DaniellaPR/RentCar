// PARTE 5 — MS.Monitoreo.Business/Interfaces/IAuditoriaService.cs
// Sin cambio de firma — solo los tipos de DTO ahora son los corregidos.

using MS.Monitoreo.Business.DTOs.Auditoria;

namespace MS.Monitoreo.Business.Interfaces;

public interface IAuditoriaService
{
    Task<AuditoriaResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<AuditoriaResponse>> GetAllAsync();
    Task<AuditoriaResponse> CreateAsync(CrearAuditoriaRequest request);
}