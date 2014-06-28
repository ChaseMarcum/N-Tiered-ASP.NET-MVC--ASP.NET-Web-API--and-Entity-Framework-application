using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class JobHistoryMap : EntityTypeConfiguration<JobHistory>
    {
        public JobHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.JobHistoryId);

            // Properties
            this.Property(t => t.EmployerName)
                .HasMaxLength(50);

            this.Property(t => t.Position)
                .HasMaxLength(50);

            this.Property(t => t.Supervisor)
                .HasMaxLength(50);

            this.Property(t => t.Street)
                .HasMaxLength(100);

            this.Property(t => t.Street2)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.Zip)
                .HasMaxLength(5);

            this.Property(t => t.Phone)
                .HasMaxLength(13);

            // Table & Column Mappings
            this.ToTable("JobHistories");
            this.Property(t => t.JobHistoryId).HasColumnName("JobHistoryId");
            this.Property(t => t.EmployerName).HasColumnName("EmployerName");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.Responsibilities).HasColumnName("Responsibilities");
            this.Property(t => t.Supervisor).HasColumnName("Supervisor");
            this.Property(t => t.StartingSalary).HasColumnName("StartingSalary");
            this.Property(t => t.EndingSalary).HasColumnName("EndingSalary");
            this.Property(t => t.ReasonForLeaving).HasColumnName("ReasonForLeaving");
            this.Property(t => t.DateFrom).HasColumnName("DateFrom");
            this.Property(t => t.DateTo).HasColumnName("DateTo");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.Street2).HasColumnName("Street2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.ApplicantId).HasColumnName("ApplicantId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Applicant)
                .WithMany(t => t.JobHistories)
                .HasForeignKey(d => d.ApplicantId);
        }
    }
}