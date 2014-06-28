using System.Data.Entity.ModelConfiguration;

namespace AIM.Service.Entities.Models.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Employees");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
            this.Property(t => t.Permissions).HasColumnName("Permissions");
            this.Property(t => t.JobId).HasColumnName("JobId");

            // Tracking Properties
            this.Ignore(t => t.TrackingState);
            this.Ignore(t => t.ModifiedProperties);

            // Relationships
            this.HasOptional(t => t.Job)
                .WithMany(t => t.Employees)
                .HasForeignKey(d => d.JobId);
        }
    }
}