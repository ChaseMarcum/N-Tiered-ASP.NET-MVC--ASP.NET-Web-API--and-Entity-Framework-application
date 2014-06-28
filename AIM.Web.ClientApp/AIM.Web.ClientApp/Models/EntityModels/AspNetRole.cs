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
    public partial class AspNetRole : ModelBase<AspNetRole>, IEquatable<AspNetRole>, ITrackable
    {
        public AspNetRole()
        {
            this.AspNetUsers = new ChangeTrackingCollection<AspNetUser>();
        }

        [DataMember]
        public string Id
        {
            get { return _id; }
            set
            {
                if (Equals(value, _id)) return;
                _id = value;
                NotifyPropertyChanged(m => m.Id);
            }
        }

        private string _id;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (Equals(value, _name)) return;
                _name = value;
                NotifyPropertyChanged(m => m.Name);
            }
        }

        private string _name;

        [DataMember]
        public ChangeTrackingCollection<AspNetUser> AspNetUsers
        {
            get { return _AspNetUsers; }
            set
            {
                if (value != null) value.Parent = this;
                if (Equals(value, _AspNetUsers)) return;
                _AspNetUsers = value;
                NotifyPropertyChanged(m => m.AspNetUsers);
            }
        }

        private ChangeTrackingCollection<AspNetUser> _AspNetUsers;

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

        bool IEquatable<AspNetRole>.Equals(AspNetRole other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}