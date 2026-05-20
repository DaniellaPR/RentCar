using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataManagement.Interfaces;

namespace MS.Identidad.DataManagement.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentidadDbContext _context;

        public IClienteDataService Clientes { get; }
        public ILicenciaConducirDataService LicenciasConducir { get; }
        public IRolDataService Roles { get; }
        public IUsuarioAppDataService UsuariosApp { get; }

        public UnitOfWork(
            IdentidadDbContext context,
            IClienteDataService clientes,
            ILicenciaConducirDataService licenciasConducir,
            IRolDataService roles,
            IUsuarioAppDataService usuariosApp)
        {
            _context = context;
            Clientes = clientes;
            LicenciasConducir = licenciasConducir;
            Roles = roles;
            UsuariosApp = usuariosApp;
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