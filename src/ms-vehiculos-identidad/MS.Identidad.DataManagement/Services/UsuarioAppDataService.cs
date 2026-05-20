using Microsoft.EntityFrameworkCore;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataManagement.Common;
using MS.Identidad.DataManagement.Interfaces;
using MS.Identidad.DataManagement.Mappers;
using MS.Identidad.DataManagement.Models;

namespace MS.Identidad.DataManagement.Services
{
    public class UsuarioAppDataService : IUsuarioAppDataService
    {
        private readonly IdentidadDbContext _context;

        public UsuarioAppDataService(IdentidadDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<UsuarioAppDataModel>> GetPagedAsync(UsuarioAppFiltroDataModel filtro)
        {
            var query = _context.UsuariosApp.AsQueryable();

            if (filtro.RolIdFiltro.HasValue)
                query = query.Where(x => x.ROL_id == filtro.RolIdFiltro.Value);

            if (!string.IsNullOrEmpty(filtro.CorreoFiltro))
                query = query.Where(x => x.USU_email.Contains(filtro.CorreoFiltro));



            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<UsuarioAppDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }
        public async Task<UsuarioAppDataModel?> GetByIdAsync(Guid id)
        {
            var entity = await _context.UsuariosApp.FindAsync(id);
            return entity?.ToDataModel();
        }

        /// <summary>
        /// Busca un usuario activo por correo electrónico.
        /// Usado por el AuthService para validar credenciales en el login.
        /// </summary>
        public async Task<UsuarioAppDataModel?> GetByEmailAsync(string email)
        {
            var entity = await _context.UsuariosApp
                .FirstOrDefaultAsync(x => x.USU_email == email);
            return entity?.ToDataModel();
        }

        public async Task<UsuarioAppDataModel> AddAsync(UsuarioAppDataModel model)
        {
            var entity = model.ToEntity();
            entity.USU_id = Guid.NewGuid();
            entity.USU_fechaCreacion = DateTime.UtcNow;
            await _context.UsuariosApp.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<UsuarioAppDataModel> UpdateAsync(UsuarioAppDataModel model)
        {
            var entity = model.ToEntity();
            entity.USU_fechaModificacion = DateTime.UtcNow;
            _context.UsuariosApp.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.UsuariosApp.FindAsync(id);
            if (entity == null) return false;
            _context.UsuariosApp.Remove(entity);
            return true;
        }
    }
}