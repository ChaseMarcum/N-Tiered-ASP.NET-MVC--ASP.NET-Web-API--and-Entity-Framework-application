using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AIM.Web.Application.Client;
using AIM.Web.ClientApp.Models.EntityModels;
using Newtonsoft.Json;

namespace AIM.Web.ClientApp.Controllers
{
    public class QuestionnaireController : Controller
    {
        // GET: Questionnaire
        public async Task<ViewResult> Index(int questionnaireId = 1)
        {

            IEnumerable<Question> questionnaireQuestions = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aimadminstrativeservice.cloudapp.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                string request = "api/Question?questionnaireId=" + questionnaireId;
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    questionnaireQuestions = await response.Content.ReadAsAsync<IEnumerable<Question>>();
                }
            }

            // expand JSON Proterties
            if (questionnaireQuestions != null)
            {
                foreach (Question question in questionnaireQuestions)
                {
                    question.QJsonOptionList = new List<string>();
                    question.QJsonAnswerList = new List<string>();

                    var expandedQJsonProperties = JsonConvert.DeserializeObject<Question>(question.QJsonProperties);

                    question.QJsonId = expandedQJsonProperties.QJsonId;
                    question.QJsonType = expandedQJsonProperties.QJsonType;
                    question.QJsonText = expandedQJsonProperties.QJsonText;

                    for (var i = 0; i < expandedQJsonProperties.QJsonOptionList.Count(); ++i)
                    {
                        question.QJsonOptionList.Add(expandedQJsonProperties.QJsonOptionList[i]);
                    }

                    for (var i = 0; i < expandedQJsonProperties.QJsonAnswerList.Count(); ++i)
                    {
                        question.QJsonAnswerList.Add(expandedQJsonProperties.QJsonAnswerList[i]);
                    }
                }
            }
            return View(questionnaireQuestions);
        }


        public ActionResult Failed()
        {
            return View();
        }


        public ActionResult Passed()
        {
            return View();
        }

    }
}