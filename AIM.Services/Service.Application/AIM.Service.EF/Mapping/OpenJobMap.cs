using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class OpenJobMap : EntityTypeConfiguration<OpenJob>
    {
        public OpenJobMap()
        {
            // Primary Key
            this.HasKey(t => t.OpenJobsId);

            // Properties
            // Table & Column Mappings
            this.ToTable("OpenJobs");
            this.Property(t => t.OpenJobsId).HasColumnName("OpenJobsId");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.StoreId).HasColumnName("StoreId");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasRequired(t => t.Job)
                .WithMany(t => t.OpenJobs)
                .HasForeignKey(d => d.JobId);
            this.HasRequired(t => t.Store)
                .WithMany(t => t.OpenJobs)
                .HasForeignKey(d => d.StoreId);
            this.HasRequired(t => t.Region)
                .WithMany(t => t.OpenJobs)
                .HasForeignKey(d => d.RegionId);
        }
    }
}