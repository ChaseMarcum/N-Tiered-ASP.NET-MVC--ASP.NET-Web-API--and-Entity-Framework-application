using AIM.Web.ClientApp.Models.EntityModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApiRestService;

namespace AIM.Web.ClientApp.Client
{
    public class QuestionServiceClient : WebApiClient<Question>
    {
        private static WebApiClientOptions options = new WebApiClientOptions()
        {
            BaseAddress = "http://aimapplicationservice.cloudapp.net/",
            ContentType = ContentType.Json,
            Timeout = 80000,
            Controller = "api/Question"
        };

        /// <summary>
        /// Creates an instance of QuestionClient using default options
        /// </summary>
        public QuestionServiceClient()
            : this(options)
        {
        }

        /// <summary>
        /// Creates an instance of QuestionClient using explicit options
        /// </summary>
        private QuestionServiceClient(WebApiClientOptions options)
            : base(options)
        {
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await GetManyAsync();
        }

        public async Task<Question> GetQuestionById(int? id)
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

        public async Task<Question> CreateQuestion(Question question)
        {
            return await CreateAsync(question);
        }

        public async Task<Question> EditQuestion(Question question)
        {
            return await EditAsync(question);
        }

        public async Task DeleteQuestion(int id)
        {
            await DeleteAsync(id);
        }
    }
}