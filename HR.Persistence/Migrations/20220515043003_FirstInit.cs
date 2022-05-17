using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.Persistence.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EmployeeContext");

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkingDayDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EntranceTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    ExitTime = table.Column<TimeSpan>(type: "Time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    PersonnelCode = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "Date", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CycleDurationInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Contracts",
                        column: x => x.EmployeeId,
                        principalSchema: "EmployeeContext",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShiftAssignments",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShiftAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeShiftAssignments_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "EmployeeContext",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OverallWorkSummaries",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalWorkInHours = table.Column<double>(type: "float", nullable: false),
                    TotalOvertimeInHours = table.Column<double>(type: "float", nullable: false),
                    TotalUndertimeInHours = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OverallWorkSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OverallWorkSummaries_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "EmployeeContext",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftPatterns",
                schema: "EmployeeContext",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOrder = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    ShifId = table.Column<Guid>(type: "UniqueIdentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftPatterns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftPatterns_Shift_ShifId",
                        column: x => x.ShifId,
                        principalSchema: "EmployeeContext",
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_EmployeeId",
                schema: "EmployeeContext",
                table: "Contract",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShiftAssignments_EmployeeId",
                schema: "EmployeeContext",
                table: "EmployeeShiftAssignments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OverallWorkSummaries_EmployeeId",
                schema: "EmployeeContext",
                table: "OverallWorkSummaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPatterns_ShifId",
                schema: "EmployeeContext",
                table: "ShiftPatterns",
                column: "ShifId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "Contract",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "EmployeeShiftAssignments",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "OverallWorkSummaries",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "ShiftPatterns",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "EmployeeContext");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "EmployeeContext");
        }
    }
}
