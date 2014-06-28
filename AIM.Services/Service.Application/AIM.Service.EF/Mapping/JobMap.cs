using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            // Primary Key
            this.HasKey(t => t.JobId);

            // Properties
            this.Property(t => t.Position)
                .HasMaxLength(150);

            this.Property(t => t.FullPartTime)
                .HasMaxLength(50);

            this.Property(t => t.SalaryRange)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Jobs");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.FullPartTime).HasColumnName("FullPartTime");
            this.Property(t => t.SalaryRange).HasColumnName("SalaryRange");
            this.Property(t => t.QuestionnaireId).HasColumnName("QuestionnaireId");
            this.Property(t => t.HoursId).HasColumnName("HoursId");
            this.Property(t => t.InterviewQuestionId).HasColumnName("InterviewQuestionId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Hour)
                .WithMany(t => t.Jobs)
                .HasForeignKey(d => d.HoursId);
            this.HasOptional(t => t.InterviewQuestion)
                .WithMany(t => t.Jobs)
                .HasForeignKey(d => d.InterviewQuestionId);
            this.HasOptional(t => t.Questionnaire)
                .WithMany(t => t.Jobs)
                .HasForeignKey(d => d.QuestionnaireId);
        }
    }
}