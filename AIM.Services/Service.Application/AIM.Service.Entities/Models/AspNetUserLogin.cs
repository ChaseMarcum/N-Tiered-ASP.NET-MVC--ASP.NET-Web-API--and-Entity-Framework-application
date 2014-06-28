/****************************** Module Header ******************************\
* Module Name:  AspNetUserLogin.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Asp.Net User Login Model.
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
    [Table("AspNetUserLogin")]
    public partial class AspNetUserLogin : ITrackable
    {
        [DataMember]
        [Display(Name = "ASP.NET User Login Provider")]
        [Key]
        [Column(Order = 0)]
        public string LoginProvider { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Provider Key")]
        [Key]
        [Column(Order = 1)]
        public string ProviderKey { get; set; }

        [DataMember]
        [Display(Name = "ASP.NET User Id")]
        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }

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