using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IApplicantQuestionAnswerRepository : IRepository<ApplicantQuestionAnswer>, IRepositoryAsync<ApplicantQuestionAnswer>
    {
        Task<IEnumerable<ApplicantQuestionAnswer>> GetApplicantQuestionAnswers();
        Task<ApplicantQuestionAnswer> GetApplicantQuestionAnswer(int id);
        Task<bool> DeleteApplicantQuestionAnswer(int id);
    }
}
