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
    public class QuestionnaireRepository : Repository<Questionnaire>, IQuestionnaireRepository
    {
        private readonly IAIM_DBContext _context;

        public QuestionnaireRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Questionnaire>> GetQuestionnaires()
        {
            IEnumerable<Questionnaire> entities = await _context.Questionnaires
                .Include(t => t.Jobs)
                .Include(t => t.Questions)
                .ToListAsync();
            return entities;
        }

        public async Task<Questionnaire> GetQuestionnaire(int id)
        {
            Questionnaire entity = await _context.Questionnaires
                .Include(t => t.Jobs)
                .Include(t => t.Questions)
                .SingleOrDefaultAsync(t => t.QuestionnaireId == id);
            return entity;
        }

        public async Task<Questionnaire> GetQuestionnaireByJobId(int id)
        {
            Questionnaire entity = await _context.Questionnaires
                .Where(t => t.JobId == id)
                .Include(t => t.Jobs)
                .Include(t => t.Questions)
                .SingleOrDefaultAsync(t => t.QuestionnaireId == id);
            return entity;
        }

        public async Task<bool> DeleteQuestionnaire(int id)
        {
            Questionnaire entity = await _context.Questionnaires
                .Include(t => t.Jobs)
                .Include(t => t.Questions)
                .SingleOrDefaultAsync(t => t.QuestionnaireId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
