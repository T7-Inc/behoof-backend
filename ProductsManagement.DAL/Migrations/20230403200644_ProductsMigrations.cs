using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductsManagement.DAL.Migrations
{
    public partial class ProductsMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rulesets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    minvalue = table.Column<double>(type: "double precision", nullable: true),
                    maxvalue = table.Column<double>(type: "double precision", nullable: true),
                    outstock = table.Column<bool>(type: "boolean", nullable: true),
                    instock = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rulesets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trackedproducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    producturl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    aproximateprofit = table.Column<double>(type: "double precision", nullable: true),
                    minprice = table.Column<double>(type: "double precision", nullable: false),
                    maxprice = table.Column<double>(type: "double precision", nullable: false),
                    ratingbyreviews = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trackedproducts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productoffers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<int>(type: "integer", nullable: false),
                    shop = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    offerurl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    instock = table.Column<bool>(type: "boolean", nullable: false),
                    shippingcost = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productoffers", x => x.id);
                    table.ForeignKey(
                        name: "productoffers_productid_fkey",
                        column: x => x.productid,
                        principalTable: "trackedproducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productphotos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    trackedproductsid = table.Column<int>(type: "integer", nullable: false),
                    photourl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productphotos", x => x.id);
                    table.ForeignKey(
                        name: "productphotos_trackedproductsid_fkey",
                        column: x => x.trackedproductsid,
                        principalTable: "trackedproducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productprices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    trackedproductsid = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productprices", x => x.id);
                    table.ForeignKey(
                        name: "productprices_trackedproductsid_fkey",
                        column: x => x.trackedproductsid,
                        principalTable: "trackedproducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviewproducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrackedProductsId = table.Column<int>(type: "integer", nullable: false),
                    reviewcontent = table.Column<string>(type: "character varying", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: false),
                    UserPhoto = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewproducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_reviewproducts_trackedproducts_TrackedProductsId",
                        column: x => x.TrackedProductsId,
                        principalTable: "trackedproducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userlikedproducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    productid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userlikedproducts", x => x.id);
                    table.ForeignKey(
                        name: "userlikedproducts_productid_fkey",
                        column: x => x.productid,
                        principalTable: "trackedproducts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usertrackedproducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    trackedproductsid = table.Column<int>(type: "integer", nullable: false),
                    rulesetid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usertrackedproducts", x => x.id);
                    table.ForeignKey(
                        name: "usertrackedproducts_rulesetid_fkey",
                        column: x => x.rulesetid,
                        principalTable: "rulesets",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "usertrackedproducts_trackedproductsid_fkey",
                        column: x => x.trackedproductsid,
                        principalTable: "trackedproducts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_productoffers_productid",
                table: "productoffers",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_productphotos_trackedproductsid",
                table: "productphotos",
                column: "trackedproductsid");

            migrationBuilder.CreateIndex(
                name: "IX_productprices_trackedproductsid",
                table: "productprices",
                column: "trackedproductsid");

            migrationBuilder.CreateIndex(
                name: "IX_reviewproducts_TrackedProductsId",
                table: "reviewproducts",
                column: "TrackedProductsId");

            migrationBuilder.CreateIndex(
                name: "trackedproducts_producturl_key",
                table: "trackedproducts",
                column: "producturl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userlikedproducts_productid",
                table: "userlikedproducts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_usertrackedproducts_rulesetid",
                table: "usertrackedproducts",
                column: "rulesetid");

            migrationBuilder.CreateIndex(
                name: "IX_usertrackedproducts_trackedproductsid",
                table: "usertrackedproducts",
                column: "trackedproductsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productoffers");

            migrationBuilder.DropTable(
                name: "productphotos");

            migrationBuilder.DropTable(
                name: "productprices");

            migrationBuilder.DropTable(
                name: "reviewproducts");

            migrationBuilder.DropTable(
                name: "userlikedproducts");

            migrationBuilder.DropTable(
                name: "usertrackedproducts");

            migrationBuilder.DropTable(
                name: "rulesets");

            migrationBuilder.DropTable(
                name: "trackedproducts");
        }
    }
}
