/****************************** Module Header ******************************\
* Module Name:  User.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* User Model.
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
    [Table("User")]
    public partial class User : ITrackable
    {
        // User Primary Key
        [DataMember]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        // User Properties
        [DataMember]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [DataMember]
        [Display(Name = "Middle Name")]
        [StringLength(25)]
        public string MiddleName { get; set; }

        [DataMember]
        [Display(Name = "Last Name")]
        [StringLength(40)]
        public string LastName { get; set; }

        [DataMember]
        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }

        [DataMember]
        [Display(Name = "Social Security Number")]
        [StringLength(11)]
        public string SocialSecurityNumber { get; set; }

        // User Table & Column Mappings
        [DataMember]
        [Display(Name = "User Name")]
        [StringLength(256)]
        public string UserName { get; set; }

        [DataMember]
        [Display(Name = "Password")]
        [StringLength(50)]
        public string Password { get; set; }

        [DataMember]
        [Display(Name = "PersonalInfo Id")]
        public int? PersonalInfoId { get; set; }

        [DataMember]
        [Display(Name = "Applicant Id")]
        public int? ApplicantId { get; set; }

        [DataMember]
        [Display(Name = "Application Id")]
        public int? ApplicationId { get; set; }

        [DataMember]
        [Display(Name = "Employee Id")]
        public int? EmployeeId { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET Users Id")]
        [StringLength(128)]
        public string AspNetUsersId { get; set; }

        [DataMember]
        [Display(Name = "Applicant")]
        public Applicant Applicant { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User")]
        public AspNetUser AspNetUser { get; set; }

        [DataMember]
        [Display(Name = "Employee")]
        public Employee Employee { get; set; }

        [DataMember]
        [Display(Name = "Personal Info")]
        public PersonalInfo PersonalInfo { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}