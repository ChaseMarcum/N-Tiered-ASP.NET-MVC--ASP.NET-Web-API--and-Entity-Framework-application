/****************************** Module Header ******************************\
* Module Name:  Store.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Store Model.
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
    [Table("Store")]
    public partial class Store : ITrackable
    {
        public Store()
        {
            this.OpenJobs = new List<OpenJob>();
        }

        // Store Primary Key
        [DataMember]
        [Display(Name = "Store Id")]
        public int StoreId { get; set; }

        // Store Properties
        [DataMember]
        [Display(Name = "Name")]
        [StringLength(40)]
        public string Name { get; set; }

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
        public StateEnum? State { get; set; }

        [DataMember]
        [Display(Name = "Zip")]
        [StringLength(5)]
        public string Zip { get; set; }

        // Store Table & Column Mappings
        [DataMember]
        [Display(Name = "Open Jobs")]
        public List<OpenJob> OpenJobs { get; set; }

        [DataMember]
        [Display(Name = "Region Id")]
        public int? RegionId { get; set; }

        [DataMember]
        [Display(Name = "Region")]
        public Region Region { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}