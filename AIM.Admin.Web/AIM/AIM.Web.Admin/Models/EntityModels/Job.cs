using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TrackableEntities;
using TrackableEntities.Client;
using System.ComponentModel.DataAnnotations;

namespace AIM.Web.Admin.Models.EntityModels
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
        [Display(Name = "Job ID")]
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
        [Display(Name = "Position")]
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
        [Display(Name = "Description")]
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
        [Display(Name = "Full Part Time")]
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
        [Display(Name = "Salary Range")]
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
        [Display(Name = "Questionnaire ID")]
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
        [Display(Name = "Hours ID")]
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
        [Display(Name = "Interview Question ID")]
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
        [Display(Name = "Applications")]
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
        [Display(Name = "Employees")]
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
        [Display(Name = "Hour")]
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
        [Display(Name = "Interview Question")]
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
        [Display(Name = "Questionnaire")]
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
        [Display(Name = "Open Jobs")]
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