using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IQuestionnaireRepository : IRepository<Questionnaire>, IRepositoryAsync<Questionnaire>
    {
        Task<IEnumerable<Questionnaire>> GetQuestionnaires();
        Task<Questionnaire> GetQuestionnaire(int id);
        Task<Questionnaire> GetQuestionnaireByJobId(int id);
        Task<bool> DeleteQuestionnaire(int id);
    }
}
