using Microsoft.EntityFrameworkCore.Migrations;

namespace Express.Migrations
{
    public partial class innt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    IDProvince = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentralProvince = table.Column<bool>(type: "bit", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.IDProvince);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    IDDistrict = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentralDistrict = table.Column<bool>(type: "bit", nullable: false),
                    Proid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.IDDistrict);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_Proid",
                        column: x => x.Proid,
                        principalTable: "Provinces",
                        principalColumn: "IDProvince",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDistricts",
                columns: table => new
                {
                    IDSubDistrict = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDistricts", x => x.IDSubDistrict);
                    table.ForeignKey(
                        name: "FK_SubDistricts_Districts_Disid",
                        column: x => x.Disid,
                        principalTable: "Districts",
                        principalColumn: "IDDistrict",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipCompanies",
                columns: table => new
                {
                    IDCompany = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDisid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipCompanies", x => x.IDCompany);
                    table.ForeignKey(
                        name: "FK_ShipCompanies_SubDistricts_SubDisid",
                        column: x => x.SubDisid,
                        principalTable: "SubDistricts",
                        principalColumn: "IDSubDistrict",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IDUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Authen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDisid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_Users_SubDistricts_SubDisid",
                        column: x => x.SubDisid,
                        principalTable: "SubDistricts",
                        principalColumn: "IDSubDistrict",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommissionsRules",
                columns: table => new
                {
                    IDComR = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComPerBill = table.Column<float>(type: "real", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    IDCompany = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionsRules", x => x.IDComR);
                    table.ForeignKey(
                        name: "FK_CommissionsRules_ShipCompanies_IDCompany",
                        column: x => x.IDCompany,
                        principalTable: "ShipCompanies",
                        principalColumn: "IDCompany",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipDiscounts",
                columns: table => new
                {
                    IDDis = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueDis = table.Column<float>(type: "real", nullable: false),
                    Compid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipDiscounts", x => x.IDDis);
                    table.ForeignKey(
                        name: "FK_ShipDiscounts_ShipCompanies_Compid",
                        column: x => x.Compid,
                        principalTable: "ShipCompanies",
                        principalColumn: "IDCompany",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingFees",
                columns: table => new
                {
                    IDFee = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    TGGiao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxKg = table.Column<float>(type: "real", nullable: false),
                    PricePerKg = table.Column<float>(type: "real", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    Compid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingFees", x => x.IDFee);
                    table.ForeignKey(
                        name: "FK_ShippingFees_ShipCompanies_Compid",
                        column: x => x.Compid,
                        principalTable: "ShipCompanies",
                        principalColumn: "IDCompany",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    IDBill = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SendAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiveAdd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingFee = table.Column<float>(type: "real", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    ShippingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prepair = table.Column<bool>(type: "bit", nullable: false),
                    ShipReceive = table.Column<bool>(type: "bit", nullable: false),
                    Shipping = table.Column<bool>(type: "bit", nullable: false),
                    PostReceive = table.Column<bool>(type: "bit", nullable: false),
                    ShippingToC = table.Column<bool>(type: "bit", nullable: false),
                    ShippingDone = table.Column<bool>(type: "bit", nullable: false),
                    Userid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Compid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.IDBill);
                    table.ForeignKey(
                        name: "FK_Bills_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "IDUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillStatusDetails",
                columns: table => new
                {
                    IDStatus = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prepair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipReceive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shipping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostReceive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingToC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingDone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Billid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatusDetails", x => x.IDStatus);
                    table.ForeignKey(
                        name: "FK_BillStatusDetails_Bills_Billid",
                        column: x => x.Billid,
                        principalTable: "Bills",
                        principalColumn: "IDBill",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommissionsRealTimes",
                columns: table => new
                {
                    IDComRT = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Billid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IDComR = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionsRealTimes", x => x.IDComRT);
                    table.ForeignKey(
                        name: "FK_CommissionsRealTimes_Bills_Billid",
                        column: x => x.Billid,
                        principalTable: "Bills",
                        principalColumn: "IDBill",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommissionsRealTimes_CommissionsRules_IDComR",
                        column: x => x.IDComR,
                        principalTable: "CommissionsRules",
                        principalColumn: "IDComR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_Userid",
                table: "Bills",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_BillStatusDetails_Billid",
                table: "BillStatusDetails",
                column: "Billid",
                unique: true,
                filter: "[Billid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionsRealTimes_Billid",
                table: "CommissionsRealTimes",
                column: "Billid",
                unique: true,
                filter: "[Billid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionsRealTimes_IDComR",
                table: "CommissionsRealTimes",
                column: "IDComR");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionsRules_IDCompany",
                table: "CommissionsRules",
                column: "IDCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_Proid",
                table: "Districts",
                column: "Proid");

            migrationBuilder.CreateIndex(
                name: "IX_ShipCompanies_SubDisid",
                table: "ShipCompanies",
                column: "SubDisid",
                unique: true,
                filter: "[SubDisid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShipDiscounts_Compid",
                table: "ShipDiscounts",
                column: "Compid");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingFees_Compid",
                table: "ShippingFees",
                column: "Compid");

            migrationBuilder.CreateIndex(
                name: "IX_SubDistricts_Disid",
                table: "SubDistricts",
                column: "Disid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubDisid",
                table: "Users",
                column: "SubDisid",
                unique: true,
                filter: "[SubDisid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillStatusDetails");

            migrationBuilder.DropTable(
                name: "CommissionsRealTimes");

            migrationBuilder.DropTable(
                name: "ShipDiscounts");

            migrationBuilder.DropTable(
                name: "ShippingFees");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "CommissionsRules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ShipCompanies");

            migrationBuilder.DropTable(
                name: "SubDistricts");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
