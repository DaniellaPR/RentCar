using System;
using System.Threading.Tasks;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Interfaces
{
    public interface ISucursalDataService
    {
        Task<DataPagedResult<SucursalDataModel>> GetPagedAsync(SucursalFiltroDataModel filtro);
        Task<SucursalDataModel> GetByIdAsync(Guid id);
        Task<SucursalDataModel> AddAsync(SucursalDataModel model);
        Task<SucursalDataModel> UpdateAsync(SucursalDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}