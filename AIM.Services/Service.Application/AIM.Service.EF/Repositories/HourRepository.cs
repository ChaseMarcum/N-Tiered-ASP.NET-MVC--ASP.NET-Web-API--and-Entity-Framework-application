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
    public class HourRepository : Repository<Hour>, IHourRepository
    {
        private readonly IAIM_DBContext _context;

        public HourRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hour>> GetHours()
        {
            IEnumerable<Hour> entities = await _context.Hours
                .Include(t => t.Jobs)
                .Include(t => t.Applicant)
                .ToListAsync();
            return entities;
        }

        public async Task<Hour> GetHour(int id)
        {
            Hour entity = await _context.Hours
                .Include(t => t.Jobs)
                .Include(t => t.Applicant)
                .SingleOrDefaultAsync(t => t.HoursId == id);
            return entity;
        }

        public async Task<bool> DeleteHour(int id)
        {
            Hour entity = await _context.Hours
                .Include(t => t.Jobs)
                .Include(t => t.Applicant)
                .SingleOrDefaultAsync(t => t.HoursId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
