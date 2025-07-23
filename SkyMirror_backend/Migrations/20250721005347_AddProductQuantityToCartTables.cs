using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyMirror.Migrations
{
    /// <inheritdoc />
    public partial class AddProductQuantityToCartTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productQuantity",
                table: "CartProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productQuantity",
                table: "CartProducts");
        }
    }
}
