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
    public class QuestionnaireController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public QuestionnaireController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/Questionnaire
        [ResponseType(typeof(IEnumerable<Questionnaire>))]
        public async Task<IHttpActionResult> GetQuestionnaires()
        {
            IEnumerable<Questionnaire> entities = await _unitOfWork.QuestionnaireRepository.GetQuestionnaires();
            return Ok(entities);
        }

        // GET api/Questionnaire/5
        [ResponseType(typeof(Questionnaire))]
        public async Task<IHttpActionResult> GetQuestionnaire(int id)
        {
            Questionnaire entity = await _unitOfWork.QuestionnaireRepository.GetQuestionnaire(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // GET api/Questionnaire/5
        [ResponseType(typeof(Questionnaire))]
        public async Task<IHttpActionResult> GetQuestionnaireByJobId(int jobId)
        {
            Questionnaire entity = await _unitOfWork.QuestionnaireRepository.GetQuestionnaireByJobId(jobId);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/Questionnaire
        [ResponseType(typeof(Questionnaire))]
        public async Task<IHttpActionResult> PostQuestionnaire(Questionnaire entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.QuestionnaireRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.QuestionnaireRepository.Find(entity.QuestionnaireId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.QuestionnaireRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.QuestionnaireId }, entity);
        }

        // PUT api/Questionnaire
        [ResponseType(typeof(Questionnaire))]
        public async Task<IHttpActionResult> PutQuestionnaire(Questionnaire entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.QuestionnaireRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.QuestionnaireRepository.Find(entity.QuestionnaireId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.QuestionnaireRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/Questionnaire/5
        public async Task<IHttpActionResult> DeleteQuestionnaire(int id)
        {
            bool result = await _unitOfWork.QuestionnaireRepository.DeleteQuestionnaire(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.QuestionnaireRepository.Find(id) == null)
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
