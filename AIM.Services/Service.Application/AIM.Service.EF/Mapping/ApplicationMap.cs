using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            // Primary Key
            this.HasKey(t => t.ApplicationId);

            // Properties
            this.Property(t => t.PreEmploymentStatement)
                .HasMaxLength(100);

            this.Property(t => t.SalaryExpectation)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Applications");
            this.Property(t => t.ApplicationId).HasColumnName("ApplicationId");
            this.Property(t => t.ApplicantId).HasColumnName("ApplicantId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.PreEmploymentStatement).HasColumnName("PreEmploymentStatement");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.SalaryExpectation).HasColumnName("SalaryExpectation");
            this.Property(t => t.IsFullTime).HasColumnName("IsFullTime");
            this.Property(t => t.IsDays).HasColumnName("IsDays");
            this.Property(t => t.IsEvenings).HasColumnName("IsEvenings");
            this.Property(t => t.IsWeekends).HasColumnName("IsWeekends");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Applicant)
                .WithMany(t => t.Applications)
                .HasForeignKey(d => d.ApplicantId);
            this.HasOptional(t => t.Job)
                .WithMany(t => t.Applications)
                .HasForeignKey(d => d.JobId);
        }
    }
}