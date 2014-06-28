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
    public class InterviewQuestionRepository : Repository<InterviewQuestion>, IInterviewQuestionRepository
    {
        private readonly IAIM_DBContext _context;

        public InterviewQuestionRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<InterviewQuestion>> GetInterviewQuestions()
        {
            IEnumerable<InterviewQuestion> entities = await _context.InterviewQuestions
                .Include(t => t.Jobs)
                .Include(t => t.Questions)
                .ToListAsync();
            return entities;
        }

        public async Task<InterviewQuestion> GetInterviewQuestion(int id)
        {
            InterviewQuestion entity = await _context.InterviewQuestions
                .Include(t => t.Jobs)
                .Include(t => t.Questions)
                .SingleOrDefaultAsync(t => t.InterviewQuestionsId == id);
            return entity;
        }

        public async Task<bool> DeleteInterviewQuestion(int id)
        {
            InterviewQuestion entity = await _context.InterviewQuestions
                .Include(t => t.Jobs)
                .Include(t => t.Questions)
                .SingleOrDefaultAsync(t => t.InterviewQuestionsId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
