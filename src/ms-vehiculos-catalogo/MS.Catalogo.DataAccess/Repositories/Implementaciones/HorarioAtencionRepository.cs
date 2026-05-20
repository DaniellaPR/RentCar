using MS.Catalogo.DataAccess.Common;
using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataAccess.Entities;
using MS.Catalogo.DataAccess.Repositories.Interfaces;

namespace MS.Catalogo.DataAccess.Repositories.Implementaciones
{
    public class HorarioAtencionRepository : RepositoryBase<HorarioAtencionEntity>, IHorarioAtencionRepository
    {
        public HorarioAtencionRepository(CatalogoDbContext context) : base(context)
        {
        }
    }
}