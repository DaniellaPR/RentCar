using System;
using System.Threading.Tasks;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Interfaces
{
    public interface IMantenimientoDataService
    {
        Task<DataPagedResult<MantenimientoDataModel>> GetPagedAsync(MantenimientoFiltroDataModel filtro);
        Task<MantenimientoDataModel> GetByIdAsync(Guid id);
        Task<MantenimientoDataModel> AddAsync(MantenimientoDataModel model);
        Task<MantenimientoDataModel> UpdateAsync(MantenimientoDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}