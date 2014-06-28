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
    public partial class AspNetUserClaim : ModelBase<AspNetUserClaim>, IEquatable<AspNetUserClaim>, ITrackable
    {
        [DataMember]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (Equals(value, _Id)) return;
                _Id = value;
                NotifyPropertyChanged(m => m.Id);
            }
        }

        private int _Id;

        [DataMember]
        public string UserId
        {
            get { return _UserId; }
            set
            {
                if (Equals(value, _UserId)) return;
                _UserId = value;
                NotifyPropertyChanged(m => m.UserId);
            }
        }

        private string _UserId;

        [DataMember]
        public string ClaimType
        {
            get { return _ClaimType; }
            set
            {
                if (Equals(value, _ClaimType)) return;
                _ClaimType = value;
                NotifyPropertyChanged(m => m.ClaimType);
            }
        }

        private string _ClaimType;

        [DataMember]
        public string ClaimValue
        {
            get { return _ClaimValue; }
            set
            {
                if (Equals(value, _ClaimValue)) return;
                _ClaimValue = value;
                NotifyPropertyChanged(m => m.ClaimValue);
            }
        }

        private string _ClaimValue;

        [DataMember]
        public AspNetUser AspNetUser
        {
            get { return _AspNetUser; }
            set
            {
                if (Equals(value, _AspNetUser)) return;
                _AspNetUser = value;
                AspNetUserChangeTracker = _AspNetUser == null ? null
                    : new ChangeTrackingCollection<AspNetUser> { _AspNetUser };
                NotifyPropertyChanged(m => m.AspNetUser);
            }
        }

        private AspNetUser _AspNetUser;

        private ChangeTrackingCollection<AspNetUser> AspNetUserChangeTracker { get; set; }

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

        bool IEquatable<AspNetUserClaim>.Equals(AspNetUserClaim other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}