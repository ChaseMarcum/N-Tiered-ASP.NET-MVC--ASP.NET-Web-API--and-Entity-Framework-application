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
    public class ApplicantQuestionAnswerController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public ApplicantQuestionAnswerController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/ApplicantQuestionAnswer
        [ResponseType(typeof(IEnumerable<ApplicantQuestionAnswer>))]
        public async Task<IHttpActionResult> GetApplicantQuestionAnswers()
        {
            IEnumerable<ApplicantQuestionAnswer> entities = await _unitOfWork.ApplicantQuestionAnswerRepository.GetApplicantQuestionAnswers();
            return Ok(entities);
        }

        // GET api/ApplicantQuestionAnswer/5
        [ResponseType(typeof(ApplicantQuestionAnswer))]
        public async Task<IHttpActionResult> GetApplicantQuestionAnswer(int id)
        {
            ApplicantQuestionAnswer entity = await _unitOfWork.ApplicantQuestionAnswerRepository.GetApplicantQuestionAnswer(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/ApplicantQuestionAnswer
        [ResponseType(typeof(ApplicantQuestionAnswer))]
        public async Task<IHttpActionResult> PostApplicantQuestionAnswer(ApplicantQuestionAnswer entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.ApplicantQuestionAnswerRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.ApplicantQuestionAnswerRepository.Find(entity.AnswerId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.ApplicantQuestionAnswerRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.AnswerId }, entity);
        }

        // PUT api/ApplicantQuestionAnswer
        [ResponseType(typeof(ApplicantQuestionAnswer))]
        public async Task<IHttpActionResult> PutApplicantQuestionAnswer(ApplicantQuestionAnswer entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.ApplicantQuestionAnswerRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.ApplicantQuestionAnswerRepository.Find(entity.AnswerId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.ApplicantQuestionAnswerRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/ApplicantQuestionAnswer/5
        public async Task<IHttpActionResult> DeleteApplicantQuestionAnswer(int id)
        {
            bool result = await _unitOfWork.ApplicantQuestionAnswerRepository.DeleteApplicantQuestionAnswer(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.ApplicantQuestionAnswerRepository.Find(id) == null)
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
