using System.Collections;
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
    public partial class OpenJob : ModelBase<OpenJob>, IEquatable<OpenJob>, ITrackable, IEnumerable
    {
        [DataMember]
        public int OpenJobsId
        {
            get { return _OpenJobsId; }
            set
            {
                if (Equals(value, _OpenJobsId)) return;
                _OpenJobsId = value;
                NotifyPropertyChanged(m => m.OpenJobsId);
            }
        }

        private int _OpenJobsId;

        [DataMember]
        public int JobId
        {
            get { return _JobId; }
            set
            {
                if (Equals(value, _JobId)) return;
                _JobId = value;
                NotifyPropertyChanged(m => m.JobId);
            }
        }

        private int _JobId;

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
        public Nullable<bool> IsApproved
        {
            get { return _IsApproved; }
            set
            {
                if (Equals(value, _IsApproved)) return;
                _IsApproved = value;
                NotifyPropertyChanged(m => m.IsApproved);
            }
        }

        private Nullable<bool> _IsApproved;

        [DataMember]
        public Job Job
        {
            get { return _Job; }
            set
            {
                if (Equals(value, _Job)) return;
                _Job = value;
                JobChangeTracker = _Job == null ? null
                    : new ChangeTrackingCollection<Job> { _Job };
                NotifyPropertyChanged(m => m.Job);
            }
        }

        private Job _Job;

        private ChangeTrackingCollection<Job> JobChangeTracker { get; set; }

        [DataMember]
        public Store Store
        {
            get { return _Store; }
            set
            {
                if (Equals(value, _Store)) return;
                _Store = value;
                StoreChangeTracker = _Store == null ? null
                    : new ChangeTrackingCollection<Store> { _Store };
                NotifyPropertyChanged(m => m.Store);
            }
        }

        private Store _Store;

        private ChangeTrackingCollection<Store> StoreChangeTracker { get; set; }

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

        bool IEquatable<OpenJob>.Equals(OpenJob other)
        {
            if (EntityIdentifier != default(Guid))
                return EntityIdentifier == other.EntityIdentifier;
            return false;
        }

        #endregion Change Tracking

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}