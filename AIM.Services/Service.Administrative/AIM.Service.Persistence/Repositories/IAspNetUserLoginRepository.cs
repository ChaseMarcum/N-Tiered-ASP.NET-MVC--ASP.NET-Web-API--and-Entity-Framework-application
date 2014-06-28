using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IAspNetUserLoginRepository : IRepository<AspNetUserLogin>, IRepositoryAsync<AspNetUserLogin>
    {
        Task<IEnumerable<AspNetUserLogin>> GetAspNetUserLogins();
        Task<AspNetUserLogin> GetAspNetUserLogin(string id);
        Task<bool> DeleteAspNetUserLogin(string id);
    }
}
