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
    public partial class Applicant : ModelBase<Applicant>, IEquatable<Applicant>, ITrackable
    {
        public Applicant()
        {
            this.ApplicantQuestionAnswers = new ChangeTrackingCollection<ApplicantQuestionAnswer>();
            this.Applications = new ChangeTrackingCollection<Application>();
            this.Educations = new ChangeTrackingCollection<Education>();
            this.JobHistories = new ChangeTrackingCollection<JobHistory>();
            this.Hours = new ChangeTrackingCollection<Hour>();
            this.References = new ChangeTrackingCollection<Reference>();
            this.Users = new ChangeTrackingCollection<User>();
        }

        [DataMember]
        public int ApplicantId
        {
            get { return _applicantId; }
            set
            {
                if (Equals(value, _applicantId)) return;
                _applicantId = value;
                NotifyPropertyChanged(m => m.ApplicantId);
            }
        }

        private int _applicantId;

        [DataMember]
        public int? EducationId
        {
            get { return _EducationId; }
            set
            {
                if (Equals(value, _EducationId)) return;
                _EducationId = value;
                NotifyPropertyChanged(m => m.EducationId);
            }
        }

        private int? _EducationId;

        [DataMember]
        public int? JobHistoryId
        {
            get { return _JobHistoryId; }
            set
            {
                if (Equals(value, _JobHistoryId)) return;
                _JobHistoryId = value;
                NotifyPropertyChanged(m => m.JobHistoryId);
            }
        }

        private int? _JobHistoryId;

        [DataMember]
        public int? ReferenceId
        {
            get { return _ReferenceId; }
            set
            {
                if (Equals(value, _ReferenceId)) return;
                _ReferenceId = value;
                NotifyPropertyChanged(m => m.ReferenceId);
            }
        }

        private int? _ReferenceId;

        [DataMember]
        public int? UserId
        {
            get { return _UserId; }
            set
            {
                if (Equals(value, _UserId)) return;
                _UserId = value;
                NotifyPropertyChanged(m => m.UserId);
            }
        }

        private int? _UserId;

        [DataMember]
        public int? ApplicationId
        {
            get { return _ApplicationId; }
            set
            {
                if (Equals(value, _ApplicationId)) return;
                _ApplicationId = value;
                NotifyPropertyChanged(m => m.ApplicationId);
            }
        }

        private int? _ApplicationId;

        [DataMember]
        public int? AnswerId
        {
            get { return _AnswerId; }
            set
            {
                if (Equals(value, _AnswerId)) return;
                _AnswerId = value;
                NotifyPropertyChanged(m => m.AnswerId);
            }
        }

        private int? _AnswerId;

        [DataMember]
        public int? HoursId
        {
            get { return _HoursId; }
            set
            {
                if (Equals(value, _HoursId)) return;
                _HoursId = value;
                NotifyPropertyChanged(m => m.HoursId);
            }
        }

        private int? _HoursId;

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
        public ChangeTrackingCollection<Application> Applications
        {
            get { return _Applications; }
            set
            {
                if (Equals(value, _Applications)) return;
                _Applications = value;
                NotifyPropertyChanged(m => m.Applications);
            }
        }

        private ChangeTrackingCollection<Application> _Applications;

        [DataMember]
        public ChangeTrackingCollection<Education> Educations
        {
            get { return _Educations; }
            set
            {
                if (Equals(value, _Educations)) return;
                _Educations = value;
                NotifyPropertyChanged(m => m.Educations);
            }
        }

        private ChangeTrackingCollection<Education> _Educations;

        [DataMember]
        public ChangeTrackingCollection<JobHistory> JobHistories
        {
            get { return _JobHistories; }
            set
            {
                if (Equals(value, _JobHistories)) return;
                _JobHistories = value;
                NotifyPropertyChanged(m => m.JobHistories);
            }
        }

        private ChangeTrackingCollection<JobHistory> _JobHistories;

        [DataMember]
        public ChangeTrackingCollection<Hour> Hours
        {
            get { return _Hours; }
            set
            {
                if (Equals(value, _Hours)) return;
                _Hours = value;
                NotifyPropertyChanged(m => m.Hours);
            }
        }

        private ChangeTrackingCollection<Hour> _Hours;

        [DataMember]
        public ChangeTrackingCollection<Reference> References
        {
            get { return _References; }
            set
            {
                if (Equals(value, _References)) return;
                _References = value;
                NotifyPropertyChanged(m => m.References);
            }
        }

        private ChangeTrackingCollection<Reference> _References;

        [DataMember]
        public ChangeTrackingCollection<User> Users
        {
            get { return _Users; }
            set
            {
                if (Equals(value, _Users)) return;
                _Users = value;
                NotifyPropertyChanged(m => m.Users);
            }
        }

        private ChangeTrackingCollection<User> _Users;

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

        bool IEquatable<Applicant>.Equals(Applicant other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}