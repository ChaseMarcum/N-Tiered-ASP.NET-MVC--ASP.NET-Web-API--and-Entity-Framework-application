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
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        private readonly IAIM_DBContext _context;

        public RegionRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Region>> GetRegions()
        {
            IEnumerable<Region> entities = await _context.Regions
                .Include(t => t.OpenJobs)
                .Include(t => t.Stores)
                .ToListAsync();
            return entities;
        }

        public async Task<Region> GetRegion(int id)
        {
            Region entity = await _context.Regions
                .Include(t => t.OpenJobs)
                .Include(t => t.Stores)
                .SingleOrDefaultAsync(t => t.RegionId == id);
            return entity;
        }

        public async Task<bool> DeleteRegion(int id)
        {
            Region entity = await _context.Regions
                .SingleOrDefaultAsync(t => t.RegionId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
