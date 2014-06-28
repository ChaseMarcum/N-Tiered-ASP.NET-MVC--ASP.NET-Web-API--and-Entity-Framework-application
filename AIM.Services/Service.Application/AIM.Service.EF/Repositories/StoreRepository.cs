using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TrackableEntities.Patterns.EF6;
using AIM.Service.EF.Contexts;
using AIM.Service.Entities.Models;
using AIM.Service.Persistence.Repositories;

namespace AIM.Service.EF.Repositories
{
    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        private readonly IAIM_DBContext _context;

        public StoreRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Store>> GetStores()
        {

            IEnumerable<Store> entities = await _context.Stores
                .Include(t => t.OpenJobs)
                .Include(t => t.Region)
                .ToListAsync();
            return entities;
        }

        public async Task<Store> GetStore(int id)
        {
            Store entity = await _context.Stores
                .Include(t => t.OpenJobs)
                .Include(t => t.Region)
                .SingleOrDefaultAsync(t => t.StoreId == id);
            return entity;
        }

        public async Task<IEnumerable<Store>> GetStoresByRegionId(int regionId)
        {
            IEnumerable<Store> entity = await _context.Stores
                .Where(t => t.RegionId == regionId)
                .Include(t => t.OpenJobs)
                .Include(t => t.Region)
                .ToListAsync();
            return entity;
        }

        public async Task<IEnumerable<OpenJob>> GetOpenJobsByRegionId(int regionId)
        {
            IEnumerable<OpenJob> entities = await _context.OpenJobs
                .Where(t => t.RegionId == regionId)
                .Include(t => t.Job)
                .Include(t => t.Store)
                .Include(t => t.Region)
                .ToListAsync();
            return entities;
        }

        public async Task<bool> DeleteStore(int id)
        {
            Store entity = await _context.Stores
                .Include(t => t.OpenJobs)
                .SingleOrDefaultAsync(t => t.StoreId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
