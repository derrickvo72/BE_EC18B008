using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HolaCare.Migrations
{
    public partial class migx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    IDBrand = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledBrand = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.IDBrand);
                });

            migrationBuilder.CreateTable(
                name: "IngredientDetails",
                columns: table => new
                {
                    IDIngre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameIngre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PointIngre = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientDetails", x => x.IDIngre);
                });

            migrationBuilder.CreateTable(
                name: "SkinTypes",
                columns: table => new
                {
                    IDSkinType = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameSkinType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledSkinType = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinTypes", x => x.IDSkinType);
                });

            migrationBuilder.CreateTable(
                name: "TopicBlogs",
                columns: table => new
                {
                    IDTopicBlog = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameTopicBlog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledTopicBlog = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicBlogs", x => x.IDTopicBlog);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    IDPoint = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDSkinType = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PAcneType = table.Column<float>(type: "real", nullable: false),
                    PPastUsing = table.Column<float>(type: "real", nullable: false),
                    PDailyHabit = table.Column<float>(type: "real", nullable: false),
                    PMealHabit = table.Column<float>(type: "real", nullable: false),
                    PTotal = table.Column<float>(type: "real", nullable: false),
                    IDUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.IDPoint);
                    table.ForeignKey(
                        name: "FK_Points_SkinTypes_IDSkinType",
                        column: x => x.IDSkinType,
                        principalTable: "SkinTypes",
                        principalColumn: "IDSkinType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID3code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDBrand = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IDSkintype = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PointProduct = table.Column<float>(type: "real", nullable: false),
                    DisabledPro = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID3code);
                    table.ForeignKey(
                        name: "FK_Products_Brands_IDBrand",
                        column: x => x.IDBrand,
                        principalTable: "Brands",
                        principalColumn: "IDBrand",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_SkinTypes_IDSkintype",
                        column: x => x.IDSkintype,
                        principalTable: "SkinTypes",
                        principalColumn: "IDSkinType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Male = table.Column<bool>(type: "bit", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Authen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_Users_Points_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Points",
                        principalColumn: "IDPoint",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentProducts",
                columns: table => new
                {
                    IDCmtProduct = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDProduct = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCmtProduct = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledCmtProduct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentProducts", x => x.IDCmtProduct);
                    table.ForeignKey(
                        name: "FK_CommentProducts_Products_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Products",
                        principalColumn: "ID3code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngreProducts",
                columns: table => new
                {
                    ID3code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDIngre = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngreProducts", x => new { x.IDIngre, x.ID3code });
                    table.ForeignKey(
                        name: "FK_IngreProducts_IngredientDetails_IDIngre",
                        column: x => x.IDIngre,
                        principalTable: "IngredientDetails",
                        principalColumn: "IDIngre",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngreProducts_Products_ID3code",
                        column: x => x.ID3code,
                        principalTable: "Products",
                        principalColumn: "ID3code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    IDBlog = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDTopic = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IDComposer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledBlog = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.IDBlog);
                    table.ForeignKey(
                        name: "FK_Blogs_TopicBlogs_IDTopic",
                        column: x => x.IDTopic,
                        principalTable: "TopicBlogs",
                        principalColumn: "IDTopicBlog",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_IDUser",
                        column: x => x.IDUser,
                        principalTable: "Users",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentBlogs",
                columns: table => new
                {
                    IDCmtBlog = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDBlog = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCmtBlog = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledCmtblog = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentBlogs", x => x.IDCmtBlog);
                    table.ForeignKey(
                        name: "FK_CommentBlogs_Blogs_IDBlog",
                        column: x => x.IDBlog,
                        principalTable: "Blogs",
                        principalColumn: "IDBlog",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_IDTopic",
                table: "Blogs",
                column: "IDTopic");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_IDUser",
                table: "Blogs",
                column: "IDUser");

            migrationBuilder.CreateIndex(
                name: "IX_CommentBlogs_IDBlog",
                table: "CommentBlogs",
                column: "IDBlog");

            migrationBuilder.CreateIndex(
                name: "IX_CommentProducts_IDProduct",
                table: "CommentProducts",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_IngreProducts_ID3code",
                table: "IngreProducts",
                column: "ID3code");

            migrationBuilder.CreateIndex(
                name: "IX_Points_IDSkinType",
                table: "Points",
                column: "IDSkinType");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IDBrand",
                table: "Products",
                column: "IDBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IDSkintype",
                table: "Products",
                column: "IDSkintype");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentBlogs");

            migrationBuilder.DropTable(
                name: "CommentProducts");

            migrationBuilder.DropTable(
                name: "IngreProducts");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "IngredientDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "TopicBlogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "SkinTypes");
        }
    }
}
