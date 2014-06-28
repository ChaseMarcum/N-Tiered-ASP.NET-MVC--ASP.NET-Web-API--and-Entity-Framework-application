using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TrackableEntities.Patterns.EF6;
using AIM.Service.EF.Contexts;
using AIM.Service.Entities.Models;
using AIM.Service.Persistence.Repositories;

namespace AIM.Service.EF.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly IAIM_DBContext _context;

        public QuestionRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            IEnumerable<Question> entities = await _context.Questions
                .Include(t => t.InterviewQuestions)
                .Include(t => t.Questionnaires)
                .ToListAsync();
            return entities;
        }

        public async Task<IEnumerable<Question>> GetQuestionsByQuestionnaireId(int questionnaireId)
        {
            IEnumerable<Question> entity = await _context.Questions
                .Where(t => t.QuestionnaireId == questionnaireId)
                .Include(t => t.Questionnaires)
                .Include(t => t.InterviewQuestions)
                .Include(t => t.ApplicantQuestionAnswers)
                .ToListAsync();
            return entity;
        }

        public async Task<Question> GetQuestion(int id)
        {
            Question entity = await _context.Questions
                .Include(t => t.InterviewQuestions)
                .Include(t => t.Questionnaires)
                .SingleOrDefaultAsync(t => t.QuestionId == id);
            return entity;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            Question entity = await _context.Questions
                .Include(t => t.InterviewQuestions)
                .Include(t => t.Questionnaires)
                .SingleOrDefaultAsync(t => t.QuestionId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
