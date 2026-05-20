using System;
using System.Collections.Generic;
using System.Text;

using MS.Identidad.DataAccess.Common;
using MS.Identidad.DataAccess.Context;
using MS.Identidad.DataAccess.Entities;
using MS.Identidad.DataAccess.Repositories.Interfaces;

namespace MS.Identidad.DataAccess.Repositories.Implementaciones
{
    public class LicenciaConducirRepository : RepositoryBase<LicenciaConducirEntity>, ILicenciaConducirRepository
    {
        public LicenciaConducirRepository(IdentidadDbContext context) : base(context) { }
    }
}
