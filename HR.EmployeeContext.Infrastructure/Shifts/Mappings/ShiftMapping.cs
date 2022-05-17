using Framework.Core.Persistence;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Shifts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace HR.EmployeeContext.Infrastructure.Shifts.Mappings
{
    public class ShiftMapping : EntityMappingBase<Shift>, IEntityMapping
    {
        public override void Configure(EntityTypeBuilder<Shift> builder)
        {
            Initial(builder);
            builder.Property(i => i.CycleDurationInDays).IsRequired();
            builder.Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsMany(i => i.Patterns, map =>
            {
                map.ToTable("ShiftPatterns", "EmployeeContext").HasKey("Id");
                map.Property<long>("Id").ValueGeneratedOnAdd();
                map.WithOwner().HasForeignKey("ShifId");

                map.Property(i => i.DayOrder).IsRequired();

                map.Property(i => i.StartTime)
                .HasColumnType(nameof(SqlDbType.Time))
                .IsRequired();

                map.Property(i => i.EndTime)
                .HasColumnType(nameof(SqlDbType.Time))
                .IsRequired();

                map.UsePropertyAccessMode(PropertyAccessMode.Field);
            });
        }
    }
}
