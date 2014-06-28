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
    public class AspNetRoleRepository : Repository<AspNetRole>, IAspNetRoleRepository
    {
        private readonly IAIM_DBContext _context;

        public AspNetRoleRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<AspNetRole>> GetAspNetRoles()
        {
            IEnumerable<AspNetRole> entities = await _context.AspNetRoles
                .Include(t => t.AspNetUsers)
                .ToListAsync();
            return entities;
        }

        public async Task<AspNetRole> GetAspNetRole(string id)
        {
            AspNetRole entity = await _context.AspNetRoles
                .Include(t => t.AspNetUsers)
                .SingleOrDefaultAsync(t => t.Id == id);
            return entity;
        }

        public async Task<bool> DeleteAspNetRole(string id)
        {
            AspNetRole entity = await _context.AspNetRoles
                .Include(t => t.AspNetUsers)
                .SingleOrDefaultAsync(t => t.Id == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
