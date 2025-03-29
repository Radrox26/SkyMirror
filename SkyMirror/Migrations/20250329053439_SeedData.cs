using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyMirror.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "PanelName");

            migrationBuilder.AddColumn<int>(
                name: "PowerInWatts",
                table: "Products",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PowerInWatts",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PanelName",
                table: "Products",
                newName: "Name");
        }
    }
}
