using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackableEntities.Patterns;
using AIM.Service.Entities.Models;

namespace AIM.Service.Persistence.Repositories
{
    public interface IInterviewQuestionRepository : IRepository<InterviewQuestion>, IRepositoryAsync<InterviewQuestion>
    {
        Task<IEnumerable<InterviewQuestion>> GetInterviewQuestions();
        Task<InterviewQuestion> GetInterviewQuestion(int id);
        Task<bool> DeleteInterviewQuestion(int id);
    }
}
