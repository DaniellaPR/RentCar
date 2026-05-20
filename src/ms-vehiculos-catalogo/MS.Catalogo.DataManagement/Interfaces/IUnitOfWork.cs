using MS.Catalogo.DataManagement.Interfaces;

namespace MS.Catalogo.DataManagement.Interfaces
{
    /// <summary>
    /// Contrato unificado del UnitOfWork para ms-catalogo.
    /// CORRECCIÓN: La versión original declaraba IRepositoryBase<T> (patrón antiguo inexistente).
    /// Ahora expone los IXxxDataService reales que el UnitOfWork.cs ya implementaba.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ICategoriaVehiculoDataService CategoriaVehiculos { get; }
        IExtraAdicionalDataService ExtrasAdicionales { get; }
        IHorarioAtencionDataService HorariosAtencion { get; }
        IMantenimientoDataService Mantenimientos { get; }
        ISeguroDataService Seguros { get; }
        ISucursalDataService Sucursales { get; }
        ITarifaDataService Tarifas { get; }
        IVehiculoDataService Vehiculos { get; }

        Task<int> CommitAsync();
    }
}