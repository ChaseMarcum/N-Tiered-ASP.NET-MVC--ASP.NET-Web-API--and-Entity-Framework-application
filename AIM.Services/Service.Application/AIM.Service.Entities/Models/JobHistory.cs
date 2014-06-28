/****************************** Module Header ******************************\
* Module Name:  JobHistory.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Job History Model.
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
    [Table("JobHistory")]
    public partial class JobHistory : ITrackable
    {
        // Job History Primary Key
        [DataMember]
        [Display(Name = "JobHistory Id")]
        [Key]
        public int JobHistoryId { get; set; }

        // Job History Properties
        [DataMember]
        [Display(Name = "Employer Name")]
        [StringLength(50)]
        public string EmployerName { get; set; }

        [DataMember]
        [Display(Name = "Position")]
        [StringLength(50)]
        public string Position { get; set; }

        [DataMember]
        [Display(Name = "Responsibilities")]
        public string Responsibilities { get; set; }

        [DataMember]
        [Display(Name = "Supervisor")]
        [StringLength(50)]
        public string Supervisor { get; set; }

        [DataMember]
        [Display(Name = "Starting Salary")]
        public decimal? StartingSalary { get; set; }

        [DataMember]
        [Display(Name = "Ending Salary")]
        public decimal? EndingSalary { get; set; }

        [DataMember]
        [Display(Name = "Reason For Leaving")]
        public string ReasonForLeaving { get; set; }

        [DataMember]
        [Display(Name = "Date From")]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        [Display(Name = "Date To")]
        public DateTime? DateTo { get; set; }

        [DataMember]
        [Display(Name = "Street")]
        [StringLength(100)]
        public string Street { get; set; }

        [DataMember]
        [Display(Name = "Street Additional")]
        [StringLength(100)]
        public string Street2 { get; set; }

        [DataMember]
        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }

        [DataMember]
        [Display(Name = "State")]
        public StateEnum? State { get; set; }

        [DataMember]
        [Display(Name = "Zip")]
        [StringLength(5)]
        public string Zip { get; set; }

        [DataMember]
        [Display(Name = "Phone")]
        [StringLength(13)]
        public string Phone { get; set; }

        // Application Table & Column Mappings
        [DataMember]
        [Display(Name = "Applicant Id")]
        public int? ApplicantId { get; set; }

        [DataMember]
        [Display(Name = "Applicant")]
        public Applicant Applicant { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}