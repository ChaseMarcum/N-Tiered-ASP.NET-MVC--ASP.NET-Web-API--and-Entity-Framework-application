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
    public partial class Question : ModelBase<Question>, IEquatable<Question>, ITrackable
    {
        public Question()
        {
            this.ApplicantQuestionAnswers = new ChangeTrackingCollection<ApplicantQuestionAnswer>();
            this.InterviewQuestions = new ChangeTrackingCollection<InterviewQuestion>();
            this.Questionnaires = new ChangeTrackingCollection<Questionnaire>();
        }

        [DataMember]
        public int QuestionId
        {
            get { return _QuestionId; }
            set
            {
                if (Equals(value, _QuestionId)) return;
                _QuestionId = value;
                NotifyPropertyChanged(m => m.QuestionId);
            }
        }

        private int _QuestionId;

        [DataMember]
        public string QJsonProperties
        {
            get { return _QJsonProperties; }
            set
            {
                if (Equals(value, _QJsonProperties)) return;
                _QJsonProperties = value;
                NotifyPropertyChanged(m => m.QJsonProperties);
            }
        }

        private string _QJsonProperties;

        [DataMember]
        public int? QuestionnaireId
        {
            get { return _QuestionnaireId; }
            set
            {
                if (Equals(value, _QuestionnaireId)) return;
                _QuestionnaireId = value;
                NotifyPropertyChanged(m => m.QuestionnaireId);
            }
        }

        private int? _QuestionnaireId;

        [DataMember]
        public int? InterviewQuestionsId
        {
            get { return _InterviewQuestionsId; }
            set
            {
                if (Equals(value, _InterviewQuestionsId)) return;
                _InterviewQuestionsId = value;
                NotifyPropertyChanged(m => m.InterviewQuestionsId);
            }
        }

        private int? _InterviewQuestionsId;

        [DataMember]
        public ChangeTrackingCollection<ApplicantQuestionAnswer> ApplicantQuestionAnswers
        {
            get { return _ApplicantQuestionAnswers; }
            set
            {
                if (Equals(value, _ApplicantQuestionAnswers)) return;
                _ApplicantQuestionAnswers = value;
                NotifyPropertyChanged(m => m.ApplicantQuestionAnswers);
            }
        }

        private ChangeTrackingCollection<ApplicantQuestionAnswer> _ApplicantQuestionAnswers;

        [DataMember]
        public ChangeTrackingCollection<InterviewQuestion> InterviewQuestions
        {
            get { return _InterviewQuestions; }
            set
            {
                if (value != null) value.Parent = this;
                if (Equals(value, _InterviewQuestions)) return;
                _InterviewQuestions = value;
                NotifyPropertyChanged(m => m.InterviewQuestions);
            }
        }

        private ChangeTrackingCollection<InterviewQuestion> _InterviewQuestions;

        [DataMember]
        public ChangeTrackingCollection<Questionnaire> Questionnaires
        {
            get { return _Questionnaires; }
            set
            {
                if (value != null) value.Parent = this;
                if (Equals(value, _Questionnaires)) return;
                _Questionnaires = value;
                NotifyPropertyChanged(m => m.Questionnaires);
            }
        }

        private ChangeTrackingCollection<Questionnaire> _Questionnaires;

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

        bool IEquatable<Question>.Equals(Question other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}