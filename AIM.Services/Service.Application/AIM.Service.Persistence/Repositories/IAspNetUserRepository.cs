using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IAspNetUserRepository : IRepository<AspNetUser>, IRepositoryAsync<AspNetUser>
    {
        Task<IEnumerable<AspNetUser>> GetAspNetUsers();
        Task<AspNetUser> GetAspNetUser(string id);
        Task<bool> DeleteAspNetUser(string id);
    }
}
