using System;
using System.Web.Http;
using TinyIoC;
using AIM.Service.EF.Contexts;
using AIM.Service.EF.Repositories;
using AIM.Service.EF.UnitsOfWork;
using AIM.Service.Entities.Models;
using AIM.Service.Persistence.Repositories;
using AIM.Service.Persistence.UnitsOfWork;
using AIM.Service.Administrative.DependencyResolution;

namespace AIM.Service.Administrative
{
    public static class IoCConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Get IoC container
            var container = TinyIoCContainer.Current;

            // registration
            container.Resolve<ApplicantQuestionAnswer>();
            container.Resolve<Applicant>();
            container.Resolve<Application>();
            container.Resolve<AspNetRole>();
            container.Resolve<AspNetUserClaim>();
            container.Resolve<AspNetUserLogin>();
            container.Resolve<AspNetUser>();
            container.Resolve<Education>();
            container.Resolve<Hour>();
            container.Resolve<InterviewQuestion>();
            container.Resolve<JobHistory>();
            container.Resolve<Job>();
            container.Resolve<OpenJob>();
            container.Resolve<PersonalInfo>();
            container.Resolve<Questionnaire>();
            container.Resolve<Question>();
            container.Resolve<Reference>();
            container.Resolve<Region>();
            container.Resolve<Store>();
            container.Resolve<User>();

            // Register context, unit of work and repos with per request lifetime
            container.Register<IAIM_DBContext, AIM_DBContext>().AsPerRequestSingleton();
            container.Register<IAIMAdminUnitOfWork, AIMAdminUnitOfWork>().AsPerRequestSingleton();
            container.Register<IApplicantRepository, ApplicantRepository>().AsPerRequestSingleton();
            container.Register<IApplicantQuestionAnswerRepository, ApplicantQuestionAnswerRepository>().AsPerRequestSingleton();
            container.Register<IApplicationRepository, ApplicationRepository>().AsPerRequestSingleton();
            container.Register<IAspNetRoleRepository, AspNetRoleRepository>().AsPerRequestSingleton();
            container.Register<IAspNetUserClaimRepository, AspNetUserClaimRepository>().AsPerRequestSingleton();
            container.Register<IAspNetUserLoginRepository, AspNetUserLoginRepository>().AsPerRequestSingleton();
            container.Register<IAspNetUserRepository, AspNetUserRepository>().AsPerRequestSingleton();
            container.Register<IEducationRepository, EducationRepository>().AsPerRequestSingleton();
            container.Register<IEmployeeRepository, EmployeeRepository>().AsPerRequestSingleton();
            container.Register<IHourRepository, HourRepository>().AsPerRequestSingleton();
            container.Register<IInterviewQuestionRepository, InterviewQuestionRepository>().AsPerRequestSingleton();
            container.Register<IJobHistoryRepository, JobHistoryRepository>().AsPerRequestSingleton();
            container.Register<IJobRepository, JobRepository>().AsPerRequestSingleton();
            container.Register<IOpenJobRepository, OpenJobRepository>().AsPerRequestSingleton();
            container.Register<IPersonalInfoRepository, PersonalInfoRepository>().AsPerRequestSingleton();
            container.Register<IQuestionnaireRepository, QuestionnaireRepository>().AsPerRequestSingleton();
            container.Register<IQuestionRepository, QuestionRepository>().AsPerRequestSingleton();
            container.Register<IReferenceRepository, ReferenceRepository>().AsPerRequestSingleton();
            container.Register<IRegionRepository, RegionRepository>().AsPerRequestSingleton();
            container.Register<IStoreRepository, StoreRepository>().AsPerRequestSingleton();
            container.Register<IUserRepository, UserRepository>().AsPerRequestSingleton();

            // Set Web API dep resolver
            config.DependencyResolver = new TinyIoCDependencyResolver(container);
        }
    }
}
