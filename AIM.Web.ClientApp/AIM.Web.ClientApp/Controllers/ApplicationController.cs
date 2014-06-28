using System.Collections.Generic;
using AIM.Web.ClientApp.Client;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AIM.Web.ClientApp.Models;
using AIM.Web.ClientApp.Models.EntityModels;

namespace AIM.Web.ClientApp.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationServiceClient _applicationClient = new ApplicationServiceClient();
        private readonly JobServiceClient _jobClient = new JobServiceClient();

        // GET: /Application/
        public ActionResult Index(int jobId = 1)
        {
            var job = new Job()
            {
                JobId = jobId,
                Position = "Sales Associate",
                Description = "Customer Service, Stocking, Cashier",
                FullPartTime = "Part-time",
                SalaryRange = "$8.00 - $10.00 hourly",
                QuestionnaireId = 1,
                HoursId = 1
            };

            var applicant = new Applicant();
            var applicantQuestionAnswer = new ApplicantQuestionAnswer();
            var educations = new List<Education>();
            var jobHistories = new List<JobHistory>();
            var hour = new Hour();
            var references = new List<Reference>();
            var user = new User();
            var personalInfo = new PersonalInfo();

            var viewModel = new ApplicationViewModel()
            {
                Application = new Models.EntityModels.Application()
                {
                    DateCreated = DateTime.Now.Date,
                    JobId = jobId,
                },
                
                Job = job,
                Applicant = applicant,
                ApplicantQuestionAnswer = applicantQuestionAnswer,
                Education = educations,
                JobHistory = jobHistories,
                Hour = hour,
                Reference = references,
                User = user,
                PersonalInfo = personalInfo
            };

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult SaveApplicationDetails(ApplicationViewModel viewModel)
        {
            // TODO: Save logic goes here.

            return Json(new { });
        }

        public ActionResult Call()
        {
            return View();
        }
    }
}