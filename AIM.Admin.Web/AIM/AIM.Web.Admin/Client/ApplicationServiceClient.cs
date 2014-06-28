using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AIM.Web.Admin.Models.EntityModels;
using WebApiRestService;

namespace AIM.Web.Admin.Client
{
    public class ApplicationServiceClient : WebApiClient<Application>
    {
        private static WebApiClientOptions options = new WebApiClientOptions()
        {
            BaseAddress = "http://aimadminstrativeservice.cloudapp.net/",
            ContentType = WebApiRestService.ContentType.Json,
            Timeout = 80000,
            Controller = "api/Application"
        };

        /// <summary>
        /// Creates an instance of ApplicationClient using default options
        /// </summary>
        public ApplicationServiceClient()
            : this(options)
        {
        }

        /// <summary>
        /// Creates an instance of ApplicationClient using explicit options
        /// </summary>
        private ApplicationServiceClient(WebApiClientOptions options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Models.EntityModels.Application>> GetApplications()
        {
            return await GetManyAsync();
        }

        public async Task<Models.EntityModels.Application> GetApplicationById(int? id)
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

        public async Task<Models.EntityModels.Application> CreateApplication(Models.EntityModels.Application application)
        {
            return await CreateAsync(application);
        }

        public async Task<Models.EntityModels.Application> EditApplication(Models.EntityModels.Application application)
        {
            return await EditAsync(application);
        }

        public async Task DeleteApplication(int id)
        {
            await DeleteAsync(id);
        }
    }
}