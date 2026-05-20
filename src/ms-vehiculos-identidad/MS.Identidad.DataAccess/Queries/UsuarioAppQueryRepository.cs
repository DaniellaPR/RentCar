using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataAccess.Entities;

namespace MS.Identidad.DataAccess.Queries
{
    public class UsuarioAppQueryRepository
    {
        private readonly IdentidadDbContext _context;

        public UsuarioAppQueryRepository(IdentidadDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioAppEntity?> GetByCorreoAsync(string correo)
        {
            return await _context.UsuariosApp
                .Include(u => u.Rol)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.USU_email == correo);
        }
    }
}