using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Descriptor.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewerInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    EmpId = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LastLoginDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EbaySellerUserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    LastProcessDate = table.Column<DateTime>(nullable: false),
                    TotalItemsReviewed = table.Column<int>(nullable: false),
                    TotalItemsAccepted = table.Column<int>(nullable: false),
                    TotalItemsRejected = table.Column<int>(nullable: false),
                    TotalItemsInReview = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemReviewStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<string>(nullable: true),
                    ReviewDate = table.Column<DateTime>(nullable: false),
                    HsCode = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Method = table.Column<string>(nullable: true),
                    ReviewerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemReviewStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemReviewStatus_ReviewerInfo_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "ReviewerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerProductList",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    ItemId = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CrossboarderTrade = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    EbayDescription = table.Column<string>(nullable: true),
                    EbayBuyItNowPrice = table.Column<decimal>(nullable: false),
                    EbayViewItemUrl = table.Column<string>(nullable: true),
                    EbayItemLocation = table.Column<string>(nullable: true),
                    EbayItemPictureDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerProductList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerProductList_SellerInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "SellerInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemReviewStatus_ReviewerId",
                table: "ItemReviewStatus",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductList_UserId",
                table: "SellerProductList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemReviewStatus");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "SellerProductList");

            migrationBuilder.DropTable(
                name: "ReviewerInfo");

            migrationBuilder.DropTable(
                name: "SellerInfo");
        }
    }
}
