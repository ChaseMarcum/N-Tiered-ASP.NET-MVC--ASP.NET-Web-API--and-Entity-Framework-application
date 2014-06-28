/****************************** Module Header ******************************\
* Module Name:  InterviewQuestion.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Interview Question Model.
\***************************************************************************/

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using TrackableEntities;

namespace AIM.Service.Entities.Models
{
    [JsonObject(IsReference = true)]
    [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]
    public partial class InterviewQuestion : ITrackable
    {
        public InterviewQuestion()
        {
            this.Jobs = new List<Job>();
            this.Questions = new List<Question>();
        }

        // Interview Question Primary Key
        [DataMember]
        [Display(Name = "Interview Question Id")]
        [Key]
        public int InterviewQuestionsId { get; set; }

        // Interview Question Table & Column Mappings
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
        [Display(Name = "Question")]
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