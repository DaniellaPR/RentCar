using MS.Catalogo.DataAccess.Context;
using MS.Catalogo.DataManagement.Interfaces;

namespace MS.Catalogo.DataManagement.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogoDbContext _context;

        public ICategoriaVehiculoDataService CategoriaVehiculos { get; }
        public IExtraAdicionalDataService ExtrasAdicionales { get; }
        public IHorarioAtencionDataService HorariosAtencion { get; }
        public IMantenimientoDataService Mantenimientos { get; }
        public ISeguroDataService Seguros { get; }
        public ISucursalDataService Sucursales { get; }
        public ITarifaDataService Tarifas { get; }
        public IVehiculoDataService Vehiculos { get; }

        public UnitOfWork(
            CatalogoDbContext context,
            ICategoriaVehiculoDataService categoriaVehiculos,
            IExtraAdicionalDataService extrasAdicionales,
            IHorarioAtencionDataService horariosAtencion,
            IMantenimientoDataService mantenimientos,
            ISeguroDataService seguros,
            ISucursalDataService sucursales,
            ITarifaDataService tarifas,
            IVehiculoDataService vehiculos)
        {
            _context = context;
            CategoriaVehiculos = categoriaVehiculos;
            ExtrasAdicionales = extrasAdicionales;
            HorariosAtencion = horariosAtencion;
            Mantenimientos = mantenimientos;
            Seguros = seguros;
            Sucursales = sucursales;
            Tarifas = tarifas;
            Vehiculos = vehiculos;
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