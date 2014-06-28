/****************************** Module Header ******************************\
* Module Name:  Region.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Region Model.
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
    [Table("Region")]
    public partial class Region : ITrackable
    {
        public Region()
        {
            this.OpenJobs = new List<OpenJob>();
            this.Stores = new List<Store>();
        }

        // Region Primary Key
        [DataMember]
        [Display(Name = "Region Id")]
        [Key]
        public int RegionId { get; set; }

        // Region Properties
        [DataMember]
        [Display(Name = "Region Name")]
        [StringLength(40)]
        public string RegionName { get; set; }

        // Region Table & Column Mappings
        [DataMember]
        [Display(Name = "Open Jobs")]
        public List<OpenJob> OpenJobs { get; set; }

        [DataMember]
        [Display(Name = "Stores")]
        public List<Store> Stores { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}