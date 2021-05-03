using Microsoft.EntityFrameworkCore.Migrations;

namespace HolaCare.Migrations
{
    public partial class mit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Linktobuy",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Linktobuy",
                table: "Products");
        }
    }
}
