using MS.Alquiler.DataManagement.Interfaces;

namespace MS.Alquiler.DataManagement.Interfaces
{
    /// <summary>
    /// Contrato del UnitOfWork para ms-alquiler.
    /// Estaba correcto. Se añade GetDisponibilidadAsync a IReservaDataService
    /// para que el Business pueda validar solapamiento de fechas (requerido por el contrato Booking).
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IPagoDataService Pagos { get; }
        IReservaDataService Reservas { get; }
        IReservaDetalleDataService ReservaDetalles { get; }

        Task<int> CommitAsync();
    }
}