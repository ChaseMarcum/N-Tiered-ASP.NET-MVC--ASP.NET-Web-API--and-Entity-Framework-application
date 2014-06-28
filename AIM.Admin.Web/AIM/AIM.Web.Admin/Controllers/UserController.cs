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
    public class UserController : Controller
    {
        private readonly UserServiceClient _client = new UserServiceClient();
        private User _user = new User();

        public UserController()
        {
            _client = new UserServiceClient();
        }

        // GET: /User/
        public async Task<ActionResult> Index()
        {
            IEnumerable<User> users = await _client.GetUsers();

            return View(users);
        }

        // GET: /User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = await _client.GetUserById(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,FirstName,MiddleName,LastName,Email,SocialSecurityNumber," +
                                                   "PersonalInfoId,ApplicantId,ApplicationId,EmployeeId,UserName," +
                                                   "Password,AspNetUsersId")] User user)
        {
            if (ModelState.IsValid)
            {
                User updatedUser = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://aimadminstrativeservice.cloudapp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    string request = "api/User";
                    HttpResponseMessage response = await client.PostAsJsonAsync(request, user);
                    if (response.IsSuccessStatusCode)
                    {
                        updatedUser = await response.Content.ReadAsAsync<User>();
                    }
                }

                if (user != null)
                {
                    TempData["Message"] = "User " + user.FirstName + " " + user.LastName +
                                          " was successfully created.";
                }

            return RedirectToAction("Index");
            }

            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

            return View(user);
        }

        // GET: /User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = await _client.GetUserById(id);

            // Start change-tracking the model
            _user = user;

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserId,FirstName,MiddleName,LastName,Email,SocialSecurityNumber," +
                                                   "PersonalInfoId,ApplicantId,ApplicationId,EmployeeId,UserName," +
                                                   "Password,AspNetUsersId")] User user)
        {
            if (ModelState.IsValid)
            {
                User updatedUser = user;

                await _client.DeleteUser(user.UserId);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://aimadminstrativeservice.cloudapp.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    string request = "api/User";
                    HttpResponseMessage response = await client.PostAsJsonAsync(request, user);
                    if (response.IsSuccessStatusCode)
                    {
                        updatedUser = await response.Content.ReadAsAsync<User>();
                    }
                }

                TempData["Message"] = "User " + user.FirstName + " " + user.LastName +
                                          " was successfully updated.";

                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: /User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = await _client.GetUserById(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            // Delete the user
            await _client.DeleteUser(id);

            // Verify order was deleted
            User deletedUser = await _client.GetUserById(id);
            if (deletedUser == null)
            {
                TempData["Message"] = "User was successfully deleted.";
            }
            else
            {
                TempData["Message"] = "User was not deleted.";
            }

            return RedirectToAction("Index");
        }
    }
}
