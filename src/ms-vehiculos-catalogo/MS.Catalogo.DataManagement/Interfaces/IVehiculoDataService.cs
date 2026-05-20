using System;
using System.Threading.Tasks;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Interfaces
{
    public interface IVehiculoDataService
    {
        Task<DataPagedResult<VehiculoDataModel>> GetPagedAsync(VehiculoFiltroDataModel filtro);
        Task<VehiculoDataModel> GetByIdAsync(Guid id);
        Task<VehiculoDataModel> AddAsync(VehiculoDataModel model);
        Task<VehiculoDataModel> UpdateAsync(VehiculoDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}