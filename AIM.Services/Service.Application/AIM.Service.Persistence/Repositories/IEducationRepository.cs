using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IEducationRepository : IRepository<Education>, IRepositoryAsync<Education>
    {
        Task<IEnumerable<Education>> GetEducations();
        Task<Education> GetEducation(int id);
        Task<bool> DeleteEducation(int id);
    }
}
