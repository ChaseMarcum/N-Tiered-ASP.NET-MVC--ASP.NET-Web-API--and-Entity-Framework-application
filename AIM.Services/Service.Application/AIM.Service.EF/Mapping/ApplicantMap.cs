using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class ApplicantMap : EntityTypeConfiguration<Applicant>
    {
        public ApplicantMap()
        {
            // Primary Key
            this.HasKey(t => t.ApplicantId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Applicants");
            this.Property(t => t.ApplicantId).HasColumnName("ApplicantId");
            this.Property(t => t.EducationId).HasColumnName("EducationId");
            this.Property(t => t.JobHistoryId).HasColumnName("JobHistoryId");
            this.Property(t => t.ReferenceId).HasColumnName("ReferenceId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.ApplicationId).HasColumnName("ApplicationId");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");
            this.Property(t => t.HoursId).HasColumnName("HoursId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);
        }
    }
}