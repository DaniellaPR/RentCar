using MS.Monitoreo.DataAccess.Common;
using MS.Monitoreo.DataAccess.Entities;
// Asumiendo que también copiaste IRepositoryBase.cs en esta carpeta
namespace MS.Monitoreo.DataAccess.Repositories.Interfaces
{
    public interface IAuditoriaRepository : IRepositoryBase<AuditoriaEntity>
    {
    }
}