using Framework.Core.Persistence;
using Framework.Persistence;
using HR.EmployeeContext.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace HR.EmployeeContext.Infrastructure.Employees.Mappings
{
    public class ContractMapping : EntityMappingBase<Contract>,IEntityMapping
    {
        public override void Configure(EntityTypeBuilder<Contract> builder)
        {
            Initial(builder);
            builder.Property(i => i.StartDate).IsRequired().HasColumnType(nameof(SqlDbType.Date));
            builder.Property(i => i.EndDate).IsRequired().HasColumnType(nameof(SqlDbType.Date));
            builder.HasOne<Employee>()
                .WithMany(i => i.Contracts)
                .HasForeignKey(i => i.EmployeeId)
                .HasConstraintName("FK_Employee_Contracts");
        }
    }
}
