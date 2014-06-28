using AIM.Web.Admin.Models.EntityModels;
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
    public partial class JobHistory : ModelBase<JobHistory>, IEquatable<JobHistory>, ITrackable
    {
        [DataMember]
        [Display(Name = "Job History ID")]
        public int JobHistoryId
        {
            get { return _JobHistoryId; }
            set
            {
                if (Equals(value, _JobHistoryId)) return;
                _JobHistoryId = value;
                NotifyPropertyChanged(m => m.JobHistoryId);
            }
        }

        private int _JobHistoryId;

        [DataMember]
        [Display(Name = "Employer Name")]
        public string EmployerName
        {
            get { return _EmployerName; }
            set
            {
                if (Equals(value, _EmployerName)) return;
                _EmployerName = value;
                NotifyPropertyChanged(m => m.EmployerName);
            }
        }

        private string _EmployerName;

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
        [Display(Name = "Responsibilities")]
        public string Responsibilities
        {
            get { return _Responsibilities; }
            set
            {
                if (Equals(value, _Responsibilities)) return;
                _Responsibilities = value;
                NotifyPropertyChanged(m => m.Responsibilities);
            }
        }

        private string _Responsibilities;

        [DataMember]
        [Display(Name = "Supervisor")]
        public string Supervisor
        {
            get { return _Supervisor; }
            set
            {
                if (Equals(value, _Supervisor)) return;
                _Supervisor = value;
                NotifyPropertyChanged(m => m.Supervisor);
            }
        }

        private string _Supervisor;

        [DataMember]
        [Display(Name = "Starting Salary")]
        public Nullable<decimal> StartingSalary
        {
            get { return _StartingSalary; }
            set
            {
                if (Equals(value, _StartingSalary)) return;
                _StartingSalary = value;
                NotifyPropertyChanged(m => m.StartingSalary);
            }
        }

        private Nullable<decimal> _StartingSalary;

        [DataMember]
        [Display(Name = "Ending Salary")]
        public Nullable<decimal> EndingSalary
        {
            get { return _EndingSalary; }
            set
            {
                if (Equals(value, _EndingSalary)) return;
                _EndingSalary = value;
                NotifyPropertyChanged(m => m.EndingSalary);
            }
        }

        private Nullable<decimal> _EndingSalary;

        [DataMember]
        [Display(Name = "Reason For Leaving")]
        public string ReasonForLeaving
        {
            get { return _ReasonForLeaving; }
            set
            {
                if (Equals(value, _ReasonForLeaving)) return;
                _ReasonForLeaving = value;
                NotifyPropertyChanged(m => m.ReasonForLeaving);
            }
        }

        private string _ReasonForLeaving;

        [DataMember]
        [Display(Name = "Date From")]
        public Nullable<System.DateTime> DateFrom
        {
            get { return _DateFrom; }
            set
            {
                if (Equals(value, _DateFrom)) return;
                _DateFrom = value;
                NotifyPropertyChanged(m => m.DateFrom);
            }
        }

        private Nullable<System.DateTime> _DateFrom;

        [DataMember]
        [Display(Name = "Date To")]
        public Nullable<System.DateTime> DateTo
        {
            get { return _DateTo; }
            set
            {
                if (Equals(value, _DateTo)) return;
                _DateTo = value;
                NotifyPropertyChanged(m => m.DateTo);
            }
        }

        private Nullable<System.DateTime> _DateTo;

        [DataMember]
        [Display(Name = "Street")]
        public string Street
        {
            get { return _Street; }
            set
            {
                if (Equals(value, _Street)) return;
                _Street = value;
                NotifyPropertyChanged(m => m.Street);
            }
        }

        private string _Street;

        [DataMember]
        [Display(Name = "Street 2")]
        public string Street2
        {
            get { return _Street2; }
            set
            {
                if (Equals(value, _Street2)) return;
                _Street2 = value;
                NotifyPropertyChanged(m => m.Street2);
            }
        }

        private string _Street2;

        [DataMember]
        [Display(Name = "City")]
        public string City
        {
            get { return _City; }
            set
            {
                if (Equals(value, _City)) return;
                _City = value;
                NotifyPropertyChanged(m => m.City);
            }
        }

        private string _City;

        [DataMember]
        [Display(Name = "State")]
        public StateEnum? State
        {
            get { return _state; }
            set
            {
                if (Equals(value, _state)) return;
                _state = value;
                NotifyPropertyChanged(m => m.State);
            }
        }

        private StateEnum? _state;

        [DataMember]
        [Display(Name = "Zip Code")]
        public string Zip
        {
            get { return _Zip; }
            set
            {
                if (Equals(value, _Zip)) return;
                _Zip = value;
                NotifyPropertyChanged(m => m.Zip);
            }
        }

        private string _Zip;

        [DataMember]
        [Display(Name = "Phone Number")]
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if (Equals(value, _Phone)) return;
                _Phone = value;
                NotifyPropertyChanged(m => m.Phone);
            }
        }

        private string _Phone;

        [DataMember]
        [Display(Name = "Applicant ID")]
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
        [Display(Name = "Applicant")]
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

        bool IEquatable<JobHistory>.Equals(JobHistory other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}