using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AIM.Web.Admin.Models.EntityModels;
using WebApiRestService;

namespace AIM.Web.Admin.Client
{
    public class StoreServiceClient : WebApiClient<Store>
    {
        private static WebApiClientOptions options = new WebApiClientOptions()
        {
            BaseAddress = "http://aimadminstrativeservice.cloudapp.net/",
            ContentType = ContentType.Json,
            Timeout = 80000,
            Controller = "api/Store"
        };

        /// <summary>
        /// Creates an instance of StoreClient using default options
        /// </summary>
        public StoreServiceClient()
            : this(options)
        {
        }

        /// <summary>
        /// Creates an instance of StoreClient using explicit options
        /// </summary>
        private StoreServiceClient(WebApiClientOptions options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await GetManyAsync();
        }

        public async Task<Store> GetStoreById(int? id)
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

        public async Task<IEnumerable<Store>> GetStoresByRegionId(int? regionId)
        {
            if (regionId == null)
            {
                return null;
            }
            try
            {
                return await GetManyAsync(regionId, "GetStoresByRegionId");
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

        public async Task<Store> CreateStore(Store store)
        {
            return await CreateAsync(store);
        }

        public async Task<Store> EditStore(Store store)
        {
            return await EditAsync(store);
        }

        public async Task DeleteStore(int id)
        {
            await DeleteAsync(id);
        }
    }
}