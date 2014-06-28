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
    public partial class Reference : ModelBase<Reference>, IEquatable<Reference>, ITrackable
    {
        [DataMember]
        public int ReferenceId
        {
            get { return _ReferenceId; }
            set
            {
                if (Equals(value, _ReferenceId)) return;
                _ReferenceId = value;
                NotifyPropertyChanged(m => m.ReferenceId);
            }
        }

        private int _ReferenceId;

        [DataMember]
        public string RefFullName
        {
            get { return _RefFullName; }
            set
            {
                if (Equals(value, _RefFullName)) return;
                _RefFullName = value;
                NotifyPropertyChanged(m => m.RefFullName);
            }
        }

        private string _RefFullName;

        [DataMember]
        public string RefCompany
        {
            get { return _RefCompany; }
            set
            {
                if (Equals(value, _RefCompany)) return;
                _RefCompany = value;
                NotifyPropertyChanged(m => m.RefCompany);
            }
        }

        private string _RefCompany;

        [DataMember]
        public string RefTitle
        {
            get { return _RefTitle; }
            set
            {
                if (Equals(value, _RefTitle)) return;
                _RefTitle = value;
                NotifyPropertyChanged(m => m.RefTitle);
            }
        }

        private string _RefTitle;

        [DataMember]
        public string RefPhone
        {
            get { return _RefPhone; }
            set
            {
                if (Equals(value, _RefPhone)) return;
                _RefPhone = value;
                NotifyPropertyChanged(m => m.RefPhone);
            }
        }

        private string _RefPhone;

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

        bool IEquatable<Reference>.Equals(Reference other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}