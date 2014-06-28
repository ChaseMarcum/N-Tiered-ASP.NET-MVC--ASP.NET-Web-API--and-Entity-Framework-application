using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AIM.Web.Admin.Models.EntityModels;
using WebApiRestService;

namespace AIM.Web.Admin.Client
{
    public class OpenJobServiceClient : WebApiClient<OpenJob>
    {
        private static WebApiClientOptions options = new WebApiClientOptions()
        {
            BaseAddress = "http://aimadminstrativeservice.cloudapp.net/",
            ContentType = ContentType.Json,
            Timeout = 80000,
            Controller = "api/OpenJob"
        };

        /// <summary>
        /// Creates an instance of OpenJobClient using default options
        /// </summary>
        public OpenJobServiceClient()
            : this(options)
        {
        }

        /// <summary>
        /// Creates an instance of OpenJobClient using explicit options
        /// </summary>
        private OpenJobServiceClient(WebApiClientOptions options)
            : base(options)
        {
        }

        public async Task<IEnumerable<OpenJob>> GetOpenJobs()
        {
            return await GetManyAsync();
        }

        public async Task<OpenJob> GetOpenJobById(int? id)
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

        public async Task<IEnumerable<OpenJob>> GetOpenJobsByStoreId(int? storeId)
        {
            if (storeId == null)
            {
                return null;
            }
            try
            {
                return await GetManyAsync(storeId, "GetOpenJobsByStoreId");
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

        public async Task<IEnumerable<OpenJob>> GetOpenJobsByRegionId(int? regionId)
        {
            if (regionId == null)
            {
                return null;
            }
            try
            {
                return await GetManyAsync(regionId, "GetOpenJobsByRegionId");
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

        public async Task<OpenJob> CreateOpenJob(OpenJob openJob)
        {
            return await CreateAsync(openJob);
        }

        public async Task<OpenJob> EditOpenJob(OpenJob openJob)
        {
            return await EditAsync(openJob);
        }

        public async Task DeleteOpenJob(int id)
        {
            await DeleteAsync(id);
        }
    }
}