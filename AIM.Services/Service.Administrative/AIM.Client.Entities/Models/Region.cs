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
    public partial class Region : ModelBase<Region>, IEquatable<Region>, ITrackable
    {
        public Region()
        {
            this.OpenJobs = new ChangeTrackingCollection<OpenJob>();
            this.Stores = new ChangeTrackingCollection<Store>();
        }

        [DataMember]
        public int RegionId
        {
            get { return _RegionId; }
            set
            {
                if (Equals(value, _RegionId)) return;
                _RegionId = value;
                NotifyPropertyChanged(m => m.RegionId);
            }
        }

        private int _RegionId;

        [DataMember]
        public string RegionName
        {
            get { return _RegionName; }
            set
            {
                if (Equals(value, _RegionName)) return;
                _RegionName = value;
                NotifyPropertyChanged(m => m.RegionName);
            }
        }

        private string _RegionName;

        [DataMember]
        public ChangeTrackingCollection<OpenJob> OpenJobs
        {
            get { return _OpenJobs; }
            set
            {
                if (Equals(value, _OpenJobs)) return;
                _OpenJobs = value;
                NotifyPropertyChanged(m => m.OpenJobs);
            }
        }

        private ChangeTrackingCollection<OpenJob> _OpenJobs;

        [DataMember]
        public ChangeTrackingCollection<Store> Stores
        {
            get { return _Stores; }
            set
            {
                if (Equals(value, _Stores)) return;
                _Stores = value;
                NotifyPropertyChanged(m => m.Stores);
            }
        }

        private ChangeTrackingCollection<Store> _Stores;

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

        bool IEquatable<Region>.Equals(Region other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}