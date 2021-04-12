using Microsoft.EntityFrameworkCore.Migrations;

namespace AP_Proto.Data.Migrations
{
    public partial class Check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Asset",
                table: "Asset");

            migrationBuilder.RenameTable(
                name: "Asset",
                newName: "AssetModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetModel",
                table: "AssetModel",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetModel",
                table: "AssetModel");

            migrationBuilder.RenameTable(
                name: "AssetModel",
                newName: "Asset");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asset",
                table: "Asset",
                column: "Id");
        }
    }
}
