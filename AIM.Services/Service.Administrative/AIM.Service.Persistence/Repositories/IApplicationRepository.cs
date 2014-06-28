using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IApplicationRepository : IRepository<Application>, IRepositoryAsync<Application>
    {
        Task<IEnumerable<Application>> GetApplications();
        Task<Application> GetApplication(int id);
        Task<bool> DeleteApplication(int id);
    }
}
