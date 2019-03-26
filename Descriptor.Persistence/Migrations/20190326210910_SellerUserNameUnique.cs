using Microsoft.EntityFrameworkCore.Migrations;

namespace Descriptor.Persistence.Migrations
{
    public partial class SellerUserNameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Zip",
                table: "SellerInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "EbaySellerUserName",
                table: "SellerInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SellerInfo_EbaySellerUserName",
                table: "SellerInfo",
                column: "EbaySellerUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SellerInfo_EbaySellerUserName",
                table: "SellerInfo");

            migrationBuilder.AlterColumn<int>(
                name: "Zip",
                table: "SellerInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EbaySellerUserName",
                table: "SellerInfo",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
