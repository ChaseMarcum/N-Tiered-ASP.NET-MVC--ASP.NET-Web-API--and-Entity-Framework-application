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
    public class RegionController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public RegionController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/Region
        [ResponseType(typeof(IEnumerable<Region>))]
        public async Task<IHttpActionResult> GetRegions()
        {
            IEnumerable<Region> entities = await _unitOfWork.RegionRepository.GetRegions();
            return Ok(entities);
        }

        // GET api/Region/5
        [ResponseType(typeof(Region))]
        public async Task<IHttpActionResult> GetRegion(int id)
        {
            Region entity = await _unitOfWork.RegionRepository.GetRegion(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/Region
        [ResponseType(typeof(Region))]
        public async Task<IHttpActionResult> PostRegion(Region entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.RegionRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.RegionRepository.Find(entity.RegionId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.RegionRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.RegionId }, entity);
        }

        // PUT api/Region
        [ResponseType(typeof(Region))]
        public async Task<IHttpActionResult> PutRegion(Region entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.RegionRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.RegionRepository.Find(entity.RegionId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.RegionRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/Region/5
        public async Task<IHttpActionResult> DeleteRegion(int id)
        {
            bool result = await _unitOfWork.RegionRepository.DeleteRegion(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.RegionRepository.Find(id) == null)
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
