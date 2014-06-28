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
    public class JobRepository : Repository<Job>, IJobRepository
    {
        private readonly IAIM_DBContext _context;

        public JobRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            IEnumerable<Job> entities = await _context.Jobs
                .Include(t => t.OpenJobs)
                .Include(t => t.Questionnaire)
                .Include(t => t.Hour)
                .Include(t => t.InterviewQuestion)
                .Include(t => t.Employees)
                .Include(t => t.Applications)
                .ToListAsync();
            return entities;
        }

        public async Task<Job> GetJob(int id)
        {
            Job entity = await _context.Jobs
                .Include(t => t.OpenJobs)
                .Include(t => t.Questionnaire)
                .Include(t => t.Hour)
                .Include(t => t.InterviewQuestion)
                .Include(t => t.Employees)
                .Include(t => t.Applications)
                .SingleOrDefaultAsync(t => t.JobId == id);
            return entity;
        }

        public async Task<bool> DeleteJob(int id)
        {
            Job entity = await _context.Jobs
                .Include(t => t.OpenJobs)
                .Include(t => t.Questionnaire)
                .Include(t => t.Hour)
                .Include(t => t.InterviewQuestion)
                .SingleOrDefaultAsync(t => t.JobId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
