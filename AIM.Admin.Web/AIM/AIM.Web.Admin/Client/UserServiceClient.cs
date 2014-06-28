using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AIM.Web.Admin.Models.EntityModels;
using WebApiRestService;

namespace AIM.Web.Admin.Client
{
    public class UserServiceClient : WebApiClient<User>
    {
        private static WebApiClientOptions options = new WebApiClientOptions()
        {
            BaseAddress = "http://aimapplicationservice.cloudapp.net/",
            ContentType = ContentType.Json,
            Timeout = 80000,
            Controller = "api/User"
        };

        /// <summary>
        /// Creates an instance of UserClient using default options
        /// </summary>
        public UserServiceClient()
            : this(options)
        {
        }

        /// <summary>
        /// Creates an instance of UserClient using explicit options
        /// </summary>
        private UserServiceClient(WebApiClientOptions options)
            : base(options)
        {
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await GetManyAsync();
        }

        public async Task<User> GetUserById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            try
            {
                return await GetOneAsync(id);
            }
            catch (WebApiClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw e;
            }
        }

        public async Task<User> GetUserLogin(string userName, string password)
        {
            if (userName == null || password == null)
            {
                return null;
            }
            try
            {
                return await GetOneAsync(new { UserName = userName, Password = password }, "GetUserLogin");
            }
            catch (WebApiClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw e;
            }
        }

        public async Task<User> CreateUser(User user)
        {
            return await CreateAsync(user);
        }

        public async Task<User> EditUser(User user)
        {
            return await EditAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            await DeleteAsync(id);
        }
    }
}