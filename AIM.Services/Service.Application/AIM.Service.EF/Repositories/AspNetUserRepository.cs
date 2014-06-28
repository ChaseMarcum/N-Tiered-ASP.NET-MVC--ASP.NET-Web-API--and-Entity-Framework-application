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
    public class AspNetUserRepository : Repository<AspNetUser>, IAspNetUserRepository
    {
        private readonly IAIM_DBContext _context;

        public AspNetUserRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<AspNetUser>> GetAspNetUsers()
        {
            IEnumerable<AspNetUser> entities = await _context.AspNetUsers
                .Include(t => t.AspNetUserClaims)
                .Include(t => t.AspNetUserLogins)
                .Include(t => t.AspNetRoles)
                .Include(t => t.Users)
                .ToListAsync();
            return entities;
        }

        public async Task<AspNetUser> GetAspNetUser(string id)
        {
            AspNetUser entity = await _context.AspNetUsers
                .Include(t => t.AspNetUserClaims)
                .Include(t => t.AspNetUserLogins)
                .Include(t => t.AspNetRoles)
                .Include(t => t.Users)
                .SingleOrDefaultAsync(t => t.Id == id);
            return entity;
        }

        public async Task<bool> DeleteAspNetUser(string id)
        {
            AspNetUser entity = await _context.AspNetUsers
                 .SingleOrDefaultAsync(t => t.Id == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
