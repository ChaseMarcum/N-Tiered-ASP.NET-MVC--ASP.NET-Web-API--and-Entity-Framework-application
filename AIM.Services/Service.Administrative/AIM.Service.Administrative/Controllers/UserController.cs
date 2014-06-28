using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TrackableEntities.Common;
using AIM.Service.Entities.Models;
using AIM.Service.Persistence.Exceptions;
using AIM.Service.Persistence.UnitsOfWork;

namespace AIM.Service.Administrative.Controllers
{
    public class UserController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public UserController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/User
        [ResponseType(typeof(IEnumerable<User>))]
        public async Task<IHttpActionResult> GetUsers()
        {
            IEnumerable<User> users = await _unitOfWork.UserRepository.GetUsers();
            return Ok(users);
        }

        // GET api/User/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await _unitOfWork.UserRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // GET api/User/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUserLogin(string userName, string password)
        {
            User user = await _unitOfWork.UserRepository.GetUserLogin(userName, password);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/User
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.UserRepository.Insert(user);

            try
            {
                // Save and accept changes
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.UserRepository.Find(user.UserId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            // Load related entities and accept changes
            await _unitOfWork.UserRepository.LoadRelatedEntitiesAsync(user);
            user.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // PUT api/User
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PutUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.UserRepository.Update(user);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.UserRepository.Find(user.UserId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.UserRepository.LoadRelatedEntitiesAsync(user);
            user.AcceptChanges();
            return Ok(user);
        }

        // DELETE api/User/5
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            bool result = await _unitOfWork.UserRepository.DeleteAsync(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.UserRepository.Find(id) == null)
                {
                    return Conflict();
                }
                throw;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var disposable = _unitOfWork as IDisposable;
                if (disposable != null)
                    disposable.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}