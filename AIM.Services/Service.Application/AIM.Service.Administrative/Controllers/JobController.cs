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
    public class JobController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public JobController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/Job
        [ResponseType(typeof(IEnumerable<Job>))]
        public async Task<IHttpActionResult> GetJobs()
        {
            IEnumerable<Job> entities = await _unitOfWork.JobRepository.GetJobs();
            return Ok(entities);
        }

        // GET api/Job/5
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> GetJob(int id)
        {
            Job entity = await _unitOfWork.JobRepository.GetJob(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/Job
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> PostJob(Job entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.JobRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.JobRepository.Find(entity.JobId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.JobRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.JobId }, entity);
        }

        // PUT api/Job
        [ResponseType(typeof(Job))]
        public async Task<IHttpActionResult> PutJob(Job entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.JobRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.JobRepository.Find(entity.JobId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.JobRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/Job/5
        public async Task<IHttpActionResult> DeleteJob(int id)
        {
            bool result = await _unitOfWork.JobRepository.DeleteJob(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.JobRepository.Find(id) == null)
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
