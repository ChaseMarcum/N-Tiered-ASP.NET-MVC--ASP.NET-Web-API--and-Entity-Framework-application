using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using TrackableEntities;
using TrackableEntities.Client;

namespace AIM.Client.Entities.Models
{
    [JsonObject(IsReference = true)]
    [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]
    public partial class ApplicantQuestionAnswer : ModelBase<ApplicantQuestionAnswer>, IEquatable<ApplicantQuestionAnswer>, ITrackable
    {
        [DataMember]
        public int AnswerId
        {
            get { return _answerId; }
            set
            {
                if (Equals(value, _answerId)) return;
                _answerId = value;
                NotifyPropertyChanged(m => m.AnswerId);
            }
        }

        private int _answerId;

        [DataMember]
        public int? ApplicantId
        {
            get { return _applicantId; }
            set
            {
                if (Equals(value, _applicantId)) return;
                _applicantId = value;
                NotifyPropertyChanged(m => m.ApplicantId);
            }
        }

        private int? _applicantId;

        [DataMember]
        public int? QuesitonId
        {
            get { return _quesitonId; }
            set
            {
                if (Equals(value, _quesitonId)) return;
                _quesitonId = value;
                NotifyPropertyChanged(m => m.QuesitonId);
            }
        }

        private int? _quesitonId;

        [DataMember]
        public string AnswerJsonString
        {
            get { return _answerJsonString; }
            set
            {
                if (Equals(value, _answerJsonString)) return;
                _answerJsonString = value;
                NotifyPropertyChanged(m => m.AnswerJsonString);
            }
        }

        private string _answerJsonString;

        [DataMember]
        public Applicant Applicant
        {
            get { return _applicant; }
            set
            {
                if (Equals(value, _applicant)) return;
                _applicant = value;
                ApplicantChangeTracker = _applicant == null ? null
                    : new ChangeTrackingCollection<Applicant> { _applicant };
                NotifyPropertyChanged(m => m.Applicant);
            }
        }

        private Applicant _applicant;

        private ChangeTrackingCollection<Applicant> ApplicantChangeTracker { get; set; }

        [DataMember]
        public Question Question
        {
            get { return _question; }
            set
            {
                if (Equals(value, _question)) return;
                _question = value;
                QuestionChangeTracker = _question == null ? null
                    : new ChangeTrackingCollection<Question> { _question };
                NotifyPropertyChanged(m => m.Question);
            }
        }

        private Question _question;

        private ChangeTrackingCollection<Question> QuestionChangeTracker { get; set; }

        // JSON working properties to deserialize QJsonProperties JSON String

        // JSON working property for Answered Question Id
        [JsonProperty, DataMember]
        [Display(Name = "Question Id")]
        public int? AnsweredQJsonId { get; set; }

        // JSON working property for Answered Question Type
        [JsonProperty, DataMember]
        [Display(Name = "Question Type")]
        public TypeEnum? AnsweredQJsonType { get; set; }

        // JSON working property for Answered Question Text
        [JsonProperty, DataMember]
        [Display(Name = "Question")]
        public string AnsweredQJsonText { get; set; }

        // JSON working list property for Answered Question Options List
        [JsonProperty, DataMember]
        [Display(Name = "Question Options")]
        public IList<string> AnsweredQJsonOptionList { get; set; }

        // JSON working list property for Answered Question Answers List
        [JsonProperty, DataMember]
        [Display(Name = "Desired Answer(s)")]
        public IList<string> AnsweredQJsonAnswersList { get; set; }

        #region Change Tracking

        [DataMember]
        public TrackingState TrackingState { get; set; }

        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }

        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }

#pragma warning disable 414

        [JsonProperty, DataMember]
        private Guid _entityIdentity = default(Guid);

#pragma warning restore 414

        bool IEquatable<ApplicantQuestionAnswer>.Equals(ApplicantQuestionAnswer other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}