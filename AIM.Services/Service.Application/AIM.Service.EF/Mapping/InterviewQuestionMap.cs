using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class InterviewQuestionMap : EntityTypeConfiguration<InterviewQuestion>
    {
        public InterviewQuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.InterviewQuestionsId);

            // Properties
            // Table & Column Mappings
            this.ToTable("InterviewQuestions");
            this.Property(t => t.InterviewQuestionsId).HasColumnName("InterviewQuestionsId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.JobId).HasColumnName("JobId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasMany(t => t.Questions)
                .WithMany(t => t.InterviewQuestions)
                .Map(m =>
                    {
                        m.ToTable("QuestionInterviewQuestionMappings");
                        m.MapLeftKey("InterviewQuestionsId");
                        m.MapRightKey("QuestionId");
                    });
        }
    }
}