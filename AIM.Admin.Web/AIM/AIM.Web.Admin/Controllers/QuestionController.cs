using System.IO;
using System.Text;
using System.Threading.Tasks;
using AIM.Web.Admin.Client;
using AIM.Web.Admin.Models;
using AIM.Web.Admin.Models.EntityModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AIM.Web.Admin.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionServiceClient _client = new QuestionServiceClient();
        private static readonly StringBuilder Sb = new StringBuilder();
        private readonly StringWriter _sw = new StringWriter(Sb);

        // GET: /Question/
        public async Task<ActionResult> Index()
        {
            var questions = await _client.GetQuestions();

            // expand JSON Proterties
            foreach (Question question in questions)
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
            return View(questions);
        }

        // GET: /Question/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = await _client.GetQuestionById(id);

            if (question == null)
            {
                return HttpNotFound();
            }

            // expand JSON Proterties
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

            return View(question);
        }

        // GET: /Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "questionId,qJsonProperties,qJsonId,qJsonType,qJsonText,qJsonOptionList," +
                                                   "qJsonAnswerList,questionnaireId,interviewQuestionsId")] Question question)
        {
            // Create JSON string for JSON Properties
            var jsonQuestion = new JsonQuestion
            {
                QJsonId = question.QJsonId,
                QJsonType = question.QJsonType,
                QJsonText = question.QJsonText,
                QJsonOptionList = new List<string>(question.QJsonOptionList),
                QJsonAnswerList = new List<string>(question.QJsonAnswerList)
            };

            string json = JsonConvert.SerializeObject(jsonQuestion, Formatting.Indented);

            question.QJsonProperties = json;

            if (ModelState.IsValid)
            {
                await _client.CreateQuestion(question);
                return RedirectToAction("Index");
            }

            return View(question);
        }

        // GET: /Question/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = await _client.GetQuestionById(id);
            if (question == null)
            {
                return HttpNotFound();
            }

            // expand JSON Proterties
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

            return View(question);
        }

        // POST: /Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "questionId,qJsonProperties,qJsonId,qJsonType,qJsonText,qJsonOptionList," +
                                                 "qJsonAnswerList,questionnaireId,interviewQuestionsId")] Question question)
        {
            // Create JSON string for JSON Properties
            var jsonQuestion = new JsonQuestion
            {
                QJsonId = question.QJsonId,
                QJsonType = question.QJsonType,
                QJsonText = question.QJsonText,
                QJsonOptionList = new List<string>(question.QJsonOptionList),
                QJsonAnswerList = new List<string>(question.QJsonAnswerList)
            };

            string json = JsonConvert.SerializeObject(jsonQuestion, Formatting.Indented);

            question.QJsonProperties = json;

            if (ModelState.IsValid)
            {
                await _client.EditQuestion(question);
                return RedirectToAction("Index");
            }

            return View(question);
        }

        // GET: /Question/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = await _client.GetQuestionById(id);

            if (question == null)
            {
                return HttpNotFound();
            }

            // expand JSON Proterties
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

            return View(question);
        }

        // POST: /Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToRouteResult> DeleteConfirmed(int id)
        {
            await _client.DeleteQuestion(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            var dispose = _client as IDisposable;
            if (dispose != null)
            {
                dispose.Dispose();
            }
        }
    }
}