using System;
using System.Threading.Tasks;
using MS.Monitoreo.DataManagement.Common;
using MS.Monitoreo.DataManagement.Models;

namespace MS.Monitoreo.DataManagement.Interfaces
{
    public interface IAuditoriaDataService
    {
        Task<DataPagedResult<AuditoriaDataModel>> GetPagedAsync(AuditoriaFiltroDataModel filtro);
        Task<AuditoriaDataModel> GetByIdAsync(Guid id);
        Task<AuditoriaDataModel> AddAsync(AuditoriaDataModel model);
        Task<AuditoriaDataModel> UpdateAsync(AuditoriaDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}