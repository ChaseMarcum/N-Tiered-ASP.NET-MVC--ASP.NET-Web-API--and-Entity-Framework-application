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
    public partial class Hour : ModelBase<Hour>, IEquatable<Hour>, ITrackable
    {
        public Hour()
        {
            this.Jobs = new ChangeTrackingCollection<Job>();
        }

        [DataMember]
        public int HoursId
        {
            get { return _HoursId; }
            set
            {
                if (Equals(value, _HoursId)) return;
                _HoursId = value;
                NotifyPropertyChanged(m => m.HoursId);
            }
        }

        private int _HoursId;

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
        public Nullable<System.TimeSpan> MonOpen
        {
            get { return _MonOpen; }
            set
            {
                if (Equals(value, _MonOpen)) return;
                _MonOpen = value;
                NotifyPropertyChanged(m => m.MonOpen);
            }
        }

        private Nullable<System.TimeSpan> _MonOpen;

        [DataMember]
        public Nullable<System.TimeSpan> MonClose
        {
            get { return _MonClose; }
            set
            {
                if (Equals(value, _MonClose)) return;
                _MonClose = value;
                NotifyPropertyChanged(m => m.MonClose);
            }
        }

        private Nullable<System.TimeSpan> _MonClose;

        [DataMember]
        public Nullable<System.TimeSpan> TueOpen
        {
            get { return _TueOpen; }
            set
            {
                if (Equals(value, _TueOpen)) return;
                _TueOpen = value;
                NotifyPropertyChanged(m => m.TueOpen);
            }
        }

        private Nullable<System.TimeSpan> _TueOpen;

        [DataMember]
        public Nullable<System.TimeSpan> TueClose
        {
            get { return _TueClose; }
            set
            {
                if (Equals(value, _TueClose)) return;
                _TueClose = value;
                NotifyPropertyChanged(m => m.TueClose);
            }
        }

        private Nullable<System.TimeSpan> _TueClose;

        [DataMember]
        public Nullable<System.TimeSpan> WedOpen
        {
            get { return _WedOpen; }
            set
            {
                if (Equals(value, _WedOpen)) return;
                _WedOpen = value;
                NotifyPropertyChanged(m => m.WedOpen);
            }
        }

        private Nullable<System.TimeSpan> _WedOpen;

        [DataMember]
        public Nullable<System.TimeSpan> WedClose
        {
            get { return _WedClose; }
            set
            {
                if (Equals(value, _WedClose)) return;
                _WedClose = value;
                NotifyPropertyChanged(m => m.WedClose);
            }
        }

        private Nullable<System.TimeSpan> _WedClose;

        [DataMember]
        public Nullable<System.TimeSpan> ThursOpen
        {
            get { return _ThursOpen; }
            set
            {
                if (Equals(value, _ThursOpen)) return;
                _ThursOpen = value;
                NotifyPropertyChanged(m => m.ThursOpen);
            }
        }

        private Nullable<System.TimeSpan> _ThursOpen;

        [DataMember]
        public Nullable<System.TimeSpan> ThursClose
        {
            get { return _ThursClose; }
            set
            {
                if (Equals(value, _ThursClose)) return;
                _ThursClose = value;
                NotifyPropertyChanged(m => m.ThursClose);
            }
        }

        private Nullable<System.TimeSpan> _ThursClose;

        [DataMember]
        public Nullable<System.TimeSpan> FriOpen
        {
            get { return _FriOpen; }
            set
            {
                if (Equals(value, _FriOpen)) return;
                _FriOpen = value;
                NotifyPropertyChanged(m => m.FriOpen);
            }
        }

        private Nullable<System.TimeSpan> _FriOpen;

        [DataMember]
        public Nullable<System.TimeSpan> FriClose
        {
            get { return _FriClose; }
            set
            {
                if (Equals(value, _FriClose)) return;
                _FriClose = value;
                NotifyPropertyChanged(m => m.FriClose);
            }
        }

        private Nullable<System.TimeSpan> _FriClose;

        [DataMember]
        public Nullable<System.TimeSpan> SatOpen
        {
            get { return _SatOpen; }
            set
            {
                if (Equals(value, _SatOpen)) return;
                _SatOpen = value;
                NotifyPropertyChanged(m => m.SatOpen);
            }
        }

        private Nullable<System.TimeSpan> _SatOpen;

        [DataMember]
        public Nullable<System.TimeSpan> SatClose
        {
            get { return _SatClose; }
            set
            {
                if (Equals(value, _SatClose)) return;
                _SatClose = value;
                NotifyPropertyChanged(m => m.SatClose);
            }
        }

        private Nullable<System.TimeSpan> _SatClose;

        [DataMember]
        public Nullable<System.TimeSpan> SunOpen
        {
            get { return _SunOpen; }
            set
            {
                if (Equals(value, _SunOpen)) return;
                _SunOpen = value;
                NotifyPropertyChanged(m => m.SunOpen);
            }
        }

        private Nullable<System.TimeSpan> _SunOpen;

        [DataMember]
        public Nullable<System.TimeSpan> SunClose
        {
            get { return _SunClose; }
            set
            {
                if (Equals(value, _SunClose)) return;
                _SunClose = value;
                NotifyPropertyChanged(m => m.SunClose);
            }
        }

        private Nullable<System.TimeSpan> _SunClose;

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

        bool IEquatable<Hour>.Equals(Hour other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}