using Microsoft.EntityFrameworkCore.Migrations;

namespace OntarioTechUniversity.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LabNumber",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagNumber",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "TagNumber",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "LabNumber",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
