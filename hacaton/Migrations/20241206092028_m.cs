using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hacaton.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employess_departments_DepartmentId1",
                table: "employess");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId1",
                table: "employess",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_employess_departments_DepartmentId1",
                table: "employess",
                column: "DepartmentId1",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employess_departments_DepartmentId1",
                table: "employess");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId1",
                table: "employess",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_employess_departments_DepartmentId1",
                table: "employess",
                column: "DepartmentId1",
                principalTable: "departments",
                principalColumn: "Id");
        }
    }
}
