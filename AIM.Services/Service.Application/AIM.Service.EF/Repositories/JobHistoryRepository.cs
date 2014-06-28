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
    public class JobHistoryRepository : Repository<JobHistory>, IJobHistoryRepository
    {
        private readonly IAIM_DBContext _context;

        public JobHistoryRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobHistory>> GetJobHistories()
        {
            IEnumerable<JobHistory> entities = await _context.JobHistories
                .Include(t => t.Applicant)
                .ToListAsync();
            return entities;
        }

        public async Task<JobHistory> GetJobHistory(int id)
        {
            JobHistory entity = await _context.JobHistories
                .Include(t => t.Applicant)
                .SingleOrDefaultAsync(t => t.JobHistoryId == id);
            return entity;
        }

        public async Task<bool> DeleteJobHistory(int id)
        {
            JobHistory entity = await _context.JobHistories
                .Include(t => t.Applicant)
                 .SingleOrDefaultAsync(t => t.JobHistoryId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
