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
    public class AspNetUserClaimRepository : Repository<AspNetUserClaim>, IAspNetUserClaimRepository
    {
        private readonly IAIM_DBContext _context;

        public AspNetUserClaimRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<AspNetUserClaim>> GetAspNetUserClaims()
        {
            IEnumerable<AspNetUserClaim> entities = await _context.AspNetUserClaims
                .Include(t => t.AspNetUser)
                .ToListAsync();
            return entities;
        }

        public async Task<AspNetUserClaim> GetAspNetUserClaim(int id)
        {
            AspNetUserClaim entity = await _context.AspNetUserClaims
                .Include(t => t.AspNetUser)
                .SingleOrDefaultAsync(t => t.Id == id);
            return entity;
        }

        public async Task<bool> DeleteAspNetUserClaim(int id)
        {
            AspNetUserClaim entity = await _context.AspNetUserClaims
                .Include(t => t.AspNetUser)
                .SingleOrDefaultAsync(t => t.Id == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
