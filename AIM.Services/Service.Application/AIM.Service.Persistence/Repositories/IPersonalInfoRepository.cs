using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IPersonalInfoRepository : IRepository<PersonalInfo>, IRepositoryAsync<PersonalInfo>
    {
        Task<IEnumerable<PersonalInfo>> GetPersonalInfoes();
        Task<PersonalInfo> GetPersonalInfo(int id);
        Task<bool> DeletePersonalInfo(int id);
    }
}
