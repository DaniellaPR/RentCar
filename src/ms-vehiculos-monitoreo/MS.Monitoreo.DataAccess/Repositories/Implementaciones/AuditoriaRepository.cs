using MS.Monitoreo.DataAccess.Common;
using MS.Monitoreo.DataAccess.Context;
using MS.Monitoreo.DataAccess.Entities;
using MS.Monitoreo.DataAccess.Repositories.Interfaces;

namespace MS.Monitoreo.DataAccess.Repositories.Implementaciones
{
    public class AuditoriaRepository : RepositoryBase<AuditoriaEntity>, IAuditoriaRepository
    {
        public AuditoriaRepository(MonitoreoDbContext context) : base(context)
        {
        }
    }
}