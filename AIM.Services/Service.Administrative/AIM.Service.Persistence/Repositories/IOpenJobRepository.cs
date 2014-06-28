using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IOpenJobRepository : IRepository<OpenJob>, IRepositoryAsync<OpenJob>
    {
        Task<IEnumerable<OpenJob>> GetOpenJobs();
        Task<IEnumerable<OpenJob>> GetOpenJobsByStoreId(int storeId);
        Task<IEnumerable<OpenJob>> GetOpenJobsByRegionId(int regionId);
        Task<OpenJob> GetOpenJob(int id);
        Task<bool> DeleteOpenJob(int id);
    }
}
