using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class ReferenceMap : EntityTypeConfiguration<Reference>
    {
        public ReferenceMap()
        {
            // Primary Key
            this.HasKey(t => t.ReferenceId);

            // Properties
            this.Property(t => t.RefFullName)
                .HasMaxLength(50);

            this.Property(t => t.RefCompany)
                .HasMaxLength(50);

            this.Property(t => t.RefTitle)
                .HasMaxLength(50);

            this.Property(t => t.RefPhone)
                .HasMaxLength(13);

            // Table & Column Mappings
            this.ToTable("References");
            this.Property(t => t.ReferenceId).HasColumnName("ReferenceId");
            this.Property(t => t.RefFullName).HasColumnName("RefFullName");
            this.Property(t => t.RefCompany).HasColumnName("RefCompany");
            this.Property(t => t.RefTitle).HasColumnName("RefTitle");
            this.Property(t => t.RefPhone).HasColumnName("RefPhone");
            this.Property(t => t.ApplicantId).HasColumnName("ApplicantId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Applicant)
                .WithMany(t => t.References)
                .HasForeignKey(d => d.ApplicantId);
        }
    }
}