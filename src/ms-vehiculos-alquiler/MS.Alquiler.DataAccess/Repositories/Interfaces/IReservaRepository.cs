using MS.Alquiler.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Alquiler.DataAccess.Repositories.Interfaces
{
    internal interface IReservaRepository
    {
        public interface IReservaRepository : IRepositoryBase<ReservaEntity> { }
    }
}
