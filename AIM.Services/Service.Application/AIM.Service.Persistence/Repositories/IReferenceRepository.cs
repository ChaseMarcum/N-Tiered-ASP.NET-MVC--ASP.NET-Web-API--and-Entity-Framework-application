using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IReferenceRepository : IRepository<Reference>, IRepositoryAsync<Reference>
    {
        Task<IEnumerable<Reference>> GetReferences();
        Task<Reference> GetReference(int id);
        Task<bool> DeleteReference(int id);
    }
}
