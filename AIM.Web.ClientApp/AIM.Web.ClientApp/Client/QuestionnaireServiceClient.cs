using AIM.Web.ClientApp.Models.EntityModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApiRestService;

namespace AIM.Web.Application.Client
{
    public class QuestionnaireServiceClient : WebApiClient<Questionnaire>
    {
        private static WebApiClientOptions options = new WebApiClientOptions()
        {
            BaseAddress = "http://aimapplicationservice.cloudapp.net/",
            ContentType = ContentType.Json,
            Timeout = 80000,
            Controller = "api/Questionnaire"
        };

        /// <summary>
        /// Creates an instance of QuestionnaireClient using default options
        /// </summary>
        public QuestionnaireServiceClient()
            : this(options)
        {
        }

        /// <summary>
        /// Creates an instance of QuestionnaireClient using explicit options
        /// </summary>
        private QuestionnaireServiceClient(WebApiClientOptions options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Questionnaire>> GetQuestionnaires()
        {
            return await GetManyAsync();
        }

        public async Task<Questionnaire> GetQuestionnaireById(int? id)
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

        public async Task<Questionnaire> GetQuestionnaireByJobId(int? jobId)
        {
            if (jobId == null)
            {
                return null;
            }
            try
            {
                return await GetOneAsync(jobId, "GetQuestionnaireByJobId");
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

        public async Task<Questionnaire> CreateQuestionnaire(Questionnaire questionnaire)
        {
            return await CreateAsync(questionnaire);
        }

        public async Task<Questionnaire> EditQuestionnaire(Questionnaire questionnaire)
        {
            return await EditAsync(questionnaire);
        }

        public async Task DeleteQuestionnaire(int id)
        {
            await DeleteAsync(id);
        }
    }
}