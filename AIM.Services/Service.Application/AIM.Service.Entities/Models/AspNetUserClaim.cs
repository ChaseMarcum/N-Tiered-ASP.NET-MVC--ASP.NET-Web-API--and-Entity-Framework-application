/****************************** Module Header ******************************\
* Module Name:  AspNetUserClaim.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Asp.Net User Claim Model.
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
    [Table("AspNetUserClaim")]
    public partial class AspNetUserClaim : ITrackable
    {
        [DataMember]
        [Display(Name = "ASP.NET User Claim ID")]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(128)]
        [Display(Name = "ASP.NET User Claim User ID")]
        public string UserId { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Claim Type")]
        public string ClaimType { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Claim Value")]
        public string ClaimValue { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User")]
        public AspNetUser AspNetUser { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}