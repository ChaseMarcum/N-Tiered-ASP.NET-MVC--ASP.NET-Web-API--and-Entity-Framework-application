/****************************** Module Header ******************************\
* Module Name:  PersonalInfo.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Personal Info Model.
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
    [Table("PersonalInfo")]
    public partial class PersonalInfo : ITrackable
    {
        public PersonalInfo()
        {
            this.Users = new List<User>();
        }

        [DataMember]
        [Display(Name = "")]
        [Key]
        public int PersonalInfoId { get; set; }

        [DataMember]
        [Display(Name = "Alias")]
        [StringLength(25)]
        public string Alias { get; set; }

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
        public int? State { get; set; }

        [DataMember]
        [Display(Name = "Zip")]
        [StringLength(5)]
        public string Zip { get; set; }

        [DataMember]
        [Display(Name = "Phone")]
        [StringLength(13)]
        public string Phone { get; set; }

        [DataMember]
        [Display(Name = "User Id")]
        public int? UserId { get; set; }

        [DataMember]
        [Display(Name = "Users")]
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