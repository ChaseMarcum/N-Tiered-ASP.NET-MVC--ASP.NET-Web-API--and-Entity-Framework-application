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
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        private readonly IAIM_DBContext _context;

        public ApplicantRepository(IAIM_DBContext context) :
            base(context as DbContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Applicant>> GetApplicants()
        {
            IEnumerable<Applicant> entities = await _context.Applicants
                .Include(t => t.ApplicantQuestionAnswers)
                .Include(t => t.Applications)
                .Include(t => t.Educations)
                .Include(t => t.JobHistories)
                .Include(t => t.Hours)
                .Include(t => t.References)
                .Include(t => t.Users)
                .ToListAsync();
            return entities;
        }

        public async Task<Applicant> GetApplicant(int id)
        {
            Applicant entity = await _context.Applicants
                .Include(t => t.ApplicantQuestionAnswers)
                .Include(t => t.Applications)
                .Include(t => t.Educations)
                .Include(t => t.JobHistories)
                .Include(t => t.Hours)
                .Include(t => t.References)
                .Include(t => t.Users)
                .SingleOrDefaultAsync(t => t.ApplicantId == id);
            return entity;
        }

        public async Task<bool> DeleteApplicant(int id)
        {
            Applicant entity = await _context.Applicants
                .Include(t => t.ApplicantQuestionAnswers)
                .Include(t => t.Applications)
                .Include(t => t.Educations)
                .Include(t => t.JobHistories)
                .Include(t => t.Hours)
                .Include(t => t.References)
                .Include(t => t.Users)
                .SingleOrDefaultAsync(t => t.ApplicantId == id);
            if (entity == null) return false;
            ApplyDelete(entity);
            return true;
        }
    }
}
