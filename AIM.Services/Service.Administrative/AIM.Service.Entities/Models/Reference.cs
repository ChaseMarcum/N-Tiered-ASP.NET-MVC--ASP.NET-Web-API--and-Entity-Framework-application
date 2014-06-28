/****************************** Module Header ******************************\
* Module Name:  Reference.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Reference Model.
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
    [Table("Reference")]
    public partial class Reference : ITrackable
    {
        // Reference Primary Key
        [DataMember]
        [Display(Name = "Reference Id")]
        [Key]
        public int ReferenceId { get; set; }

        // Reference Properties
        [DataMember]
        [Display(Name = "Reference Full Name")]
        [StringLength(50)]
        public string RefFullName { get; set; }

        [DataMember]
        [Display(Name = "Reference Company")]
        [StringLength(50)]
        public string RefCompany { get; set; }

        [DataMember]
        [Display(Name = "Reference Title")]
        [StringLength(50)]
        public string RefTitle { get; set; }

        [DataMember]
        [Display(Name = "Reference Phone")]
        [StringLength(13)]
        public string RefPhone { get; set; }

        // Reference Table & Column Mappings
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