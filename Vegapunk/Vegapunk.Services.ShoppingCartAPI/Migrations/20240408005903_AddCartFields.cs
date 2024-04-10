using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vegapunk.Services.ShoppingCartAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCartFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CartHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartHeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "CartHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CartHeaders");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartHeaders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "CartHeaders");
        }
    }
}
