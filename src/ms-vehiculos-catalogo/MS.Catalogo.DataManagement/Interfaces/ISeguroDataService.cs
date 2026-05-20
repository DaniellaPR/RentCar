using System;
using System.Threading.Tasks;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Interfaces
{
    public interface ISeguroDataService
    {
        Task<DataPagedResult<SeguroDataModel>> GetPagedAsync(SeguroFiltroDataModel filtro);
        Task<SeguroDataModel> GetByIdAsync(Guid id);
        Task<SeguroDataModel> AddAsync(SeguroDataModel model);
        Task<SeguroDataModel> UpdateAsync(SeguroDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}