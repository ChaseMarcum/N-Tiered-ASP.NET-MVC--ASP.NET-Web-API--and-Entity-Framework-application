using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TrackableEntities;
using TrackableEntities.Client;

namespace AIM.Client.Entities.Models
{
    [JsonObject(IsReference = true)]
    [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]
    public partial class Questionnaire : ModelBase<Questionnaire>, IEquatable<Questionnaire>, ITrackable
    {
        public Questionnaire()
        {
            this.Jobs = new ChangeTrackingCollection<Job>();
            this.Questions = new ChangeTrackingCollection<Question>();
        }

        [DataMember]
        public int QuestionnaireId
        {
            get { return _QuestionnaireId; }
            set
            {
                if (Equals(value, _QuestionnaireId)) return;
                _QuestionnaireId = value;
                NotifyPropertyChanged(m => m.QuestionnaireId);
            }
        }

        private int _QuestionnaireId;

        [DataMember]
        public int? QuestionId
        {
            get { return _QuestionId; }
            set
            {
                if (Equals(value, _QuestionId)) return;
                _QuestionId = value;
                NotifyPropertyChanged(m => m.QuestionId);
            }
        }

        private int? _QuestionId;

        [DataMember]
        public int? JobId
        {
            get { return _JobId; }
            set
            {
                if (Equals(value, _JobId)) return;
                _JobId = value;
                NotifyPropertyChanged(m => m.JobId);
            }
        }

        private int? _JobId;

        [DataMember]
        public ChangeTrackingCollection<Job> Jobs
        {
            get { return _Jobs; }
            set
            {
                if (Equals(value, _Jobs)) return;
                _Jobs = value;
                NotifyPropertyChanged(m => m.Jobs);
            }
        }

        private ChangeTrackingCollection<Job> _Jobs;

        [DataMember]
        public ChangeTrackingCollection<Question> Questions
        {
            get { return _Questions; }
            set
            {
                if (value != null) value.Parent = this;
                if (Equals(value, _Questions)) return;
                _Questions = value;
                NotifyPropertyChanged(m => m.Questions);
            }
        }

        private ChangeTrackingCollection<Question> _Questions;

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

        bool IEquatable<Questionnaire>.Equals(Questionnaire other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}