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
    public class ReferenceRepository : Repository<Reference>, IReferenceRepository
    {
        private readonly IAIM_DBContext _context;

        public ReferenceRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reference>> GetReferences()
        {
            IEnumerable<Reference> entities = await _context.References
                .Include(t => t.Applicant)
                .Include(t => t.Applicant.Users)
                .ToListAsync();
            return entities;
        }

        public async Task<Reference> GetReference(int id)
        {
            Reference entity = await _context.References
                .Include(t => t.Applicant)
                .Include(t => t.Applicant.Users)
                .SingleOrDefaultAsync(t => t.ReferenceId == id);
            return entity;
        }

        public async Task<bool> DeleteReference(int id)
        {
            Reference entity = await _context.References
                .SingleOrDefaultAsync(t => t.ReferenceId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
