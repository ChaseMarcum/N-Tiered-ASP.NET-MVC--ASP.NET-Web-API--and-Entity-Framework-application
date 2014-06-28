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
    public class OpenJobController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public OpenJobController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/OpenJob
        [ResponseType(typeof(IEnumerable<OpenJob>))]
        public async Task<IHttpActionResult> GetOpenJobs()
        {
            IEnumerable<OpenJob> entities = await _unitOfWork.OpenJobRepository.GetOpenJobs();
            return Ok(entities);
        }

        // GET api/OpenJob/5
        [ResponseType(typeof(OpenJob))]
        public async Task<IHttpActionResult> GetOpenJob(int id)
        {
            OpenJob entity = await _unitOfWork.OpenJobRepository.GetOpenJob(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // GET api/OpenJob/5
        [ResponseType(typeof(IEnumerable<OpenJob>))]
        public async Task<IHttpActionResult> GetOpenJobsByStoreId(int storeId)
        {
            IEnumerable<OpenJob> entities = await _unitOfWork.OpenJobRepository.GetOpenJobsByStoreId(storeId);
            return Ok(entities);
        }

        // GET api/OpenJob/5
        [ResponseType(typeof(IEnumerable<OpenJob>))]
        public async Task<IHttpActionResult> GetOpenJobsByRegionId(int regionId)
        {
            IEnumerable<OpenJob> entities = await _unitOfWork.OpenJobRepository.GetOpenJobsByRegionId(regionId);
            return Ok(entities);
        }

        // POST api/OpenJob
        [ResponseType(typeof(OpenJob))]
        public async Task<IHttpActionResult> PostOpenJob(OpenJob entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.OpenJobRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.OpenJobRepository.Find(entity.OpenJobsId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.OpenJobRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.OpenJobsId }, entity);
        }

        // PUT api/OpenJob
        [ResponseType(typeof(OpenJob))]
        public async Task<IHttpActionResult> PutOpenJob(OpenJob entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.OpenJobRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.OpenJobRepository.Find(entity.OpenJobsId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.OpenJobRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/OpenJob/5
        public async Task<IHttpActionResult> DeleteOpenJob(int id)
        {
            bool result = await _unitOfWork.OpenJobRepository.DeleteOpenJob(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.OpenJobRepository.Find(id) == null)
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
