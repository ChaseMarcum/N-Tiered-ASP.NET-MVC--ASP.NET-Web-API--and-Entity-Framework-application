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
    public class ApplicationController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public ApplicationController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/Application
        [ResponseType(typeof(IEnumerable<Application>))]
        public async Task<IHttpActionResult> GetApplications()
        {
            IEnumerable<Application> entities = await _unitOfWork.ApplicationRepository.GetApplications();
            return Ok(entities);
        }

        // GET api/Application/5
        [ResponseType(typeof(Application))]
        public async Task<IHttpActionResult> GetApplication(int id)
        {
            Application entity = await _unitOfWork.ApplicationRepository.GetApplication(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/Application
        [ResponseType(typeof(Application))]
        public async Task<IHttpActionResult> PostApplication(Application entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.ApplicationRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.ApplicationRepository.Find(entity.ApplicationId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.ApplicationRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.ApplicationId }, entity);
        }

        // PUT api/Application
        [ResponseType(typeof(Application))]
        public async Task<IHttpActionResult> PutApplication(Application entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.ApplicationRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.ApplicationRepository.Find(entity.ApplicationId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.ApplicationRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/Application/5
        public async Task<IHttpActionResult> DeleteApplication(int id)
        {
            bool result = await _unitOfWork.ApplicationRepository.DeleteApplication(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.ApplicationRepository.Find(id) == null)
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
