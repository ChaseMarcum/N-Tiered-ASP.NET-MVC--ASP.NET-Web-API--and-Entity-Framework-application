using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class PersonalInfoMap : EntityTypeConfiguration<PersonalInfo>
    {
        public PersonalInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonalInfoId);

            // Properties
            this.Property(t => t.Alias)
                .HasMaxLength(25);

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
            this.ToTable("PersonalInfoes");
            this.Property(t => t.PersonalInfoId).HasColumnName("PersonalInfoId");
            this.Property(t => t.Alias).HasColumnName("Alias");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.Street2).HasColumnName("Street2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);
        }
    }
}