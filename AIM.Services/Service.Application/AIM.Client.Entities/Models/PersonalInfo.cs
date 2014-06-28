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
    public partial class PersonalInfo : ModelBase<PersonalInfo>, IEquatable<PersonalInfo>, ITrackable
    {
        public PersonalInfo()
        {
            this.Users = new ChangeTrackingCollection<User>();
        }

        [DataMember]
        public int PersonalInfoId
        {
            get { return _PersonalInfoId; }
            set
            {
                if (Equals(value, _PersonalInfoId)) return;
                _PersonalInfoId = value;
                NotifyPropertyChanged(m => m.PersonalInfoId);
            }
        }

        private int _PersonalInfoId;

        [DataMember]
        public string Alias
        {
            get { return _Alias; }
            set
            {
                if (Equals(value, _Alias)) return;
                _Alias = value;
                NotifyPropertyChanged(m => m.Alias);
            }
        }

        private string _Alias;

        [DataMember]
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

        bool IEquatable<PersonalInfo>.Equals(PersonalInfo other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}