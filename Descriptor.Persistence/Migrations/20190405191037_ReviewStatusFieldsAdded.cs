using Microsoft.EntityFrameworkCore.Migrations;

namespace Descriptor.Persistence.Migrations
{
    public partial class ReviewStatusFieldsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrentDescriptionId",
                table: "SellerProductList",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImagesStatus",
                table: "SellerProductList",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemStatus",
                table: "SellerProductList",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceStatus",
                table: "SellerProductList",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ItemReviewStatus",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductList_CurrentDescriptionId",
                table: "SellerProductList",
                column: "CurrentDescriptionId",
                unique: true,
                filter: "[CurrentDescriptionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SellerProductList_ItemReviewStatus_CurrentDescriptionId",
                table: "SellerProductList",
                column: "CurrentDescriptionId",
                principalTable: "ItemReviewStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SellerProductList_ItemReviewStatus_CurrentDescriptionId",
                table: "SellerProductList");

            migrationBuilder.DropIndex(
                name: "IX_SellerProductList_CurrentDescriptionId",
                table: "SellerProductList");

            migrationBuilder.DropColumn(
                name: "CurrentDescriptionId",
                table: "SellerProductList");

            migrationBuilder.DropColumn(
                name: "ImagesStatus",
                table: "SellerProductList");

            migrationBuilder.DropColumn(
                name: "ItemStatus",
                table: "SellerProductList");

            migrationBuilder.DropColumn(
                name: "PriceStatus",
                table: "SellerProductList");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ItemReviewStatus",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
