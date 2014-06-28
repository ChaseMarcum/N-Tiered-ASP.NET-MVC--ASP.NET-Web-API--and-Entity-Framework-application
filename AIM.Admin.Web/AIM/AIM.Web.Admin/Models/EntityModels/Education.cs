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
    public partial class Education : ModelBase<Education>, IEquatable<Education>, ITrackable
    {
        [DataMember]
        [Display(Name = "Education ID")]
        public int EducationId
        {
            get { return _EducationId; }
            set
            {
                if (Equals(value, _EducationId)) return;
                _EducationId = value;
                NotifyPropertyChanged(m => m.EducationId);
            }
        }

        private int _EducationId;

        [DataMember]
        [Display(Name = "School Name")]
        public string SchoolName
        {
            get { return _SchoolName; }
            set
            {
                if (Equals(value, _SchoolName)) return;
                _SchoolName = value;
                NotifyPropertyChanged(m => m.SchoolName);
            }
        }

        private string _SchoolName;

        [DataMember]
        [Display(Name = "Degree")]
        public string Degree
        {
            get { return _Degree; }
            set
            {
                if (Equals(value, _Degree)) return;
                _Degree = value;
                NotifyPropertyChanged(m => m.Degree);
            }
        }

        private string _Degree;

        [DataMember]
        [Display(Name = "Graduated")]
        public Nullable<System.DateTime> Graduated
        {
            get { return _Graduated; }
            set
            {
                if (Equals(value, _Graduated)) return;
                _Graduated = value;
                NotifyPropertyChanged(m => m.Graduated);
            }
        }

        private Nullable<System.DateTime> _Graduated;

        [DataMember]
        [Display(Name = "Years Attended")]
        public string YearsAttended
        {
            get { return _YearsAttended; }
            set
            {
                if (Equals(value, _YearsAttended)) return;
                _YearsAttended = value;
                NotifyPropertyChanged(m => m.YearsAttended);
            }
        }

        private string _YearsAttended;

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

        bool IEquatable<Education>.Equals(Education other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}