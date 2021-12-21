using Microsoft.EntityFrameworkCore.Migrations;

namespace OntarioTechUniversity.Migrations
{
    public partial class migrationthree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LabNumber",
                table: "SafetyDataSheet");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "SafetyDataSheet",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certification",
                table: "Item",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNum",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MSDS",
                table: "Item",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductManual",
                table: "Item",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductOverview",
                table: "Item",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecommendedMaintenance",
                table: "Item",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WasteManagement",
                table: "Item",
                type: "varchar(500)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "SafetyDataSheet");

            migrationBuilder.DropColumn(
                name: "Certification",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemNum",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "MSDS",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ProductManual",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ProductOverview",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RecommendedMaintenance",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "WasteManagement",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "LabNumber",
                table: "SafetyDataSheet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
