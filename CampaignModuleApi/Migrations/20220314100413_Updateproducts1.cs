using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignModuleApi.Migrations
{
    public partial class Updateproducts1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Campaigns",
                newName: "TotalSales");

            migrationBuilder.AddColumn<int>(
                name: "ProductStatus",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CampaignFinishDate",
                table: "Campaigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CampaignStartDate",
                table: "Campaigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CampaignStatus",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Turnover",
                table: "Campaigns",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductStatus",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CampaignFinishDate",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CampaignStartDate",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CampaignStatus",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Turnover",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "TotalSales",
                table: "Campaigns",
                newName: "Duration");
        }
    }
}
