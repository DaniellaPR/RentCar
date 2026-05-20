using MS.Monitoreo.DataAccess.Context;
using MS.Monitoreo.DataManagement.Interfaces;

namespace MS.Monitoreo.DataManagement.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MonitoreoDbContext _context;

        public IAuditoriaDataService Auditorias { get; }

        public UnitOfWork(
            MonitoreoDbContext context,
            IAuditoriaDataService auditorias)
        {
            _context = context;
            Auditorias = auditorias;
        }

        public async Task<int> CommitAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}