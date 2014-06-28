/****************************** Module Header ******************************\
* Module Name:  Employee.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Employee Model.
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
    [Table("Employee")]
    public partial class Employee : ITrackable
    {
        public Employee()
        {
            this.Users = new List<User>();
        }

        // Employee Primary Key
        [DataMember]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        // Employee Properties
        [DataMember]
        [Display(Name = "Permissions")]
        public PermissionsEnum? Permissions { get; set; }

        // Employee Table & Column Mappings
        [DataMember]
        [Display(Name = "Job Id")]
        public int? JobId { get; set; }

        [DataMember]
        [Display(Name = "Job")]
        public Job Job { get; set; }

        [DataMember]
        [Display(Name = "User")]
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