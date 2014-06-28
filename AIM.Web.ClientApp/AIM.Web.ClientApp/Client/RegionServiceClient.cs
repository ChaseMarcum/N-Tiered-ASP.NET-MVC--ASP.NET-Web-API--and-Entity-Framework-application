using AIM.Web.ClientApp.Models.EntityModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApiRestService;

namespace AIM.Web.Application.Client
{
    public class RegionServiceClient : WebApiClient<Region>
    {
        private static WebApiClientOptions options = new WebApiClientOptions()
        {
            BaseAddress = "http://aimapplicationservice.cloudapp.net/",
            ContentType = ContentType.Json,
            Timeout = 80000,
            Controller = "api/Region"
        };

        /// <summary>
        /// Creates an instance of RegionClient using default options
        /// </summary>
        public RegionServiceClient()
            : this(options)
        {
        }

        /// <summary>
        /// Creates an instance of RegionClient using explicit options
        /// </summary>
        private RegionServiceClient(WebApiClientOptions options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Region>> GetRegions()
        {
            return await GetManyAsync();
        }

        public async Task<Region> GetRegionById(int? id)
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

        public async Task<Region> CreateRegion(Region region)
        {
            return await CreateAsync(region);
        }

        public async Task<Region> EditRegion(Region region)
        {
            return await EditAsync(region);
        }

        public async Task DeleteRegion(int id)
        {
            await DeleteAsync(id);
        }
    }
}