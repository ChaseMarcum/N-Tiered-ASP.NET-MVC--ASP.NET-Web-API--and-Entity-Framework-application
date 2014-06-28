using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

using AIM.Web.ClientApp.Client;
using AIM.Web.ClientApp.Models.EntityModels;


namespace AIM.Web.ClientApp.Controllers
{
    public class PersonalInfoController : Controller
    {
        private readonly PersonalInfoServiceClient _client = new PersonalInfoServiceClient();

        // GET: /PersonalInfo/
        public async Task<ActionResult> Index()
        {
            var personalInfo = await _client.GetPersonalInfos();

            return View(personalInfo);
        }

        // GET: /PersonalInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalinfo = await _client.GetPersonalInfoById(id);
            if (personalinfo == null)
            {
                return HttpNotFound();
            }

            return View(personalinfo);
        }

        // GET: /PersonalInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PersonalInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PersonalInfoId,alias,street,street2,city,state,zip,phone,userId")] PersonalInfo personalinfo)
        {
            setDefaultValues(ref personalinfo);

            if (ModelState.IsValid)
            {
                await _client.CreatePersonalInfo(personalinfo);
                return RedirectToAction("Index");
            }

            return View(personalinfo);
        }

        private void setDefaultValues(ref PersonalInfo personalinfo)
        {
            // Dash was used because space gets treated as
            // an empty field by the either the view or the controller
            // which messes up the details display

            if (personalinfo.Alias == null)
                personalinfo.Alias = "-";

            if (personalinfo.Street == null)
                personalinfo.Street = "-";

            if (personalinfo.Street2 == null)
                personalinfo.Street2 = "-";

            if (personalinfo.City == null)
                personalinfo.City = "-";

            // State is required when creating PersonalInfo

            if (personalinfo.Zip == null)
                personalinfo.Zip = "-";

            if (personalinfo.Phone == null)
                personalinfo.Phone = "-";

            if (personalinfo.UserId == null)
                personalinfo.UserId = -1;
        }

        // GET: /PersonalInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonalInfo personalinfo = await _client.GetPersonalInfoById(id);

            if (personalinfo == null)
            {
                return HttpNotFound();
            }
            return View(personalinfo);
        }

        // POST: /PersonalInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PersonalInfoId,alias,street,street2,city,state,zip,phone,userId")] PersonalInfo personalinfo)
        {
            if (ModelState.IsValid)
            {
                await _client.DeletePersonalInfo(personalinfo.PersonalInfoId);
                await _client.CreatePersonalInfo(personalinfo);

                return RedirectToAction("Index");
            }
            return View(personalinfo);
        }

        // GET: /PersonalInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PersonalInfo personalinfo = await _client.GetPersonalInfoById(id);

            if (personalinfo == null)
            {
                return HttpNotFound();
            }
            return View(personalinfo);
        }

        // POST: /PersonalInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _client.DeletePersonalInfo(id);
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
