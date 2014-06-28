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
    public partial class User : ModelBase<User>, IEquatable<User>, ITrackable
    {
        [DataMember]
        public int UserId
        {
            get { return _userId; }
            set
            {
                if (Equals(value, _userId)) return;
                _userId = value;
                NotifyPropertyChanged(m => m.UserId);
            }
        }

        private int _userId;

        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (Equals(value, _firstName)) return;
                _firstName = value;
                NotifyPropertyChanged(m => m.FirstName);
            }
        }

        private string _firstName;

        [DataMember]
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (Equals(value, _middleName)) return;
                _middleName = value;
                NotifyPropertyChanged(m => m.MiddleName);
            }
        }

        private string _middleName;

        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (Equals(value, _lastName)) return;
                _lastName = value;
                NotifyPropertyChanged(m => m.LastName);
            }
        }

        private string _lastName;

        [DataMember]
        public string Email
        {
            get { return _email; }
            set
            {
                if (Equals(value, _email)) return;
                _email = value;
                NotifyPropertyChanged(m => m.Email);
            }
        }

        private string _email;

        [DataMember]
        public string SocialSecurityNumber
        {
            get { return _socialSecurityNumber; }
            set
            {
                if (Equals(value, _socialSecurityNumber)) return;
                _socialSecurityNumber = value;
                NotifyPropertyChanged(m => m.SocialSecurityNumber);
            }
        }

        private string _socialSecurityNumber;

        [DataMember]
        public int? PersonalInfoId
        {
            get { return _personalInfoId; }
            set
            {
                if (Equals(value, _personalInfoId)) return;
                _personalInfoId = value;
                NotifyPropertyChanged(m => m.PersonalInfoId);
            }
        }

        private int? _personalInfoId;

        [DataMember]
        public int? ApplicantId
        {
            get { return _applicantId; }
            set
            {
                if (Equals(value, _applicantId)) return;
                _applicantId = value;
                NotifyPropertyChanged(m => m.ApplicantId);
            }
        }

        private int? _applicantId;

        [DataMember]
        public int? ApplicationId
        {
            get { return _applicationId; }
            set
            {
                if (Equals(value, _applicationId)) return;
                _applicationId = value;
                NotifyPropertyChanged(m => m.ApplicationId);
            }
        }

        private int? _applicationId;

        [DataMember]
        public int? EmployeeId
        {
            get { return _employeeId; }
            set
            {
                if (Equals(value, _employeeId)) return;
                _employeeId = value;
                NotifyPropertyChanged(m => m.EmployeeId);
            }
        }

        private int? _employeeId;

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (Equals(value, _userName)) return;
                _userName = value;
                NotifyPropertyChanged(m => m.UserName);
            }
        }

        private string _userName;

        [DataMember]
        public string Password
        {
            get { return _password; }
            set
            {
                if (Equals(value, _password)) return;
                _password = value;
                NotifyPropertyChanged(m => m.Password);
            }
        }

        private string _password;

        [DataMember]
        public string AspNetUsersId
        {
            get { return _aspNetUsersId; }
            set
            {
                if (Equals(value, _aspNetUsersId)) return;
                _aspNetUsersId = value;
                NotifyPropertyChanged(m => m.AspNetUsersId);
            }
        }

        private string _aspNetUsersId;

        [DataMember]
        public Applicant Applicant
        {
            get { return _applicant; }
            set
            {
                if (Equals(value, _applicant)) return;
                _applicant = value;
                ApplicantChangeTracker = _applicant == null ? null
                    : new ChangeTrackingCollection<Applicant> { _applicant };
                NotifyPropertyChanged(m => m.Applicant);
            }
        }

        private Applicant _applicant;

        private ChangeTrackingCollection<Applicant> ApplicantChangeTracker { get; set; }

        [DataMember]
        public AspNetUser AspNetUser
        {
            get { return _aspNetUser; }
            set
            {
                if (Equals(value, _aspNetUser)) return;
                _aspNetUser = value;
                AspNetUserChangeTracker = _aspNetUser == null ? null
                    : new ChangeTrackingCollection<AspNetUser> { _aspNetUser };
                NotifyPropertyChanged(m => m.AspNetUser);
            }
        }

        private AspNetUser _aspNetUser;

        private ChangeTrackingCollection<AspNetUser> AspNetUserChangeTracker { get; set; }

        [DataMember]
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                if (Equals(value, _employee)) return;
                _employee = value;
                EmployeeChangeTracker = _employee == null ? null
                    : new ChangeTrackingCollection<Employee> { _employee };
                NotifyPropertyChanged(m => m.Employee);
            }
        }

        private Employee _employee;

        private ChangeTrackingCollection<Employee> EmployeeChangeTracker { get; set; }

        [DataMember]
        public PersonalInfo PersonalInfo
        {
            get { return _personalInfo; }
            set
            {
                if (Equals(value, _personalInfo)) return;
                _personalInfo = value;
                PersonalInfoChangeTracker = _personalInfo == null ? null
                    : new ChangeTrackingCollection<PersonalInfo> { _personalInfo };
                NotifyPropertyChanged(m => m.PersonalInfo);
            }
        }

        private PersonalInfo _personalInfo;

        private ChangeTrackingCollection<PersonalInfo> PersonalInfoChangeTracker { get; set; }

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

        bool IEquatable<User>.Equals(User other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}