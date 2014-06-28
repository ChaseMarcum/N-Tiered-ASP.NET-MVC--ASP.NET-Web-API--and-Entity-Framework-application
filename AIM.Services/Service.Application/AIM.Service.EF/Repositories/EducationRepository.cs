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
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        private readonly IAIM_DBContext _context;

        public EducationRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Education>> GetEducations()
        {
            IEnumerable<Education> entities = await _context.Educations
                .Include(t => t.Applicant)
                .ToListAsync();
            return entities;
        }

        public async Task<Education> GetEducation(int id)
        {
            Education entity = await _context.Educations
                .Include(t => t.Applicant)
                .SingleOrDefaultAsync(t => t.EducationId == id);
            return entity;
        }

        public async Task<bool> DeleteEducation(int id)
        {
            Education entity = await _context.Educations
                .Include(t => t.Applicant)
                .SingleOrDefaultAsync(t => t.EducationId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
