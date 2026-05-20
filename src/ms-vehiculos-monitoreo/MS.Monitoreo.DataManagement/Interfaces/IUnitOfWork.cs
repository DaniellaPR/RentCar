using MS.Monitoreo.DataManagement.Interfaces;

namespace MS.Monitoreo.DataManagement.Interfaces
{
    /// <summary>
    /// Contrato del UnitOfWork para ms-monitoreo.
    /// Estaba correcto. Se mantiene exactamente igual.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IAuditoriaDataService Auditorias { get; }

        Task<int> CommitAsync();
    }
}