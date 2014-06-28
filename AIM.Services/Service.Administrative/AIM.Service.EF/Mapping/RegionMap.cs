using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            // Primary Key
            this.HasKey(t => t.RegionId);

            // Properties
            this.Property(t => t.RegionName)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Region");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.RegionName).HasColumnName("RegionName");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);
        }
    }
}