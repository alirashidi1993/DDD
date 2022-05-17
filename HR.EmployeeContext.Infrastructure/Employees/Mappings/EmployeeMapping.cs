using Framework.Core.Persistence;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace HR.EmployeeContext.Infrastructure.Employees.Mappings
{
    public class EmployeeMapping : EntityMappingBase<Employee>, IEntityMapping
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            Initial(builder);
            builder.Property(i => i.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(i => i.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.NationalCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(i => i.Address)
                .IsRequired();

            builder.Property(i => i.Birthdate)
                .IsRequired()
                .HasColumnType(nameof(SqlDbType.Date));

            builder.Property(i => i.Password)
                .IsRequired()
                .HasMaxLength(16);

            builder.Property(i => i.PersonnelCode)
                .IsRequired();

            builder.OwnsMany(i => i.EmployeeShiftAssignments, map =>
            {
                map.ToTable("EmployeeShiftAssignments", "EmployeeContext").HasKey("Id");
                map.Property<long>("Id").ValueGeneratedOnAdd();
                map.WithOwner().HasForeignKey("EmployeeId");

                map.Property(i=>i.AssignmentDate).IsRequired().HasColumnType(nameof(SqlDbType.Date));
                map.Property(i => i.Archived).IsRequired();
                map.UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.OwnsMany(i => i.OverallWorkSummaries, map =>
            {
                map.ToTable("OverallWorkSummaries", "EmployeeContext").HasKey("Id");
                map.Property<long?>("Id").ValueGeneratedOnAdd();
                map.WithOwner().HasForeignKey("EmployeeId");

                map.Property(i => i.EndDate).IsRequired();
                map.Property(i => i.StartDate).IsRequired();
                map.Property(i => i.TotalWorkInHours).IsRequired();
                map.Property(i => i.TotalUndertimeInHours).IsRequired();
                map.Property(i => i.TotalOvertimeInHours).IsRequired();
                map.UsePropertyAccessMode(PropertyAccessMode.Field);
            });
        }
    }
}
