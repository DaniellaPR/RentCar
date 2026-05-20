using MS.Catalogo.DataAccess.Common;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataAccess.Repositories.Interfaces;

namespace MS.Catalogo.DataAccess.Repositories.Implementaciones
{
    public class SeguroRepository : RepositoryBase<SeguroEntity>, ISeguroRepository
    {
        public SeguroRepository(CatalogoDbContext context) : base(context)
        {
        }
    }
}