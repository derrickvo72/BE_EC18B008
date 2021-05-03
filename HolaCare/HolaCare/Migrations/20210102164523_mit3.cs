using Microsoft.EntityFrameworkCore.Migrations;

namespace HolaCare.Migrations
{
    public partial class mit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDProductType",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComposerName",
                table: "CommentProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CommentProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "CommentProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ComposerName",
                table: "CommentBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CommentBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "CommentBlogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    IDProductType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledProductType = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.IDProductType);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IDProductType",
                table: "Products",
                column: "IDProductType");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_IDProductType",
                table: "Products",
                column: "IDProductType",
                principalTable: "ProductType",
                principalColumn: "IDProductType",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_IDProductType",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropIndex(
                name: "IX_Products_IDProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IDProductType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComposerName",
                table: "CommentProducts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CommentProducts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "CommentProducts");

            migrationBuilder.DropColumn(
                name: "ComposerName",
                table: "CommentBlogs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CommentBlogs");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "CommentBlogs");
        }
    }
}
