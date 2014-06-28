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
    public class QuestionController : ApiController
    {
        private readonly IAIMAdminUnitOfWork _unitOfWork;

        public QuestionController(IAIMAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/Question
        [ResponseType(typeof(IEnumerable<Question>))]
        public async Task<IHttpActionResult> GetQuestions()
        {
            IEnumerable<Question> entities = await _unitOfWork.QuestionRepository.GetQuestions();
            return Ok(entities);
        }

        [ResponseType(typeof(IEnumerable<Question>))]
        public async Task<IHttpActionResult> GetQuestionsByQuestionnaireId(int questionnaireId)
        {
            IEnumerable<Question> entities = await _unitOfWork.QuestionRepository.GetQuestionsByQuestionnaireId(questionnaireId);
            return Ok(entities);
        }

        // GET api/Question/5
        [ResponseType(typeof(Question))]
        public async Task<IHttpActionResult> GetQuestion(int id)
        {
            Question entity = await _unitOfWork.QuestionRepository.GetQuestion(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        // POST api/Question
        [ResponseType(typeof(Question))]
        public async Task<IHttpActionResult> PostQuestion(Question entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.QuestionRepository.Insert(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateException)
            {
                if (_unitOfWork.QuestionRepository.Find(entity.QuestionId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.QuestionRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.QuestionId }, entity);
        }

        // PUT api/Question
        [ResponseType(typeof(Question))]
        public async Task<IHttpActionResult> PutQuestion(Question entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.QuestionRepository.Update(entity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.QuestionRepository.Find(entity.QuestionId) == null)
                {
                    return Conflict();
                }
                throw;
            }

            await _unitOfWork.QuestionRepository.LoadRelatedEntitiesAsync(entity);
            entity.AcceptChanges();
            return Ok(entity);
        }

        // DELETE api/Question/5
        public async Task<IHttpActionResult> DeleteQuestion(int id)
        {
            bool result = await _unitOfWork.QuestionRepository.DeleteQuestion(id);
            if (!result) return Ok();

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (UpdateConcurrencyException)
            {
                if (_unitOfWork.QuestionRepository.Find(id) == null)
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
