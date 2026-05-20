using System;
using System.Threading.Tasks;
using MS.Alquiler.DataManagement.Common;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Interfaces
{
    public interface IReservaDetalleDataService
    {
        Task<DataPagedResult<ReservaDetalleDataModel>> GetPagedAsync(ReservaDetalleFiltroDataModel filtro);
        Task<ReservaDetalleDataModel> GetByIdAsync(Guid id);
        Task<ReservaDetalleDataModel> AddAsync(ReservaDetalleDataModel model);
        Task<ReservaDetalleDataModel> UpdateAsync(ReservaDetalleDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}