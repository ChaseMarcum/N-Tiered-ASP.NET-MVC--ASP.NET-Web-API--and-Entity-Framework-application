using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class HourMap : EntityTypeConfiguration<Hour>
    {
        public HourMap()
        {
            // Primary Key
            this.HasKey(t => t.HoursId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Hours");
            this.Property(t => t.HoursId).HasColumnName("HoursId");
            this.Property(t => t.ApplicantId).HasColumnName("ApplicantId");
            this.Property(t => t.MonOpen).HasColumnName("MonOpen");
            this.Property(t => t.MonClose).HasColumnName("MonClose");
            this.Property(t => t.TueOpen).HasColumnName("TueOpen");
            this.Property(t => t.TueClose).HasColumnName("TueClose");
            this.Property(t => t.WedOpen).HasColumnName("WedOpen");
            this.Property(t => t.WedClose).HasColumnName("WedClose");
            this.Property(t => t.ThursOpen).HasColumnName("ThursOpen");
            this.Property(t => t.ThursClose).HasColumnName("ThursClose");
            this.Property(t => t.FriOpen).HasColumnName("FriOpen");
            this.Property(t => t.FriClose).HasColumnName("FriClose");
            this.Property(t => t.SatOpen).HasColumnName("SatOpen");
            this.Property(t => t.SatClose).HasColumnName("SatClose");
            this.Property(t => t.SunOpen).HasColumnName("SunOpen");
            this.Property(t => t.SunClose).HasColumnName("SunClose");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Applicant)
                .WithMany(t => t.Hours)
                .HasForeignKey(d => d.ApplicantId);
        }
    }
}