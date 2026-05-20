using System;
using System.Threading.Tasks;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Interfaces
{
    public interface ICategoriaVehiculoDataService
    {
        Task<DataPagedResult<CategoriaVehiculoDataModel>> GetPagedAsync(CategoriaVehiculoFiltroDataModel filtro);
        Task<CategoriaVehiculoDataModel> GetByIdAsync(Guid id);
        Task<CategoriaVehiculoDataModel> AddAsync(CategoriaVehiculoDataModel model);
        Task<CategoriaVehiculoDataModel> UpdateAsync(CategoriaVehiculoDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}