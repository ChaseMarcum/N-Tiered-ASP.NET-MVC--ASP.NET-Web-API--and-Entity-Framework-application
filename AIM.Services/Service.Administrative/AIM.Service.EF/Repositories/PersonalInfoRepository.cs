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
    public class PersonalInfoRepository : Repository<PersonalInfo>, IPersonalInfoRepository
    {
        private readonly IAIM_DBContext _context;

        public PersonalInfoRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonalInfo>> GetPersonalInfoes()
        {
            IEnumerable<PersonalInfo> entities = await _context.PersonalInfoes
                .Include(t => t.Users)
                .ToListAsync();
            return entities;
        }

        public async Task<PersonalInfo> GetPersonalInfo(int id)
        {
            PersonalInfo entity = await _context.PersonalInfoes
                .Include(t => t.Users)
                .SingleOrDefaultAsync(t => t.PersonalInfoId == id);
            return entity;
        }

        public async Task<bool> DeletePersonalInfo(int id)
        {
            PersonalInfo entity = await _context.PersonalInfoes
                .Include(t => t.Users)
                .SingleOrDefaultAsync(t => t.PersonalInfoId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
