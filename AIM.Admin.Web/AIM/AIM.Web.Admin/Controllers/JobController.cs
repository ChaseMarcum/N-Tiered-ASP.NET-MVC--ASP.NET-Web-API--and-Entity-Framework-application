using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using AIM.Web.Admin.Client;
using AIM.Web.Admin.Models.EntityModels;

namespace AIM.Web.Admin.Controllers
{
    public class JobController : Controller
    {
        private readonly JobServiceClient _client = new JobServiceClient();

        public JobController()
        {
            _client = new JobServiceClient();
        }


        // GET: /Job/
        public async Task<ViewResult> Index()
        {
            IEnumerable<Job> jobs = null;

            using (var client = new JobServiceClient())
            {
                jobs = await client.GetJobs();
            }

            return View(jobs);
        }

        // GET: /Job/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            Job job = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var client = new JobServiceClient())
            {
                job = await client.GetJobById(id);
            }

            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        // GET: /Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Position,Description,FullPartTime,SalaryRange")] Job job)
        {

            if (ModelState.IsValid)
            {
                Job updatedJob = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://aimadminstrativeservice.cloudapp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    string request = "api/Job";
                    HttpResponseMessage response = await client.PostAsJsonAsync(request, job);
                    if (response.IsSuccessStatusCode)
                    {
                        updatedJob = await response.Content.ReadAsAsync<Job>();
                    }
                }

                if (job != null)
                {
                    TempData["Message"] = "Job " + job.Position + " was successfully created.";
                }

                return RedirectToAction("Index");
            }

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

            return View(job);
        }

        // GET: /Job/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            Job job = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var client = new JobServiceClient())
            {
                job = await client.GetJobById(id);
            }

            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        // POST: /Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Position,Description,FullPartTime,SalaryRange")] Job job)
        {
            if (ModelState.IsValid)
            {
                using (var client = new JobServiceClient())
                {
                    await client.DeleteJob(job.JobId);
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://aimadminstrativeservice.cloudapp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    string request = "api/Job";
                    HttpResponseMessage response = await client.PostAsJsonAsync(request, job);
                    if (response.IsSuccessStatusCode)
                    {
                        await response.Content.ReadAsAsync<Job>();
                    }
                }

                TempData["Message"] = "Job " + job.Position + " was successfully updated.";

                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: /Job/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            Job job = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var client = new JobServiceClient())
            {
                job = await client.GetJobById(id);
            }

            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: /Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var client = new JobServiceClient())
            {
                await client.DeleteJob(id);

                Job deletedJob = await _client.GetJobById(id);
                if (deletedJob == null)
                {
                    TempData["Message"] = "Job was successfully deleted.";
                }
                else
                {
                    TempData["Message"] = "Job was not deleted.";
                }
            }

            return RedirectToAction("Index");
        }
    }
}
