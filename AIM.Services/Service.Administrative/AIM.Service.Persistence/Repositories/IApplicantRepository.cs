using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IApplicantRepository : IRepository<Applicant>, IRepositoryAsync<Applicant>
    {
        Task<IEnumerable<Applicant>> GetApplicants();
        Task<Applicant> GetApplicant(int id);
        Task<bool> DeleteApplicant(int id);
    }
}
