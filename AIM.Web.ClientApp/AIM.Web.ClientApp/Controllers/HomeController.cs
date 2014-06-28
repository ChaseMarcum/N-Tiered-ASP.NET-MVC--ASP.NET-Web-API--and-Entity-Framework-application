using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using AIM.Web.Application.Client;
using System.Web.Mvc;
using AIM.Web.ClientApp.Models.EntityModels;

namespace AIM.Web.ClientApp.Controllers
{
    public class HomeController : Controller
    {

        public async Task<ActionResult> Index()
        {
            IEnumerable<Region> regions = null;

            using (var regionClient = new RegionServiceClient())
            {
                regions = await regionClient.GetRegions();
            }

            return View(regions);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}