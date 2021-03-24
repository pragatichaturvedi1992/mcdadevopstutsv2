using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagment.UI.Data.Migrations
{
    public partial class AddInventoryItemDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "InventoryItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "InventoryItems");
        }
    }
}
