using Microsoft.EntityFrameworkCore.Migrations;

namespace HolaCare.Migrations
{
    public partial class mit4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameProductType",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameProductType",
                table: "Products");
        }
    }
}
