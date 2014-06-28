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
    public partial class AspNetUser : ModelBase<AspNetUser>, IEquatable<AspNetUser>, ITrackable
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new ChangeTrackingCollection<AspNetUserClaim>();
            this.AspNetUserLogins = new ChangeTrackingCollection<AspNetUserLogin>();
            this.Users = new ChangeTrackingCollection<User>();
            this.AspNetRoles = new ChangeTrackingCollection<AspNetRole>();
        }

        [DataMember]
        public string Id
        {
            get { return _Id; }
            set
            {
                if (Equals(value, _Id)) return;
                _Id = value;
                NotifyPropertyChanged(m => m.Id);
            }
        }

        private string _Id;

        [DataMember]
        public string Email
        {
            get { return _Email; }
            set
            {
                if (Equals(value, _Email)) return;
                _Email = value;
                NotifyPropertyChanged(m => m.Email);
            }
        }

        private string _Email;

        [DataMember]
        public bool EmailConfirmed
        {
            get { return _EmailConfirmed; }
            set
            {
                if (Equals(value, _EmailConfirmed)) return;
                _EmailConfirmed = value;
                NotifyPropertyChanged(m => m.EmailConfirmed);
            }
        }

        private bool _EmailConfirmed;

        [DataMember]
        public string PasswordHash
        {
            get { return _PasswordHash; }
            set
            {
                if (Equals(value, _PasswordHash)) return;
                _PasswordHash = value;
                NotifyPropertyChanged(m => m.PasswordHash);
            }
        }

        private string _PasswordHash;

        [DataMember]
        public string SecurityStamp
        {
            get { return _SecurityStamp; }
            set
            {
                if (Equals(value, _SecurityStamp)) return;
                _SecurityStamp = value;
                NotifyPropertyChanged(m => m.SecurityStamp);
            }
        }

        private string _SecurityStamp;

        [DataMember]
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {
                if (Equals(value, _PhoneNumber)) return;
                _PhoneNumber = value;
                NotifyPropertyChanged(m => m.PhoneNumber);
            }
        }

        private string _PhoneNumber;

        [DataMember]
        public bool PhoneNumberConfirmed
        {
            get { return _PhoneNumberConfirmed; }
            set
            {
                if (Equals(value, _PhoneNumberConfirmed)) return;
                _PhoneNumberConfirmed = value;
                NotifyPropertyChanged(m => m.PhoneNumberConfirmed);
            }
        }

        private bool _PhoneNumberConfirmed;

        [DataMember]
        public bool TwoFactorEnabled
        {
            get { return _TwoFactorEnabled; }
            set
            {
                if (Equals(value, _TwoFactorEnabled)) return;
                _TwoFactorEnabled = value;
                NotifyPropertyChanged(m => m.TwoFactorEnabled);
            }
        }

        private bool _TwoFactorEnabled;

        [DataMember]
        public Nullable<System.DateTime> LockoutEndDateUtc
        {
            get { return _LockoutEndDateUtc; }
            set
            {
                if (Equals(value, _LockoutEndDateUtc)) return;
                _LockoutEndDateUtc = value;
                NotifyPropertyChanged(m => m.LockoutEndDateUtc);
            }
        }

        private Nullable<System.DateTime> _LockoutEndDateUtc;

        [DataMember]
        public bool LockoutEnabled
        {
            get { return _LockoutEnabled; }
            set
            {
                if (Equals(value, _LockoutEnabled)) return;
                _LockoutEnabled = value;
                NotifyPropertyChanged(m => m.LockoutEnabled);
            }
        }

        private bool _LockoutEnabled;

        [DataMember]
        public int AccessFailedCount
        {
            get { return _AccessFailedCount; }
            set
            {
                if (Equals(value, _AccessFailedCount)) return;
                _AccessFailedCount = value;
                NotifyPropertyChanged(m => m.AccessFailedCount);
            }
        }

        private int _AccessFailedCount;

        [DataMember]
        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (Equals(value, _UserName)) return;
                _UserName = value;
                NotifyPropertyChanged(m => m.UserName);
            }
        }

        private string _UserName;

        [DataMember]
        public ChangeTrackingCollection<AspNetUserClaim> AspNetUserClaims
        {
            get { return _AspNetUserClaims; }
            set
            {
                if (Equals(value, _AspNetUserClaims)) return;
                _AspNetUserClaims = value;
                NotifyPropertyChanged(m => m.AspNetUserClaims);
            }
        }

        private ChangeTrackingCollection<AspNetUserClaim> _AspNetUserClaims;

        [DataMember]
        public ChangeTrackingCollection<AspNetUserLogin> AspNetUserLogins
        {
            get { return _AspNetUserLogins; }
            set
            {
                if (Equals(value, _AspNetUserLogins)) return;
                _AspNetUserLogins = value;
                NotifyPropertyChanged(m => m.AspNetUserLogins);
            }
        }

        private ChangeTrackingCollection<AspNetUserLogin> _AspNetUserLogins;

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

        [DataMember]
        public ChangeTrackingCollection<AspNetRole> AspNetRoles
        {
            get { return _AspNetRoles; }
            set
            {
                if (value != null) value.Parent = this;
                if (Equals(value, _AspNetRoles)) return;
                _AspNetRoles = value;
                NotifyPropertyChanged(m => m.AspNetRoles);
            }
        }

        private ChangeTrackingCollection<AspNetRole> _AspNetRoles;

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

        bool IEquatable<AspNetUser>.Equals(AspNetUser other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}