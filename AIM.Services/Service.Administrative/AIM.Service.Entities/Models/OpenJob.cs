/****************************** Module Header ******************************\
* Module Name:  OpenJob.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Open Job Model.
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
    [Table("OpenJob")]
    public partial class OpenJob : ITrackable
    {
        // Open Job Primary Key
        [DataMember]
        [Display(Name = "Open Jobs Id")]
        [Key]
        public int OpenJobsId { get; set; }

        // Open Jobs Properties
        [DataMember]
        [Display(Name = "Is Approved")]
        public bool? IsApproved { get; set; }

        // Open Job Table & Column Mappings
        [DataMember]
        [Display(Name = "Job Id")]
        public int JobId { get; set; }

        [DataMember]
        [Display(Name = "Store Id")]
        public int StoreId { get; set; }

        [DataMember]
        [Display(Name = "Region Id")]
        public int RegionId { get; set; }

        [DataMember]
        [Display(Name = "Job")]
        public Job Job { get; set; }

        [DataMember]
        [Display(Name = "Store")]
        public Store Store { get; set; }

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