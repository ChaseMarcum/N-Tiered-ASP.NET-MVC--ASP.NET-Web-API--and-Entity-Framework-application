using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IJobRepository : IRepository<Job>, IRepositoryAsync<Job>
    {
        Task<IEnumerable<Job>> GetJobs();
        Task<Job> GetJob(int id);
        Task<bool> DeleteJob(int id);
    }
}
