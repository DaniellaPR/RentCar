using System;
using System.Threading.Tasks;
using MS.Catalogo.DataManagement.Common;
using MS.Catalogo.DataManagement.Models;

namespace MS.Catalogo.DataManagement.Interfaces
{
    public interface IHorarioAtencionDataService
    {
        Task<DataPagedResult<HorarioAtencionDataModel>> GetPagedAsync(HorarioAtencionFiltroDataModel filtro);
        Task<HorarioAtencionDataModel> GetByIdAsync(Guid id);
        Task<HorarioAtencionDataModel> AddAsync(HorarioAtencionDataModel model);
        Task<HorarioAtencionDataModel> UpdateAsync(HorarioAtencionDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}