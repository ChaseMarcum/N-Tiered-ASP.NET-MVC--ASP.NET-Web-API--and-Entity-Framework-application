using AIM.Web.ClientApp.Models.EntityModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TrackableEntities;
using TrackableEntities.Client;

namespace AIM.Web.ClientApp.Models.EntityModels
{
    [JsonObject(IsReference = true)]
    [DataContract(IsReference = true, Namespace = "http://schemas.datacontract.org/2004/07/TrackableEntities.Models")]
    public partial class Application : ModelBase<Application>, IEquatable<Application>, ITrackable
    {
        [DataMember]
        public int ApplicationId
        {
            get { return _ApplicationId; }
            set
            {
                if (Equals(value, _ApplicationId)) return;
                _ApplicationId = value;
                NotifyPropertyChanged(m => m.ApplicationId);
            }
        }

        private int _ApplicationId;

        [DataMember]
        public int? ApplicantId
        {
            get { return _ApplicantId; }
            set
            {
                if (Equals(value, _ApplicantId)) return;
                _ApplicantId = value;
                NotifyPropertyChanged(m => m.ApplicantId);
            }
        }

        private int? _ApplicantId;

        [DataMember]
        public Nullable<System.DateTime> DateCreated
        {
            get { return _DateCreated; }
            set
            {
                if (Equals(value, _DateCreated)) return;
                _DateCreated = value;
                NotifyPropertyChanged(m => m.DateCreated);
            }
        }

        private Nullable<System.DateTime> _DateCreated;

        [DataMember]
        public string PreEmploymentStatement
        {
            get { return _PreEmploymentStatement; }
            set
            {
                if (Equals(value, _PreEmploymentStatement)) return;
                _PreEmploymentStatement = value;
                NotifyPropertyChanged(m => m.PreEmploymentStatement);
            }
        }

        private string _PreEmploymentStatement;

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
        public StatusEnum? Status
        {
            get { return _status; }
            set
            {
                if (Equals(value, _status)) return;
                _status = value;
                NotifyPropertyChanged(m => m.Status);
            }
        }

        private StatusEnum? _status;

        [DataMember]
        public string SalaryExpectation
        {
            get { return _SalaryExpectation; }
            set
            {
                if (Equals(value, _SalaryExpectation)) return;
                _SalaryExpectation = value;
                NotifyPropertyChanged(m => m.SalaryExpectation);
            }
        }

        private string _SalaryExpectation;

        [DataMember]
        public Nullable<bool> IsFullTime
        {
            get { return _IsFullTime; }
            set
            {
                if (Equals(value, _IsFullTime)) return;
                _IsFullTime = value;
                NotifyPropertyChanged(m => m.IsFullTime);
            }
        }

        private Nullable<bool> _IsFullTime;

        [DataMember]
        public Nullable<bool> IsDays
        {
            get { return _IsDays; }
            set
            {
                if (Equals(value, _IsDays)) return;
                _IsDays = value;
                NotifyPropertyChanged(m => m.IsDays);
            }
        }

        private Nullable<bool> _IsDays;

        [DataMember]
        public Nullable<bool> IsEvenings
        {
            get { return _IsEvenings; }
            set
            {
                if (Equals(value, _IsEvenings)) return;
                _IsEvenings = value;
                NotifyPropertyChanged(m => m.IsEvenings);
            }
        }

        private Nullable<bool> _IsEvenings;

        [DataMember]
        public Nullable<bool> IsWeekends
        {
            get { return _IsWeekends; }
            set
            {
                if (Equals(value, _IsWeekends)) return;
                _IsWeekends = value;
                NotifyPropertyChanged(m => m.IsWeekends);
            }
        }

        private Nullable<bool> _IsWeekends;

        [DataMember]
        public Applicant Applicant
        {
            get { return _Applicant; }
            set
            {
                if (Equals(value, _Applicant)) return;
                _Applicant = value;
                ApplicantChangeTracker = _Applicant == null ? null
                    : new ChangeTrackingCollection<Applicant> { _Applicant };
                NotifyPropertyChanged(m => m.Applicant);
            }
        }

        private Applicant _Applicant;

        private ChangeTrackingCollection<Applicant> ApplicantChangeTracker { get; set; }

        [DataMember]
        public Job Job
        {
            get { return _Job; }
            set
            {
                if (Equals(value, _Job)) return;
                _Job = value;
                JobChangeTracker = _Job == null ? null
                    : new ChangeTrackingCollection<Job> { _Job };
                NotifyPropertyChanged(m => m.Job);
            }
        }

        private Job _Job;

        private ChangeTrackingCollection<Job> JobChangeTracker { get; set; }

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

        bool IEquatable<Application>.Equals(Application other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}