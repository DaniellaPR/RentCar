using System;
using System.Threading.Tasks;
using MS.Identidad.DataManagement.Common;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Interfaces
{
    public interface ILicenciaConducirDataService
    {
        Task<DataPagedResult<LicenciaConducirDataModel>> GetPagedAsync(LicenciaConducirFiltroDataModel filtro);
        Task<LicenciaConducirDataModel> GetByIdAsync(Guid id);
        Task<LicenciaConducirDataModel> AddAsync(LicenciaConducirDataModel model);
        Task<LicenciaConducirDataModel> UpdateAsync(LicenciaConducirDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}