using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IQuestionRepository : IRepository<Question>, IRepositoryAsync<Question>
    {
        Task<IEnumerable<Question>> GetQuestions();
        Task<IEnumerable<Question>> GetQuestionsByQuestionnaireId(int questionnaireId);
        Task<Question> GetQuestion(int id);
        Task<bool> DeleteQuestion(int id);
    }
}
