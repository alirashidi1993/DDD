using Framework.Core.Persistence;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Attendances;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace HR.EmployeeContext.Infrastructure.Attendances.Mappings
{
    public class AttendanceMapping : EntityMappingBase<Attendance>, IEntityMapping
    {
        public override void Configure(EntityTypeBuilder<Attendance> builder)
        {
            Initial(builder);

            builder.Property(i => i.EmployeeId).IsRequired();

            builder.Property(i=>i.WorkingDayDate)
                .HasColumnType(nameof(SqlDbType.Date))
                .IsRequired();

            builder.Property(i=>i.EntranceTime)
                .HasColumnType(nameof(SqlDbType.Time))
                .IsRequired();

            builder.Property(i => i.ExitTime)
                .HasColumnType(nameof(SqlDbType.Time))
                .IsRequired();

        }
    }
}
