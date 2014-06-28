using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class EducationMap : EntityTypeConfiguration<Education>
    {
        public EducationMap()
        {
            // Primary Key
            this.HasKey(t => t.EducationId);

            // Properties
            this.Property(t => t.SchoolName)
                .HasMaxLength(100);

            this.Property(t => t.Degree)
                .HasMaxLength(100);

            this.Property(t => t.YearsAttended)
                .HasMaxLength(100);

            this.Property(t => t.Street)
                .HasMaxLength(100);

            this.Property(t => t.Street2)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .HasMaxLength(100);

            this.Property(t => t.Zip)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("Educations");
            this.Property(t => t.EducationId).HasColumnName("EducationId");
            this.Property(t => t.SchoolName).HasColumnName("SchoolName");
            this.Property(t => t.Degree).HasColumnName("Degree");
            this.Property(t => t.Graduated).HasColumnName("Graduated");
            this.Property(t => t.YearsAttended).HasColumnName("YearsAttended");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.Street2).HasColumnName("Street2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.ApplicantId).HasColumnName("ApplicantId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Applicant)
                .WithMany(t => t.Educations)
                .HasForeignKey(d => d.ApplicantId);
        }
    }
}