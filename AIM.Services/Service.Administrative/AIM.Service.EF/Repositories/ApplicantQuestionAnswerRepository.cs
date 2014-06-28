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
    public class ApplicantQuestionAnswerRepository : Repository<ApplicantQuestionAnswer>, IApplicantQuestionAnswerRepository
    {
        private readonly IAIM_DBContext _context;

        public ApplicantQuestionAnswerRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<ApplicantQuestionAnswer>> GetApplicantQuestionAnswers()
        {
            IEnumerable<ApplicantQuestionAnswer> entities = await _context.ApplicantQuestionAnswers
                .Include(t => t.Applicant)
                .Include(t => t.Question)
                .ToListAsync();
            return entities;
        }

        public async Task<ApplicantQuestionAnswer> GetApplicantQuestionAnswer(int id)
        {
            ApplicantQuestionAnswer entity = await _context.ApplicantQuestionAnswers
                .Include(t => t.Applicant)
                .Include(t => t.Question)
                .SingleOrDefaultAsync(t => t.AnswerId == id);
            return entity;
        }

        public async Task<bool> DeleteApplicantQuestionAnswer(int id)
        {
            ApplicantQuestionAnswer entity = await _context.ApplicantQuestionAnswers
                .Include(t => t.Applicant)
                .Include(t => t.Question)
                .SingleOrDefaultAsync(t => t.AnswerId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
