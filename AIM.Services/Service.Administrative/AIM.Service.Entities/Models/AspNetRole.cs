/****************************** Module Header ******************************\
* Module Name:  AspNetRole.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Asp.Net Role Model.
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
    public partial class AspNetRole : ITrackable
    {
        public AspNetRole()
        {
            this.AspNetUsers = new List<AspNetUser>();
        }

        [DataMember]
        [Display(Name = "ASP.NET Role ID")]
        public string Id { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET Role Name")]
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET Users")]
        public List<AspNetUser> AspNetUsers { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}