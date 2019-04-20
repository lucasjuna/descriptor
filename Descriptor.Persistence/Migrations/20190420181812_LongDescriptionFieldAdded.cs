using Microsoft.EntityFrameworkCore.Migrations;

namespace Descriptor.Persistence.Migrations
{
    public partial class LongDescriptionFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EbayLongDescription",
                table: "SellerProductList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EbayLongDescription",
                table: "SellerProductList");
        }
    }
}
