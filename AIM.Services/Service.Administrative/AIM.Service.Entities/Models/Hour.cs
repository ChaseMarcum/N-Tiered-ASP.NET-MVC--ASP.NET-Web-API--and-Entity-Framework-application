/****************************** Module Header ******************************\
* Module Name:  Hour.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Hour Model.
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
    [Table("Hour")]
    public partial class Hour : ITrackable
    {
        public Hour()
        {
            this.Jobs = new List<Job>();
        }

        // Hour Primary Key
        [DataMember]
        [Display(Name = "Hours Id")]
        [Key]
        public int HoursId { get; set; }

        // Hour Properties
        [DataMember]
        [Display(Name = "Mon")]
        public TimeSpan? MonOpen { get; set; }

        [DataMember]
        [Display(Name = "Mon")]
        public TimeSpan? MonClose { get; set; }

        [DataMember]
        [Display(Name = "Tue")]
        public TimeSpan? TueOpen { get; set; }

        [DataMember]
        [Display(Name = "Tue")]
        public TimeSpan? TueClose { get; set; }

        [DataMember]
        [Display(Name = "Wed")]
        public TimeSpan? WedOpen { get; set; }

        [DataMember]
        [Display(Name = "Wed")]
        public TimeSpan? WedClose { get; set; }

        [DataMember]
        [Display(Name = "Thurs")]
        public TimeSpan? ThursOpen { get; set; }

        [DataMember]
        [Display(Name = "Thurs")]
        public TimeSpan? ThursClose { get; set; }

        [DataMember]
        [Display(Name = "Fri")]
        public TimeSpan? FriOpen { get; set; }

        [DataMember]
        [Display(Name = "Fri")]
        public TimeSpan? FriClose { get; set; }

        [DataMember]
        [Display(Name = "Sat")]
        public TimeSpan? SatOpen { get; set; }

        [DataMember]
        [Display(Name = "Sat")]
        public TimeSpan? SatClose { get; set; }

        [DataMember]
        [Display(Name = "Sun")]
        public TimeSpan? SunOpen { get; set; }

        [DataMember]
        [Display(Name = "Sun")]
        public TimeSpan? SunClose { get; set; }

        // Hour Table & Column Mappings
        [DataMember]
        [Display(Name = "Applicant Id")]
        public int? ApplicantId { get; set; }

        [DataMember]
        [Display(Name = "Applicant")]
        public Applicant Applicant { get; set; }

        [DataMember]
        [Display(Name = "Job")]
        public List<Job> Jobs { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}