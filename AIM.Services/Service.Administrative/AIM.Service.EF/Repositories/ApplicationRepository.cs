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
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        private readonly IAIM_DBContext _context;

        public ApplicationRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetApplications()
        {
            IEnumerable<Application> entities = await _context.Applications
                .Include(t => t.Applicant)
                .Include(t => t.Job)
                .ToListAsync();
            return entities;
        }

        public async Task<Application> GetApplication(int id)
        {
            Application entity = await _context.Applications
                .Include(t => t.Applicant)
                .Include(t => t.Job)
                .SingleOrDefaultAsync(t => t.ApplicationId == id);
            return entity;
        }

        public async Task<bool> DeleteApplication(int id)
        {
            Application entity = await _context.Applications
                .Include(t => t.Applicant)
                .Include(t => t.Job)
                .SingleOrDefaultAsync(t => t.ApplicationId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
