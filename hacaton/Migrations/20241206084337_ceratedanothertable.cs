using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hacaton.Migrations
{
    /// <inheritdoc />
    public partial class ceratedanothertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DepartmentId",
                table: "employess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "employess",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "employess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employess_DepartmentId1",
                table: "employess",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_employess_departments_DepartmentId1",
                table: "employess",
                column: "DepartmentId1",
                principalTable: "departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employess_departments_DepartmentId1",
                table: "employess");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropIndex(
                name: "IX_employess_DepartmentId1",
                table: "employess");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "employess");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "employess");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "employess");
        }
    }
}
