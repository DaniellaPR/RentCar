using MS.Identidad.DataManagement.Common;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Interfaces
{
    /// <summary>
    /// AMPLIADO: Se añade GetByEmailAsync para que el AuthService pueda
    /// validar credenciales en el login sin conocer el Id del usuario.
    /// </summary>
    public interface IUsuarioAppDataService
    {
        Task<DataPagedResult<UsuarioAppDataModel>> GetPagedAsync(UsuarioAppFiltroDataModel filtro);
        Task<UsuarioAppDataModel?> GetByIdAsync(Guid id);
        Task<UsuarioAppDataModel?> GetByEmailAsync(string email);   // ← NUEVO
        Task<UsuarioAppDataModel> AddAsync(UsuarioAppDataModel model);
        Task<UsuarioAppDataModel> UpdateAsync(UsuarioAppDataModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}