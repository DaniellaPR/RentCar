using System;
using System.Threading.Tasks;
using MS.Identidad.DataManagement.Common;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Interfaces
{
    public interface IClienteDataService
    {
        Task<DataPagedResult<ClienteDataModel>> GetPagedAsync(ClienteFiltroDataModel filtro);
        Task<ClienteDataModel> GetByIdAsync(Guid id);
        Task<ClienteDataModel> AddAsync(ClienteDataModel model);
        Task<ClienteDataModel> UpdateAsync(ClienteDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}