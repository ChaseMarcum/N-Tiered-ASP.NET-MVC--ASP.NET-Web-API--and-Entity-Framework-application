using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.QuestionId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.QuestionId).HasColumnName("QuestionId");
            this.Property(t => t.QJsonProperties).HasColumnName("QJsonProperties");
            this.Property(t => t.QuestionnaireId).HasColumnName("QuestionnaireId");
            this.Property(t => t.InterviewQuestionsId).HasColumnName("InterviewQuestionsId");

            // JSON working properites
            this.Ignore(t => t.QJsonId);
            this.Ignore(t => t.QJsonType);
            this.Ignore(t => t.QJsonText);
            this.Ignore(t => t.QJsonOptionList);
            this.Ignore(t => t.QJsonAnswerList);

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasMany(t => t.Questionnaires)
                .WithMany(t => t.Questions)
                .Map(m =>
                    {
                        m.ToTable("QuestionQuestionnaires");
                        m.MapLeftKey("QuestionId");
                        m.MapRightKey("QuestionnaireId");
                    });
        }
    }
}