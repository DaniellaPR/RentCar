using MS.Identidad.DataAccess.Common;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MS.Identidad.DataAccess.Repositories.Interfaces;

namespace MS.Identidad.DataAccess.Repositories.Implementaciones
{
    public class ClienteRepository : RepositoryBase<ClienteEntity>, IClienteRepository
    {
        public ClienteRepository(IdentidadDbContext context) : base(context) { }
    }
}
