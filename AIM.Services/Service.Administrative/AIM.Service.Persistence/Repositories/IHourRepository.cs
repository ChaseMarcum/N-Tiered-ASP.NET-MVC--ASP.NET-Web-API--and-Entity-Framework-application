using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IHourRepository : IRepository<Hour>, IRepositoryAsync<Hour>
    {
        Task<IEnumerable<Hour>> GetHours();
        Task<Hour> GetHour(int id);
        Task<bool> DeleteHour(int id);
    }
}
