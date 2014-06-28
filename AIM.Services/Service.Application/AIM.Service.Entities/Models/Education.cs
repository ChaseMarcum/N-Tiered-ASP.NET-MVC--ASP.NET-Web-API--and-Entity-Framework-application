/****************************** Module Header ******************************\
* Module Name:  Education.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Education Model.
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
    [Table("Education")]
    public partial class Education : ITrackable
    {
        // Education Primary Key
        [DataMember]
        [Display(Name = "Education ID")]
        public int EducationId { get; set; }

        // Education Properties
        [DataMember]
        [StringLength(100)]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        [DataMember]
        [Display(Name = "Degree")]
        [StringLength(100)]
        public string Degree { get; set; }

        [DataMember]
        [Display(Name = "Date Graduated")]
        public DateTime? Graduated { get; set; }

        [DataMember]
        [Display(Name = "Years Attended")]
        [StringLength(100)]
        public string YearsAttended { get; set; }

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
        [StringLength(100)]
        public string City { get; set; }

        [DataMember]
        [Display(Name = "State")]
        public StateEnum? State { get; set; }

        [DataMember]
        [Display(Name = "Zip Code")]
        [StringLength(5)]
        public string Zip { get; set; }

        // Education Table & Column Mappings
        [DataMember]
        [Display(Name = "Applicant ID")]
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