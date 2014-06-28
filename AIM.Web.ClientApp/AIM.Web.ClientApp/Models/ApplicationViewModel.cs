using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIM.Web.ClientApp.Models.EntityModels;

namespace AIM.Web.ClientApp.Models
{
    public class ApplicationViewModel
    {
        public EntityModels.Application Application { get; set; }
        public Applicant Applicant { get; set; }
        public Job Job { get; set; }
        public ApplicantQuestionAnswer ApplicantQuestionAnswer { get; set; }
        public ICollection<Education> Education { get; set; }
        public ICollection<JobHistory> JobHistory { get; set; }
        public Hour Hour { get; set; }
        public ICollection<Reference> Reference { get; set; }
        public User User { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
    }
}