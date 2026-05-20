using System;
using System.Collections.Generic;
using System.Text;

using MS.Identidad.Business.DTOs.Cliente;

namespace MS.Identidad.Business.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteResponse>> GetAllAsync();
        Task<ClienteResponse> GetByIdAsync(Guid id);
        Task<ClienteResponse> CreateAsync(CrearClienteRequest request);
        Task<ClienteResponse> UpdateAsync(Guid id, ActualizarClienteRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
