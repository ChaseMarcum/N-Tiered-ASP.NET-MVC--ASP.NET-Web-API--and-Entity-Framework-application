/****************************** Module Header ******************************\
* Module Name:  Application.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Application Model.
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
    [Table("Application")]
    public partial class Application : ITrackable
    {
        // Application Primary Key
        [DataMember]
        [Display(Name = "Application ID")]
        public int ApplicationId { get; set; }

        // Education Properties
        [DataMember]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        [DataMember]
        [Display(Name = "Pre-Employment Statement")]
        [StringLength(100)]
        public string PreEmploymentStatement { get; set; }

        [DataMember]
        [Display(Name = "Status")]
        public StatusEnum? Status { get; set; }

        [DataMember]
        [Display(Name = "Salary Expectation")]
        [StringLength(20)]
        public string SalaryExpectation { get; set; }

        [DataMember]
        [Display(Name = "Full Time")]
        public bool? IsFullTime { get; set; }

        [DataMember]
        [Display(Name = "Days")]
        public bool? IsDays { get; set; }

        [DataMember]
        [Display(Name = "Evenings")]
        public bool? IsEvenings { get; set; }

        [DataMember]
        [Display(Name = "Weekends")]
        public bool? IsWeekends { get; set; }

        // Application Table & Column Mappings
        [DataMember]
        [Display(Name = "Applicant Id")]
        public int? ApplicantId { get; set; }

        [DataMember]
        [Display(Name = "Applicant")]
        public Applicant Applicant { get; set; }

        [DataMember]
        [Display(Name = "Job Id")]
        public int? JobId { get; set; }

        [DataMember]
        [Display(Name = "Job")]
        public Job Job { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}