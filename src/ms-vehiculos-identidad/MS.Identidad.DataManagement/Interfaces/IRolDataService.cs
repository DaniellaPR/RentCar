using System;
using System.Threading.Tasks;
using MS.Identidad.DataManagement.Common;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Interfaces
{
    public interface IRolDataService
    {
        Task<DataPagedResult<RolDataModel>> GetPagedAsync(RolFiltroDataModel filtro);
        Task<RolDataModel> GetByIdAsync(Guid id);
        Task<RolDataModel> AddAsync(RolDataModel model);
        Task<RolDataModel> UpdateAsync(RolDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}