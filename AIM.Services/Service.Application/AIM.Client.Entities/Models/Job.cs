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
    public partial class Job : ModelBase<Job>, IEquatable<Job>, ITrackable
    {
        public Job()
        {
            this.Applications = new ChangeTrackingCollection<Application>();
            this.Employees = new ChangeTrackingCollection<Employee>();
            this.OpenJobs = new ChangeTrackingCollection<OpenJob>();
        }

        [DataMember]
        public int JobId
        {
            get { return _JobId; }
            set
            {
                if (Equals(value, _JobId)) return;
                _JobId = value;
                NotifyPropertyChanged(m => m.JobId);
            }
        }

        private int _JobId;

        [DataMember]
        public string Position
        {
            get { return _Position; }
            set
            {
                if (Equals(value, _Position)) return;
                _Position = value;
                NotifyPropertyChanged(m => m.Position);
            }
        }

        private string _Position;

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set
            {
                if (Equals(value, _Description)) return;
                _Description = value;
                NotifyPropertyChanged(m => m.Description);
            }
        }

        private string _Description;

        [DataMember]
        public string FullPartTime
        {
            get { return _FullPartTime; }
            set
            {
                if (Equals(value, _FullPartTime)) return;
                _FullPartTime = value;
                NotifyPropertyChanged(m => m.FullPartTime);
            }
        }

        private string _FullPartTime;

        [DataMember]
        public string SalaryRange
        {
            get { return _SalaryRange; }
            set
            {
                if (Equals(value, _SalaryRange)) return;
                _SalaryRange = value;
                NotifyPropertyChanged(m => m.SalaryRange);
            }
        }

        private string _SalaryRange;

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
        public int? InterviewQuestionId
        {
            get { return _InterviewQuestionId; }
            set
            {
                if (Equals(value, _InterviewQuestionId)) return;
                _InterviewQuestionId = value;
                NotifyPropertyChanged(m => m.InterviewQuestionId);
            }
        }

        private int? _InterviewQuestionId;

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
        public ChangeTrackingCollection<Employee> Employees
        {
            get { return _Employees; }
            set
            {
                if (Equals(value, _Employees)) return;
                _Employees = value;
                NotifyPropertyChanged(m => m.Employees);
            }
        }

        private ChangeTrackingCollection<Employee> _Employees;

        [DataMember]
        public Hour Hour
        {
            get { return _Hour; }
            set
            {
                if (Equals(value, _Hour)) return;
                _Hour = value;
                HourChangeTracker = _Hour == null ? null
                    : new ChangeTrackingCollection<Hour> { _Hour };
                NotifyPropertyChanged(m => m.Hour);
            }
        }

        private Hour _Hour;

        private ChangeTrackingCollection<Hour> HourChangeTracker { get; set; }

        [DataMember]
        public InterviewQuestion InterviewQuestion
        {
            get { return _InterviewQuestion; }
            set
            {
                if (Equals(value, _InterviewQuestion)) return;
                _InterviewQuestion = value;
                InterviewQuestionChangeTracker = _InterviewQuestion == null ? null
                    : new ChangeTrackingCollection<InterviewQuestion> { _InterviewQuestion };
                NotifyPropertyChanged(m => m.InterviewQuestion);
            }
        }

        private InterviewQuestion _InterviewQuestion;

        private ChangeTrackingCollection<InterviewQuestion> InterviewQuestionChangeTracker { get; set; }

        [DataMember]
        public Questionnaire Questionnaire
        {
            get { return _Questionnaire; }
            set
            {
                if (Equals(value, _Questionnaire)) return;
                _Questionnaire = value;
                QuestionnaireChangeTracker = _Questionnaire == null ? null
                    : new ChangeTrackingCollection<Questionnaire> { _Questionnaire };
                NotifyPropertyChanged(m => m.Questionnaire);
            }
        }

        private Questionnaire _Questionnaire;

        private ChangeTrackingCollection<Questionnaire> QuestionnaireChangeTracker { get; set; }

        [DataMember]
        public ChangeTrackingCollection<OpenJob> OpenJobs
        {
            get { return _OpenJobs; }
            set
            {
                if (Equals(value, _OpenJobs)) return;
                _OpenJobs = value;
                NotifyPropertyChanged(m => m.OpenJobs);
            }
        }

        private ChangeTrackingCollection<OpenJob> _OpenJobs;

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

        bool IEquatable<Job>.Equals(Job other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}