using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IAspNetUserClaimRepository : IRepository<AspNetUserClaim>, IRepositoryAsync<AspNetUserClaim>
    {
        Task<IEnumerable<AspNetUserClaim>> GetAspNetUserClaims();
        Task<AspNetUserClaim> GetAspNetUserClaim(int id);
        Task<bool> DeleteAspNetUserClaim(int id);
    }
}
