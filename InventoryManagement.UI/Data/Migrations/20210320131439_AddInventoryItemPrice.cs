using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagment.UI.Data.Migrations
{
    public partial class AddInventoryItemPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ItemPrice",
                table: "InventoryItems",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemPrice",
                table: "InventoryItems");
        }
    }
}
