using System;
using System.Threading.Tasks;
using MS.Alquiler.DataManagement.Common;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Interfaces
{
    public interface IPagoDataService
    {
        Task<DataPagedResult<PagoDataModel>> GetPagedAsync(PagoFiltroDataModel filtro);
        Task<PagoDataModel> GetByIdAsync(Guid id);
        Task<PagoDataModel> AddAsync(PagoDataModel model);
        Task<PagoDataModel> UpdateAsync(PagoDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}