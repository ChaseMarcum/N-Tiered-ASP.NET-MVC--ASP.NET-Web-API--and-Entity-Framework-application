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
    public class StoreController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public StoreController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/Store
        [ResponseType(typeof(IEnumerable<Store>))]
        public async Task<IHttpActionResult> GetStores()
        {
            IEnumerable<Store> entities = await _unitOfWork.StoreRepository.GetStores();
            return Ok(entities);
        }

        // GET api/Store/5
        [ResponseType(typeof(Store))]
        public async Task<IHttpActionResult> GetStore(int id)
        {
            Store entity = await _unitOfWork.StoreRepository.GetStore(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // GET api/Store/5
        [ResponseType(typeof(IEnumerable<Store>))]
        public async Task<IHttpActionResult> GetStoresByRegionId(int regionId)
        {
            IEnumerable<Store> entities = await _unitOfWork.StoreRepository.GetStoresByRegionId(regionId);
            return Ok(entities);
        }

        // POST api/Store
        [ResponseType(typeof(Store))]
        public async Task<IHttpActionResult> PostStore(Store entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.StoreRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.StoreRepository.Find(entity.StoreId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.StoreRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.StoreId }, entity);
        }

        // PUT api/Store
        [ResponseType(typeof(Store))]
        public async Task<IHttpActionResult> PutStore(Store entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.StoreRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.StoreRepository.Find(entity.StoreId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.StoreRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/Store/5
        public async Task<IHttpActionResult> DeleteStore(int id)
        {
            bool result = await _unitOfWork.StoreRepository.DeleteStore(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.StoreRepository.Find(id) == null)
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
