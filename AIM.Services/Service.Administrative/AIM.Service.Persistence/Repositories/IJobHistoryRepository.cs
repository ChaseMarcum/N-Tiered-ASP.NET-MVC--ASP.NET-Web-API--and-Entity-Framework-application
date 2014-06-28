using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IJobHistoryRepository : IRepository<JobHistory>, IRepositoryAsync<JobHistory>
    {
        Task<IEnumerable<JobHistory>> GetJobHistories();
        Task<JobHistory> GetJobHistory(int id);
        Task<bool> DeleteJobHistory(int id);
    }
}
