using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class QuestionnaireMap : EntityTypeConfiguration<Questionnaire>
    {
        public QuestionnaireMap()
        {
            // Primary Key
            this.HasKey(t => t.QuestionnaireId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Questionnaires");
            this.Property(t => t.QuestionnaireId).HasColumnName("QuestionnaireId");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.JobId).HasColumnName("JobId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);
        }
    }
}