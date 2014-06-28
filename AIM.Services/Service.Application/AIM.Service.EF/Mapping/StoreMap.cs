using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class StoreMap : EntityTypeConfiguration<Store>
    {
        public StoreMap()
        {
            // Primary Key
            this.HasKey(t => t.StoreId);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(40);

            this.Property(t => t.Street)
                .HasMaxLength(100);

            this.Property(t => t.Street2)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Zip)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Store");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.Street2).HasColumnName("Street2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Region)
                .WithMany(t => t.Stores)
                .HasForeignKey(d => d.RegionId);
        }
    }
}