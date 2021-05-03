using Microsoft.EntityFrameworkCore.Migrations;

namespace HolaCare.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Points_IDUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IDUser",
                table: "Points");

            migrationBuilder.AddColumn<string>(
                name: "PointIDPoint",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PointIDPoint",
                table: "Users",
                column: "PointIDPoint");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Points_PointIDPoint",
                table: "Users",
                column: "PointIDPoint",
                principalTable: "Points",
                principalColumn: "IDPoint",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Points_PointIDPoint",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PointIDPoint",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PointIDPoint",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "IDUser",
                table: "Points",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Points_IDUser",
                table: "Users",
                column: "IDUser",
                principalTable: "Points",
                principalColumn: "IDPoint",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
