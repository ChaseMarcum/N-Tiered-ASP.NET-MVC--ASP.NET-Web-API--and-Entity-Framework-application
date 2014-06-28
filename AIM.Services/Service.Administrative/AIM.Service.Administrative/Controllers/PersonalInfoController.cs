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
    public class PersonalInfoController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public PersonalInfoController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/PersonalInfo
        [ResponseType(typeof(IEnumerable<PersonalInfo>))]
        public async Task<IHttpActionResult> GetPersonalInfoes()
        {
            IEnumerable<PersonalInfo> entities = await _unitOfWork.PersonalInfoRepository.GetPersonalInfoes();
            return Ok(entities);
        }

        // GET api/PersonalInfo/5
        [ResponseType(typeof(PersonalInfo))]
        public async Task<IHttpActionResult> GetPersonalInfo(int id)
        {
            PersonalInfo entity = await _unitOfWork.PersonalInfoRepository.GetPersonalInfo(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/PersonalInfo
        [ResponseType(typeof(PersonalInfo))]
        public async Task<IHttpActionResult> PostPersonalInfo(PersonalInfo entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.PersonalInfoRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.PersonalInfoRepository.Find(entity.PersonalInfoId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.PersonalInfoRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.PersonalInfoId }, entity);
        }

        // PUT api/PersonalInfo
        [ResponseType(typeof(PersonalInfo))]
        public async Task<IHttpActionResult> PutPersonalInfo(PersonalInfo entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.PersonalInfoRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.PersonalInfoRepository.Find(entity.PersonalInfoId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.PersonalInfoRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/PersonalInfo/5
        public async Task<IHttpActionResult> DeletePersonalInfo(int id)
        {
            bool result = await _unitOfWork.PersonalInfoRepository.DeletePersonalInfo(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.PersonalInfoRepository.Find(id) == null)
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
