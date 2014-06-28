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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly IAIM_DBContext _context;

        public EmployeeRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            IEnumerable<Employee> entities = await _context.Employees
                .Include(t => t.Users)
                .Include(t => t.Job)
                .ToListAsync();
            return entities;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee entity = await _context.Employees
                .Include(t => t.Users)
                .Include(t => t.Job)
                .SingleOrDefaultAsync(t => t.EmployeeId == id);
            return entity;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            Employee entity = await _context.Employees
                .Include(t => t.Users)
                .SingleOrDefaultAsync(t => t.EmployeeId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
