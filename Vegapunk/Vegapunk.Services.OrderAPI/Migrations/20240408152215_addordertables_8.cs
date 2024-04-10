using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vegapunk.Services.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class addordertables_8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrderHeaders",
                newName: "OrderStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "OrderHeaders",
                newName: "Status");
        }
    }
}
