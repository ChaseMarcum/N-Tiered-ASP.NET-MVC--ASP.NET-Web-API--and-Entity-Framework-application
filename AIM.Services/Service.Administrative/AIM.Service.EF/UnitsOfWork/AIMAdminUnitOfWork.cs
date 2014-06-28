using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using TrackableEntities.Patterns.EF6;
using AIM.Service.EF.Contexts;
using AIM.Service.Persistence.Exceptions;
using AIM.Service.Persistence.Repositories;
using AIM.Service.Persistence.UnitsOfWork;

namespace AIM.Service.EF.UnitsOfWork
{
    public class AIMAdminUnitOfWork : UnitOfWork, IAIMAdminUnitOfWork
    {
        private readonly IApplicantQuestionAnswerRepository _applicantQuestionAnswerRepository;
        private readonly IApplicantRepository _applicantRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly IAspNetRoleRepository _aspNetRoleRepository;
        private readonly IAspNetUserClaimRepository _aspNetUserClaimRepository;
        private readonly IAspNetUserLoginRepository _aspNetUserLoginRepository;
        private readonly IAspNetUserRepository _aspNetUserRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHourRepository _hourRepository;
        private readonly IInterviewQuestionRepository _interviewQuestionRepository;
        private readonly IJobHistoryRepository _jobHistoryRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IOpenJobRepository _openJobRepository;
        private readonly IPersonalInfoRepository _personalInfoRepository;
        private readonly IQuestionnaireRepository _questionnaireRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IReferenceRepository _referenceRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IUserRepository _userRepository;

        public AIMAdminUnitOfWork(IAIM_DBContext context,
            IApplicantQuestionAnswerRepository applicantQuestionAnswerRepository,
            IApplicantRepository applicantRepository,
            IApplicationRepository applicationRepository,
            IAspNetRoleRepository aspNetRoleRepository,
            IAspNetUserClaimRepository aspNetUserClaimRepository,
            IAspNetUserLoginRepository aspNetUserLoginRepository,
            IAspNetUserRepository aspNetUserRepository,
            IEducationRepository educationRepository,
            IEmployeeRepository employeeRepository,
            IHourRepository hourRepositor,
            IInterviewQuestionRepository interviewQuestionRepository,
            IJobHistoryRepository jobHistoryRepository,
            IJobRepository jobRepository,
            IOpenJobRepository openJobRepository,
            IPersonalInfoRepository personalInfoRepository,
            IQuestionnaireRepository questionnaireRepository,
            IQuestionRepository questionRepository,
            IReferenceRepository referenceRepository,
            IRegionRepository regionRepository,
            IStoreRepository storeRepository,
            IUserRepository userRepository) :
            base(context as DbContext)
        {
            _applicantQuestionAnswerRepository = applicantQuestionAnswerRepository;
            _applicantRepository = applicantRepository;
            _applicationRepository = applicationRepository;
            _aspNetRoleRepository = aspNetRoleRepository;
            _aspNetUserClaimRepository = aspNetUserClaimRepository;
            _aspNetUserLoginRepository = aspNetUserLoginRepository;
            _aspNetUserRepository = aspNetUserRepository;
            _educationRepository = educationRepository;
            _employeeRepository = employeeRepository;
            _hourRepository = hourRepositor;
            _interviewQuestionRepository = interviewQuestionRepository;
            _jobHistoryRepository = jobHistoryRepository;
            _jobRepository = jobRepository;
            _openJobRepository = openJobRepository;
            _personalInfoRepository = personalInfoRepository;
            _questionnaireRepository = questionnaireRepository;
            _questionRepository = questionRepository;
            _referenceRepository = referenceRepository;
            _regionRepository = regionRepository;
            _storeRepository = storeRepository;
            _userRepository = userRepository;
        }

        public IApplicantQuestionAnswerRepository ApplicantQuestionAnswerRepository
        {
            get { return _applicantQuestionAnswerRepository; }
        }

        public IApplicantRepository ApplicantRepository
        {
            get { return _applicantRepository; }
        }

        public IApplicationRepository ApplicationRepository
        {
            get { return _applicationRepository; }
        }

        public IAspNetRoleRepository AspNetRoleRepository
        {
            get { return _aspNetRoleRepository; }
        }

        public IAspNetUserClaimRepository AspNetUserClaimRepository
        {
            get { return _aspNetUserClaimRepository; }
        }

        public IAspNetUserLoginRepository AspNetUserLoginRepository
        {
            get { return _aspNetUserLoginRepository; }
        }

        public IAspNetUserRepository AspNetUserRepository
        {
            get { return _aspNetUserRepository; }
        }

        public IEducationRepository EducationRepository
        {
            get { return _educationRepository; }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get { return _employeeRepository; }
        }

        public IHourRepository HourRepository
        {
            get { return _hourRepository; }
        }

        public IInterviewQuestionRepository InterviewQuestionRepository
        {
            get { return _interviewQuestionRepository; }
        }

        public IJobHistoryRepository JobHistoryRepository
        {
            get { return _jobHistoryRepository; }
        }

        public IJobRepository JobRepository
        {
            get { return _jobRepository; }
        }

        public IOpenJobRepository OpenJobRepository
        {
            get { return _openJobRepository; }
        }

        public IPersonalInfoRepository PersonalInfoRepository
        {
            get { return _personalInfoRepository; }
        }

        public IQuestionnaireRepository QuestionnaireRepository
        {
            get { return _questionnaireRepository; }
        }

        public IQuestionRepository QuestionRepository
        {
            get { return _questionRepository; }
        }

        public IReferenceRepository ReferenceRepository
        {
            get { return _referenceRepository; }
        }

        public IRegionRepository RegionRepository
        {
            get { return _regionRepository; }
        }

        public IStoreRepository StoreRepository
        {
            get { return _storeRepository; }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository; }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                throw new UpdateConcurrencyException(concurrencyException.Message,
                    concurrencyException);
            }
            catch (DbUpdateException updateException)
            {
                throw new UpdateException(updateException.Message,
                    updateException);
            }
        }

        public override Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync(CancellationToken.None);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException concurrencyException)
            {
                throw new UpdateConcurrencyException(concurrencyException.Message,
                    concurrencyException);
            }
            catch (DbUpdateException updateException)
            {
                throw new UpdateException(updateException.Message, 
                    updateException);
            }
        }
    }
}
