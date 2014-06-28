using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IStoreRepository : IRepository<Store>, IRepositoryAsync<Store>
    {
        Task<IEnumerable<Store>> GetStores();
        Task<IEnumerable<Store>> GetStoresByRegionId(int regionId);
        Task<Store> GetStore(int id);
        Task<bool> DeleteStore(int id);
    }
}
