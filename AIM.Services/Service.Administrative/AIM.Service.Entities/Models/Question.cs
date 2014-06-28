/****************************** Module Header ******************************\
* Module Name:  Question.cs
* Project:	    A.I.M. - Automated Interview Manager
* Copyright (c) 5 Programers Of Tomorrow.
*
* Question Model.
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
    [Table("Question")]
    public partial class Question : ITrackable
    {
        public Question()
        {
            this.ApplicantQuestionAnswers = new List<ApplicantQuestionAnswer>();
            this.InterviewQuestions = new List<InterviewQuestion>();
            this.Questionnaires = new List<Questionnaire>();
        }

        // Question Primary Key
        [DataMember]
        [Display(Name = "Question ID")]
        public int QuestionId { get; set; }

        // Question Properties
        [DataMember]
        [Display(Name = "Q Json Properties")]
        public string QJsonProperties { get; set; }

        // Question Table & Column Mappings
        [DataMember]
        [Display(Name = "Questionnaire ID")]
        public int? QuestionnaireId { get; set; }

        [DataMember]
        [Display(Name = "Interview Questions ID")]
        public int? InterviewQuestionsId { get; set; }

        [DataMember]
        [Display(Name = "Applicant Question Answers")]
        public List<ApplicantQuestionAnswer> ApplicantQuestionAnswers { get; set; }

        [DataMember]
        [Display(Name = "Interview Questions")]
        public List<InterviewQuestion> InterviewQuestions { get; set; }

        [DataMember]
        [Display(Name = "Questionnaires")]
        public List<Questionnaire> Questionnaires { get; set; }

        // JSON working properties to deserialize QJsonProperties JSON String

        // JSON working property for Question Id
        [JsonProperty, DataMember]
        [Display(Name = "Question Id")]
        public int? QJsonId { get; set; }

        // JSON working property for Question Type
        [JsonProperty, DataMember]
        [Display(Name = "Question Type")]
        public TypeEnum? QJsonType { get; set; }

        // JSON working property for Question Text
        [JsonProperty, DataMember]
        [Display(Name = "Question")]
        public string QJsonText { get; set; }

        // JSON working list property for Question Options List
        [JsonProperty, DataMember]
        [Display(Name = "Question Options")]
        public IList<string> QJsonOptionList { get; set; }

        // JSON working list property for Question Answer(s) List
        [JsonProperty, DataMember]
        [Display(Name = "Desired Answer(s)")]
        public IList<string> QJsonAnswerList { get; set; }

        // Tracking Properties
        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}