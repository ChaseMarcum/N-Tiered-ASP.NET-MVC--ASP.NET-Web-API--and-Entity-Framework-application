using System;
using TrackableEntities.Patterns;
using AIM.Service.Persistence.Repositories;

namespace AIM.Service.Persistence.UnitsOfWork
{
    public interface IAIMAdminUnitOfWork : IUnitOfWork, IUnitOfWorkAsync
    {
        IApplicantQuestionAnswerRepository ApplicantQuestionAnswerRepository { get; }
        IApplicantRepository ApplicantRepository { get; }
        IApplicationRepository ApplicationRepository { get; }
        IAspNetRoleRepository AspNetRoleRepository { get; }
        IAspNetUserClaimRepository AspNetUserClaimRepository { get; }
        IAspNetUserLoginRepository AspNetUserLoginRepository { get; }
        IAspNetUserRepository AspNetUserRepository { get; }
        IEducationRepository EducationRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IHourRepository HourRepository { get; }
        IInterviewQuestionRepository InterviewQuestionRepository { get; }
        IJobHistoryRepository JobHistoryRepository { get; }
        IJobRepository JobRepository { get; }
        IOpenJobRepository OpenJobRepository { get; }
        IPersonalInfoRepository PersonalInfoRepository { get; }
        IQuestionnaireRepository QuestionnaireRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IReferenceRepository ReferenceRepository { get; }
        IRegionRepository RegionRepository { get; }
        IStoreRepository StoreRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
