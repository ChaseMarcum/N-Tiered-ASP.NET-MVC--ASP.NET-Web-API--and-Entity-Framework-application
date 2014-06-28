using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AIM.Web.Admin.Models.EntityModels;
using WebApiRestService;

namespace AIM.Web.Admin.Client
{
    public class JobServiceClient : WebApiClient<Job> 
    {
        private static WebApiClientOptions options = new WebApiClientOptions()
        {
            BaseAddress = "http://aimadminstrativeservice.cloudapp.net/",
            ContentType = ContentType.Json,
            Timeout = 80000,
            Controller = "api/Job"
        };

        /// <summary>
        /// Creates an instance of JobClient using default options
        /// </summary>
        public JobServiceClient()
            : this(options)
        {
        }

        /// <summary>
        /// Creates an instance of JobClient using explicit options
        /// </summary>
        private JobServiceClient(WebApiClientOptions options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await GetManyAsync();
        }

        public async Task<Job> GetJobById(int? id)
        {
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

        public async Task<Job> CreateJob(Job job)
        {
            return await CreateAsync(job);
        }

        public async Task<Job> EditJob(Job job)
        {
            return await EditAsync(job);
        }

        public async Task DeleteJob(int id)
        {
            await DeleteAsync(id);
        }
    }
}