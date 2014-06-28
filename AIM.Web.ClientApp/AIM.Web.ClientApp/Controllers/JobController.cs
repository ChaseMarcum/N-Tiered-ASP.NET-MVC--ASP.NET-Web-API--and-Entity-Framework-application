using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AIM.Web.ClientApp.Client;
using AIM.Web.ClientApp.Models.EntityModels;


namespace AIM.Web.ClientApp.Controllers
{
    public class JobController : Controller
    {
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
                using (var client = new JobServiceClient())
                {
                    await client.CreateJob(job);               
                }

                return RedirectToAction("Details", job.JobId);
            }

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
                    await client.EditJob(job);
                }

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
            }

            return RedirectToAction("Index");
        }
    }
}