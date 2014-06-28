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
    public class OpenJobRepository : Repository<OpenJob>, IOpenJobRepository
    {
        private readonly IAIM_DBContext _context;

        public OpenJobRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpenJob>> GetOpenJobs()
        {
            IEnumerable<OpenJob> entities = await _context.OpenJobs
                .Include(t => t.Job)
                .Include(t => t.Store)
                .Include(t => t.Region)
                .ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<OpenJob>> GetOpenJobsByStoreId(int storeId)
        {
            IEnumerable<OpenJob> entities = await _context.OpenJobs
                .Where(t => t.StoreId == storeId)
                .Include(t => t.Job)
                .Include(t => t.Store)
                .Include(t => t.Region)
                .ToListAsync();
            return entities;
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

        public async Task<OpenJob> GetOpenJob(int id)
        {
            OpenJob entity = await _context.OpenJobs
                .Include(t => t.Job)
                .Include(t => t.Store)
                .Include(t => t.Region)
                .SingleOrDefaultAsync(t => t.OpenJobsId == id);
            return entity;
        }

        public async Task<bool> DeleteOpenJob(int id)
        {
            OpenJob entity = await _context.OpenJobs
                .Include(t => t.Job)
                .Include(t => t.Store)
                .Include(t => t.Region)
                .SingleOrDefaultAsync(t => t.OpenJobsId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
