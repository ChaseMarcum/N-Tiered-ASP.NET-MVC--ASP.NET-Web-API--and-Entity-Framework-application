using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IRegionRepository : IRepository<Region>, IRepositoryAsync<Region>
    {
        Task<IEnumerable<Region>> GetRegions();
        Task<Region> GetRegion(int id);
        Task<bool> DeleteRegion(int id);
    }
}
