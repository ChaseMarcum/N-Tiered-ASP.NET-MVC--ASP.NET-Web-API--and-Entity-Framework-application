/****************************** Module Header ******************************\
* Module Name:  Job.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Job Model.
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
    [Table("Job")]
    public partial class Job : ITrackable
    {
        public Job()
        {
            this.Applications = new List<Application>();
            this.Employees = new List<Employee>();
            this.OpenJobs = new List<OpenJob>();
        }

        // Job Primary Key
        [DataMember]
        [Display(Name = "Job Id")]
        [Key]
        public int JobId { get; set; }

        // Employee Properties
        [DataMember]
        [Display(Name = "Position")]
        [StringLength(150)]
        public string Position { get; set; }

        [DataMember]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataMember]
        [Display(Name = "Full/Part Time")]
        [StringLength(50)]
        public string FullPartTime { get; set; }

        [DataMember]
        [Display(Name = "Salary Range")]
        [StringLength(100)]
        public string SalaryRange { get; set; }

        // Job Table & Column Mappings
        [DataMember]
        [Display(Name = "Questionnaire Id")]
        public int? QuestionnaireId { get; set; }

        [DataMember]
        [Display(Name = "Hours Id")]
        public int? HoursId { get; set; }

        [DataMember]
        [Display(Name = "Interview Question Id")]
        public int? InterviewQuestionId { get; set; }

        [DataMember]
        [Display(Name = "Application")]
        public List<Application> Applications { get; set; }

        [DataMember]
        [Display(Name = "Employees")]
        public List<Employee> Employees { get; set; }

        [DataMember]
        [Display(Name = "Hour")]
        public Hour Hour { get; set; }

        [DataMember]
        [Display(Name = "Interview Question")]
        public InterviewQuestion InterviewQuestion { get; set; }

        [DataMember]
        [Display(Name = "Questionnaire")]
        public Questionnaire Questionnaire { get; set; }

        [DataMember]
        [Display(Name = "Open Job")]
        public List<OpenJob> OpenJobs { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}