using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HR.ReadModel.Context.Models
{
    public partial class HRContext : DbContext
    {
        public HRContext()
        {
        }

        public HRContext(DbContextOptions<HRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeShiftAssignment> EmployeeShiftAssignments { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ShiftPattern> ShiftPatterns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=RASHIDI-A;Database=HR;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance", "EmployeeContext");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.WorkingDayDate).HasColumnType("date");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract", "EmployeeContext");

                entity.HasIndex(e => e.EmployeeId, "IX_Contract_EmployeeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Employee_Contracts");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "EmployeeContext");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NationalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<EmployeeShiftAssignment>(entity =>
            {
                entity.ToTable("EmployeeShiftAssignments", "EmployeeContext");

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeShiftAssignments_EmployeeId");

                entity.Property(e => e.AssignmentDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeShiftAssignments)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift", "EmployeeContext");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ShiftPattern>(entity =>
            {
                entity.ToTable("ShiftPatterns", "EmployeeContext");

                entity.HasIndex(e => e.ShifId, "IX_ShiftPatterns_ShifId");

                entity.HasOne(d => d.Shif)
                    .WithMany(p => p.ShiftPatterns)
                    .HasForeignKey(d => d.ShifId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
