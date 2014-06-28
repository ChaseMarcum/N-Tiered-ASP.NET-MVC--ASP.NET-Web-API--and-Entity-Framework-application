using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(25);

            this.Property(t => t.MiddleName)
                .HasMaxLength(25);

            this.Property(t => t.LastName)
                .HasMaxLength(40);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.SocialSecurityNumber)
                .HasMaxLength(11);

            this.Property(t => t.UserName)
                .HasMaxLength(256);

            this.Property(t => t.Password)
                .HasMaxLength(50);

            this.Property(t => t.AspNetUsersId)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.SocialSecurityNumber).HasColumnName("SocialSecurityNumber");
            this.Property(t => t.PersonalInfoId).HasColumnName("PersonalInfoId");
            this.Property(t => t.ApplicantId).HasColumnName("ApplicantId");
            this.Property(t => t.ApplicationId).HasColumnName("ApplicationId");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.AspNetUsersId).HasColumnName("AspNetUsersId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Applicant)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.ApplicantId);
            this.HasOptional(t => t.AspNetUser)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.AspNetUsersId);
            this.HasOptional(t => t.Employee)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.EmployeeId);
            this.HasOptional(t => t.PersonalInfo)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.PersonalInfoId);
        }
    }
}