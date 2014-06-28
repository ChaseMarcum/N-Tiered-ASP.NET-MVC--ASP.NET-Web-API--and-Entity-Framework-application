using System;
using System.Data.Entity;
using AIM.Service.Entities.Models;

namespace AIM.Service.EF.Contexts
{
    public interface IAIM_DBContext
    {
        IDbSet<ApplicantQuestionAnswer> ApplicantQuestionAnswers { get; set; }
        IDbSet<Applicant> Applicants { get; set; }
        IDbSet<Application> Applications { get; set; }
        IDbSet<AspNetRole> AspNetRoles { get; set; }
        IDbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        IDbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        IDbSet<AspNetUser> AspNetUsers { get; set; }
        IDbSet<Education> Educations { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<Hour> Hours { get; set; }
        IDbSet<InterviewQuestion> InterviewQuestions { get; set; }
        IDbSet<JobHistory> JobHistories { get; set; }
        IDbSet<Job> Jobs { get; set; }
        IDbSet<OpenJob> OpenJobs { get; set; }
        IDbSet<PersonalInfo> PersonalInfoes { get; set; }
        IDbSet<Questionnaire> Questionnaires { get; set; }
        IDbSet<Question> Questions { get; set; }
        IDbSet<Reference> References { get; set; }
        IDbSet<Region> Regions { get; set; }
        IDbSet<Store> Stores { get; set; }
        IDbSet<User> Users { get; set; }
    }
}
