using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IAspNetRoleRepository : IRepository<AspNetRole>, IRepositoryAsync<AspNetRole>
    {
        Task<IEnumerable<AspNetRole>> GetAspNetRoles();
        Task<AspNetRole> GetAspNetRole(string id);
        Task<bool> DeleteAspNetRole(string id);
    }
}
