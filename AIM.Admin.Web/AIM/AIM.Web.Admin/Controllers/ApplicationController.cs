using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AIM.Web.Admin.Client;
using AIM.Web.Admin.Models.EntityModels;

namespace AIM.Web.Admin.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationServiceClient _client = new ApplicationServiceClient();

        // GET: /Application/
        public async Task<ActionResult> Index()
        {
            var applications = await _client.GetApplications();

            return View(applications);
        }

        // GET: /Application/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Application application = await _client.GetApplicationById(id);

            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // GET: /Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Application/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "applicantId,educationId,jobHistoryId,referenceId,userId,applicationId,answerId,hoursId")] Application application)
        {
            if (ModelState.IsValid)
            {
                await _client.CreateApplication(application);
                return RedirectToAction("Index");
            }

            return View(application);
        }

        // GET: /Application/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await _client.GetApplicationById(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: /Application/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "applicantId,educationId,jobHistoryId,referenceId,userId,applicationId,answerId,hoursId")] Application application)
        {
            if (ModelState.IsValid)
            {
                await _client.EditApplication(application);
                return RedirectToAction("Index");
            }
            return View(application);
        }

        // GET: /Application/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = await _client.GetApplicationById(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: /Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _client.DeleteApplication(id);
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

