using MS.Identidad.DataAccess.Common;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataAccess.Entities;
using MS.Identidad.DataAccess.Repositories.Interfaces;

namespace MS.Identidad.DataAccess.Repositories.Implementaciones
{
    public class UsuarioAppRepository : RepositoryBase<UsuarioAppEntity>, IUsuarioAppRepository
    {
        public UsuarioAppRepository(IdentidadDbContext context) : base(context) { }
    }
}
