using MS.Alquiler.DataAccess.Context;
using MS.Alquiler.DataManagement.Interfaces;

namespace MS.Alquiler.DataManagement.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlquilerDbContext _context;

        public IPagoDataService Pagos { get; }
        public IReservaDataService Reservas { get; }
        public IReservaDetalleDataService ReservaDetalles { get; }

        public UnitOfWork(
            AlquilerDbContext context,
            IPagoDataService pagos,
            IReservaDataService reservas,
            IReservaDetalleDataService reservaDetalles)
        {
            _context = context;
            Pagos = pagos;
            Reservas = reservas;
            ReservaDetalles = reservaDetalles;
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