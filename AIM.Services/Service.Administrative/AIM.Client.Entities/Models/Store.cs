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
    public partial class Store : ModelBase<Store>, IEquatable<Store>, ITrackable
    {
        public Store()
        {
            this.OpenJobs = new ChangeTrackingCollection<OpenJob>();
        }

        [DataMember]
        public int StoreId
        {
            get { return _StoreId; }
            set
            {
                if (Equals(value, _StoreId)) return;
                _StoreId = value;
                NotifyPropertyChanged(m => m.StoreId);
            }
        }

        private int _StoreId;

        [DataMember]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (Equals(value, _Name)) return;
                _Name = value;
                NotifyPropertyChanged(m => m.Name);
            }
        }

        private string _Name;

        [DataMember]
        public int? RegionId
        {
            get { return _RegionId; }
            set
            {
                if (Equals(value, _RegionId)) return;
                _RegionId = value;
                NotifyPropertyChanged(m => m.RegionId);
            }
        }

        private int? _RegionId;

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
        public Region Region
        {
            get { return _Region; }
            set
            {
                if (Equals(value, _Region)) return;
                _Region = value;
                RegionChangeTracker = _Region == null ? null
                    : new ChangeTrackingCollection<Region> { _Region };
                NotifyPropertyChanged(m => m.Region);
            }
        }

        private Region _Region;

        private ChangeTrackingCollection<Region> RegionChangeTracker { get; set; }

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

        bool IEquatable<Store>.Equals(Store other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking
    }
}