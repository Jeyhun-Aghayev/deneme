using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hacaton.Migrations
{
    /// <inheritdoc />
    public partial class createdtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VacationLimit = table.Column<int>(type: "int", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    OverTimeHours = table.Column<int>(type: "int", nullable: true),
                    EmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Paswword = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonus = table.Column<double>(type: "float", nullable: false),
                    AttendanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employess_attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "attendances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorkyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyMaxHours = table.Column<int>(type: "int", nullable: false),
                    BonusPercentage = table.Column<double>(type: "float", nullable: true),
                    EmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contracts_employess_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "employess",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "payrolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonus = table.Column<double>(type: "float", nullable: true),
                    Deductions = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    months = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payrolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payrolls_employess_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "employess",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vacationRequests_employess_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "employess",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_attendances_EmployeesId",
                table: "attendances",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_EmployeesId",
                table: "contracts",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_employess_AttendanceId",
                table: "employess",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_payrolls_EmployeesId",
                table: "payrolls",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_vacationRequests_EmployeesId",
                table: "vacationRequests",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendances_employess_EmployeesId",
                table: "attendances",
                column: "EmployeesId",
                principalTable: "employess",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendances_employess_EmployeesId",
                table: "attendances");

            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "payrolls");

            migrationBuilder.DropTable(
                name: "vacationRequests");

            migrationBuilder.DropTable(
                name: "employess");

            migrationBuilder.DropTable(
                name: "attendances");
        }
    }
}
