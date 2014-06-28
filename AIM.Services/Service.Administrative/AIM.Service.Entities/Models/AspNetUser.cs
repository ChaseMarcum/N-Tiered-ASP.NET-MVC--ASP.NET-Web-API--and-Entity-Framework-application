/****************************** Module Header ******************************\
* Module Name:  AspNetUser.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Asp.Net User Model.
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
    [Table("AspNetUser")]
    public partial class AspNetUser : ITrackable
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new List<AspNetUserClaim>();
            this.AspNetUserLogins = new List<AspNetUserLogin>();
            this.Users = new List<User>();
            this.AspNetRoles = new List<AspNetRole>();
        }

        [DataMember]
        [Display(Name = "ASP.NET User ID")]
        public string Id { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Email")]
        [StringLength(256)]
        public string Email { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Email Confirmed")]
        public bool EmailConfirmed { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Password Hash")]
        public string PasswordHash { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Security Stamp")]
        public string SecurityStamp { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Phone Number")]
        public string PhoneNumber { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Phone Number Confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Two Factor Enabled")]
        public bool TwoFactorEnabled { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Lockout End Date Utc")]
        public DateTime? LockoutEndDateUtc { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Lockout Enabled")]
        public bool LockoutEnabled { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Access Failed Count")]
        public int AccessFailedCount { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Access Failed Count")]
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Claims")]
        public List<AspNetUserClaim> AspNetUserClaims { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Logins")]
        public List<AspNetUserLogin> AspNetUserLogins { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET Users")]
        public List<User> Users { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET Roles")]
        public List<AspNetRole> AspNetRoles { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}