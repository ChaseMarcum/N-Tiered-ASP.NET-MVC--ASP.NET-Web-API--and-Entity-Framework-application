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
    public partial class AspNetUserLogin : ModelBase<AspNetUserLogin>, IEquatable<AspNetUserLogin>, ITrackable
    {
        [DataMember]
        public string LoginProvider
        {
            get { return _LoginProvider; }
            set
            {
                if (Equals(value, _LoginProvider)) return;
                _LoginProvider = value;
                NotifyPropertyChanged(m => m.LoginProvider);
            }
        }

        private string _LoginProvider;

        [DataMember]
        public string ProviderKey
        {
            get { return _ProviderKey; }
            set
            {
                if (Equals(value, _ProviderKey)) return;
                _ProviderKey = value;
                NotifyPropertyChanged(m => m.ProviderKey);
            }
        }

        private string _ProviderKey;

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

        bool IEquatable<AspNetUserLogin>.Equals(AspNetUserLogin other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}