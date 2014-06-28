/****************************** Module Header ******************************\
* Module Name:  Questionnaire.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Questionnaire Model.
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
    [Table("Questionnaire")]
    public partial class Questionnaire : ITrackable
    {
        public Questionnaire()
        {
            this.Jobs = new List<Job>();
            this.Questions = new List<Question>();
        }

        // Questionnaire Primary Key
        [DataMember]
        [Display(Name = "Questionnaire Id")]
        public int QuestionnaireId { get; set; }

        // Question Table & Column Mappings
        [DataMember]
        [Display(Name = "Question Id")]
        public int? QuestionId { get; set; }

        [DataMember]
        [Display(Name = "Job Id")]
        public int? JobId { get; set; }

        [DataMember]
        [Display(Name = "Job")]
        public List<Job> Jobs { get; set; }

        [DataMember]
        [Display(Name = "Questions")]
        public List<Question> Questions { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}