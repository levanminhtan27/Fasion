using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Fashion.Migrations
{
    public partial class AddColumnCustomerIdInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");
        }
    }
}
