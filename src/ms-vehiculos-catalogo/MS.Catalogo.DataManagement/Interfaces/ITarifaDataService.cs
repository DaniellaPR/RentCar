using System;
using System.Threading.Tasks;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Interfaces
{
    public interface ITarifaDataService
    {
        Task<DataPagedResult<TarifaDataModel>> GetPagedAsync(TarifaFiltroDataModel filtro);
        Task<TarifaDataModel> GetByIdAsync(Guid id);
        Task<TarifaDataModel> AddAsync(TarifaDataModel model);
        Task<TarifaDataModel> UpdateAsync(TarifaDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}