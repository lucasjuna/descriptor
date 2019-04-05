using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Descriptor.Persistence.Migrations
{
    public partial class ForeignKeysAndIndexUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "SellerProductList",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LoginName",
                table: "ReviewerInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageData",
                table: "ProductImages",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ItemId",
                table: "ItemReviewStatus",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellerProductList_ItemId",
                table: "SellerProductList",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ItemId",
                table: "ProductImages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemReviewStatus_ItemId",
                table: "ItemReviewStatus",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReviewStatus_SellerProductList_ItemId",
                table: "ItemReviewStatus",
                column: "ItemId",
                principalTable: "SellerProductList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_SellerProductList_ItemId",
                table: "ProductImages",
                column: "ItemId",
                principalTable: "SellerProductList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReviewStatus_SellerProductList_ItemId",
                table: "ItemReviewStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_SellerProductList_ItemId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_SellerProductList_ItemId",
                table: "SellerProductList");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ItemId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ItemReviewStatus_ItemId",
                table: "ItemReviewStatus");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "SellerProductList",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginName",
                table: "ReviewerInfo",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "ProductImages",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageData",
                table: "ProductImages",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "ItemReviewStatus",
                nullable: true,
                oldClrType: typeof(long));
        }
    }
}
