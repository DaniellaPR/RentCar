using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS.Alquiler.DataAccess.Context;
using MS.Alquiler.DataManagement.Common;
using MS.Alquiler.DataManagement.Interfaces;
using MS.Alquiler.DataManagement.Mappers;
using MS.Alquiler.DataManagement.Models;

namespace MS.Alquiler.DataManagement.Services
{
    public class ReservaDetalleDataService : IReservaDetalleDataService
    {
        private readonly AlquilerDbContext _context;

        public ReservaDetalleDataService(AlquilerDbContext context)
        {
            _context = context;
        }

        public async Task<DataPagedResult<ReservaDetalleDataModel>> GetPagedAsync(ReservaDetalleFiltroDataModel filtro)
        {
            var query = _context.ReservaDetalles.AsQueryable();

            if (filtro.ReservaIdFiltro.HasValue)
                query = query.Where(x => x.RES_id == filtro.ReservaIdFiltro.Value);

            if (filtro.ExtraIdFiltro.HasValue)
                query = query.Where(x => x.EXT_id == filtro.ExtraIdFiltro.Value);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtro.PageNumber - 1) * filtro.PageSize)
                .Take(filtro.PageSize)
                .ToListAsync();

            return new DataPagedResult<ReservaDetalleDataModel>
            {
                TotalCount = totalCount,
                PageNumber = filtro.PageNumber,
                PageSize = filtro.PageSize,
                Items = items.Select(x => x.ToDataModel())
            };
        }

        public async Task<ReservaDetalleDataModel> GetByIdAsync(Guid id)
        {
            var entity = await _context.ReservaDetalles.FindAsync(id);
            return entity?.ToDataModel();
        }

        public async Task<ReservaDetalleDataModel> AddAsync(ReservaDetalleDataModel model)
        {
            var entity = model.ToEntity();
            await _context.ReservaDetalles.AddAsync(entity);
            return entity.ToDataModel();
        }

        public async Task<ReservaDetalleDataModel> UpdateAsync(ReservaDetalleDataModel model)
        {
            var entity = model.ToEntity();
            _context.ReservaDetalles.Update(entity);
            return await Task.FromResult(entity.ToDataModel());
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.ReservaDetalles.FindAsync(id);
            if (entity == null) return false;

            _context.ReservaDetalles.Remove(entity);
            return true;
        }
    }
}