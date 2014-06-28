using System.Data.Entity;
using AIM.Service.Entities.Models.Mapping;
using AIM.Service.Entities.Models;

namespace AIM.Service.EF.Contexts
{
    public partial class AIM_DBContext : DbContext, IAIM_DBContext
    {
        static AIM_DBContext()
        {
            Database.SetInitializer<AIM_DBContext>(null);
        }

        public AIM_DBContext()
            : base("Name=AIM_DBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<ApplicantQuestionAnswer> ApplicantQuestionAnswers { get; set; }
        public IDbSet<Applicant> Applicants { get; set; }
        public IDbSet<Application> Applications { get; set; }
        public IDbSet<AspNetRole> AspNetRoles { get; set; }
        public IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public IDbSet<AspNetUser> AspNetUsers { get; set; }
        public IDbSet<Education> Educations { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Hour> Hours { get; set; }
        public IDbSet<InterviewQuestion> InterviewQuestions { get; set; }
        public IDbSet<JobHistory> JobHistories { get; set; }
        public IDbSet<Job> Jobs { get; set; }
        public IDbSet<OpenJob> OpenJobs { get; set; }
        public IDbSet<PersonalInfo> PersonalInfoes { get; set; }
        public IDbSet<Questionnaire> Questionnaires { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<Reference> References { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<Store> Stores { get; set; }
        public IDbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicantQuestionAnswerMap());
            modelBuilder.Configurations.Add(new ApplicantMap());
            modelBuilder.Configurations.Add(new ApplicationMap());
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new EducationMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new HourMap());
            modelBuilder.Configurations.Add(new InterviewQuestionMap());
            modelBuilder.Configurations.Add(new JobHistoryMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new OpenJobMap());
            modelBuilder.Configurations.Add(new PersonalInfoMap());
            modelBuilder.Configurations.Add(new QuestionnaireMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new ReferenceMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new StoreMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
