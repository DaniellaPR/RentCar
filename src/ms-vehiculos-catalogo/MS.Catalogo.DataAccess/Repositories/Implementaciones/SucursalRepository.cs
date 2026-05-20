using MS.Catalogo.DataAccess.Common;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataAccess.Repositories.Interfaces;

namespace MS.Catalogo.DataAccess.Repositories.Implementaciones
{
    public class SucursalRepository : RepositoryBase<SucursalEntity>, ISucursalRepository
    {
        public SucursalRepository(CatalogoDbContext context) : base(context)
        {
        }
    }
}