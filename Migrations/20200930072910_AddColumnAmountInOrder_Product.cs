using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Fashion.Migrations
{
    public partial class AddColumnAmountInOrder_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Order_Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Order_Products");
        }
    }
}
