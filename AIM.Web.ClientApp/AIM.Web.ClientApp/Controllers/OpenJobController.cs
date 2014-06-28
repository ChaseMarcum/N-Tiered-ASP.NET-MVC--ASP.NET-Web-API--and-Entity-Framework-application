using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AIM.Web.Application.Client;
using AIM.Web.ClientApp.Client;
using AIM.Web.ClientApp.Models.EntityModels;

namespace AIM.Web.ClientApp.Controllers
{
    public class OpenJobController : Controller
    {
        private readonly JobServiceClient _jobClient = new JobServiceClient();
        private readonly OpenJobServiceClient _openJobClient = new OpenJobServiceClient();
        private readonly RegionServiceClient _regionClient = new RegionServiceClient();

        // GET: /OpenJob/
        public async Task<ViewResult> Index(string RegionId)
        {

            IEnumerable<OpenJob> openJobs = null;

            int regionId = Convert.ToInt32(RegionId);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://aimadminstrativeservice.cloudapp.net/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                string request = "api/OpenJob?regionId=" + regionId;
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    openJobs = await response.Content.ReadAsAsync<IEnumerable<OpenJob>>();
                }
            }

            var region = await _regionClient.GetRegionById(regionId);
            ViewBag.RegionName = region.RegionName;

            return View(openJobs);
        }

        // GET: /OpenJob/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenJob openjob = await _openJobClient.GetOpenJobById(id);
            if (openjob == null)
            {
                return HttpNotFound();
            }

            ViewBag.Position = openjob.Job.Position;
            return View(openjob);
        }

     
    }
}
