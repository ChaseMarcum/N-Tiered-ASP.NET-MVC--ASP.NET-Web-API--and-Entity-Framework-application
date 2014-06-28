/****************************** Module Header ******************************\
* Module Name:  ApplicantQuestionAnswer.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Applicant Question Answer Model.
\***************************************************************************/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using TrackableEntities;

namespace AIM.Service.Entities.Models
{
    [JsonObject(IsReference = true)]
    [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]
    [Table("Applicant")]
    public partial class Applicant : ITrackable
    {
        public Applicant()
        {
            this.ApplicantQuestionAnswers = new List<ApplicantQuestionAnswer>();
            this.Applications = new List<Application>();
            this.Educations = new List<Education>();
            this.JobHistories = new List<JobHistory>();
            this.Hours = new List<Hour>();
            this.References = new List<Reference>();
            this.Users = new List<User>();
        }

        // Applicant Primary Key
        [DataMember]
        [Display(Name = "Applicant ID")]
        public int ApplicantId { get; set; }

        // Applicant Table & Column Mappings
        [DataMember]
        [Display(Name = "Education ID")]
        public int? EducationId { get; set; }

        [DataMember]
        [Display(Name = "Job History ID")]
        public int? JobHistoryId { get; set; }

        [DataMember]
        [Display(Name = "Reference ID")]
        public int? ReferenceId { get; set; }

        [DataMember]
        [Display(Name = "User ID")]
        public int? UserId { get; set; }

        [DataMember]
        [Display(Name = "Application ID")]
        public int? ApplicationId { get; set; }

        [DataMember]
        [Display(Name = "Answer ID")]
        public int? AnswerId { get; set; }

        [DataMember]
        [Display(Name = "Hours ID")]
        public int? HoursId { get; set; }

        [DataMember]
        [Display(Name = "Applicant Question Answers List")]
        public List<ApplicantQuestionAnswer> ApplicantQuestionAnswers { get; set; }

        [DataMember]
        [Display(Name = "Applications List")]
        public List<Application> Applications { get; set; }

        [DataMember]
        [Display(Name = "Educations List")]
        public List<Education> Educations { get; set; }

        [DataMember]
        [Display(Name = "Job Histories list")]
        public List<JobHistory> JobHistories { get; set; }

        [DataMember]
        [Display(Name = "Hours List")]
        public List<Hour> Hours { get; set; }

        [DataMember]
        [Display(Name = "References List")]
        public List<Reference> References { get; set; }

        [DataMember]
        [Display(Name = "Users List")]
        public List<User> Users { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}