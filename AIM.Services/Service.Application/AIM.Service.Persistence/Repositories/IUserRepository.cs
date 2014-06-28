using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IUserRepository : IRepository<User>, IRepositoryAsync<User>
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> GetUserLogin(string userName, string password);
        Task<bool> DeleteUser(int id);
    }
}
