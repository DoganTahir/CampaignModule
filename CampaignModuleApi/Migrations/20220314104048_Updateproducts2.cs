using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignModuleApi.Migrations
{
    public partial class Updateproducts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Products_ProductId",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_ProductId",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Campaigns");

            migrationBuilder.AlterColumn<string>(
                name: "ProductCode",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductCode",
                table: "Campaigns",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "Campaigns",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ProductId",
                table: "Campaigns",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Products_ProductId",
                table: "Campaigns",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
