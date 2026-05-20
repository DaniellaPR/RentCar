using MS.Identidad.DataManagement.Interfaces;

namespace MS.Identidad.DataManagement.Interfaces
{
    /// <summary>
    /// Contrato del UnitOfWork para ms-identidad.
    /// Estaba correcto. Se mantiene igual.
    /// El GetByEmailAsync se añade en IUsuarioAppDataService (archivo separado)
    /// porque el AuthService lo necesita para el login.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IClienteDataService Clientes { get; }
        ILicenciaConducirDataService LicenciasConducir { get; }
        IRolDataService Roles { get; }
        IUsuarioAppDataService UsuariosApp { get; }

        Task<int> CommitAsync();
    }
}