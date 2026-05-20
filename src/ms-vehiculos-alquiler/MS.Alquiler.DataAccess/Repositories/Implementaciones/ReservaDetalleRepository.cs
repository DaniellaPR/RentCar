// ReservaDetalleRepository.cs
using MS.Alquiler.DataAccess.Common;
using MS.Alquiler.DataAccess.Context;
using MS.Alquiler.DataAccess.Entities;
using MS.Alquiler.DataAccess.Repositories.Interfaces;

namespace MS.Alquiler.DataAccess.Repositories.Implementaciones
{
    public class ReservaDetalleRepository : RepositoryBase<ReservaDetalleEntity>, IReservaDetalleRepository
    {
        public ReservaDetalleRepository(AlquilerDbContext context) : base(context) { }
    }
}