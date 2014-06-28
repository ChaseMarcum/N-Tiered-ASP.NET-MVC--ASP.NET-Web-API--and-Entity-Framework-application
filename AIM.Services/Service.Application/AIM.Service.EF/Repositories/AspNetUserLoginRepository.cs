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
    public class AspNetUserLoginRepository : Repository<AspNetUserLogin>, IAspNetUserLoginRepository
    {
        private readonly IAIM_DBContext _context;

        public AspNetUserLoginRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<AspNetUserLogin>> GetAspNetUserLogins()
        {
            IEnumerable<AspNetUserLogin> entities = await _context.AspNetUserLogins
                .Include(t => t.AspNetUser)
                .ToListAsync();
            return entities;
        }

        public async Task<AspNetUserLogin> GetAspNetUserLogin(string id)
        {
            AspNetUserLogin entity = await _context.AspNetUserLogins
                .Include(t => t.AspNetUser)
                .SingleOrDefaultAsync(t => t.UserId == id);
            return entity;
        }

        public async Task<bool> DeleteAspNetUserLogin(string id)
        {
            AspNetUserLogin entity = await _context.AspNetUserLogins
                .Include(t => t.AspNetUser)
                .SingleOrDefaultAsync(t => t.UserId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
