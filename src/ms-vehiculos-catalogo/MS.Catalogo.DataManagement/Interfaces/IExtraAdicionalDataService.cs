using System;
using System.Threading.Tasks;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Interfaces
{
    public interface IExtraAdicionalDataService
    {
        Task<DataPagedResult<ExtraAdicionalDataModel>> GetPagedAsync(ExtraAdicionalFiltroDataModel filtro);
        Task<ExtraAdicionalDataModel> GetByIdAsync(Guid id);
        Task<ExtraAdicionalDataModel> AddAsync(ExtraAdicionalDataModel model);
        Task<ExtraAdicionalDataModel> UpdateAsync(ExtraAdicionalDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}