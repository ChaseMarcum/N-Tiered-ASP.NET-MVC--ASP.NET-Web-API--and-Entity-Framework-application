using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class ApplicantQuestionAnswerMap : EntityTypeConfiguration<ApplicantQuestionAnswer>
    {
        public ApplicantQuestionAnswerMap()
        {
            // Primary Key
            this.HasKey(t => t.AnswerId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ApplicantQuestionAnswers");
            this.Property(t => t.AnswerId).HasColumnName("AnswerId");
            this.Property(t => t.ApplicantId).HasColumnName("ApplicantId");
            this.Property(t => t.QuesitonId).HasColumnName("QuesitonId");
            this.Property(t => t.AnswerJsonString).HasColumnName("AnswerJsonString");

            // JSON working properites
            this.Ignore(t => t.AnsweredQJsonId);
            this.Ignore(t => t.AnsweredQJsonType);
            this.Ignore(t => t.AnsweredQJsonText);
            this.Ignore(t => t.AnsweredQJsonOptionList);
            this.Ignore(t => t.AnsweredQJsonAnswersList);

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Applicant)
                .WithMany(t => t.ApplicantQuestionAnswers)
                .HasForeignKey(d => d.ApplicantId);
            this.HasOptional(t => t.Question)
                .WithMany(t => t.ApplicantQuestionAnswers)
                .HasForeignKey(d => d.QuesitonId);
        }
    }
}