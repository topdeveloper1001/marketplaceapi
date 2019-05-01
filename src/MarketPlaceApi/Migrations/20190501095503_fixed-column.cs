using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlaceApi.Migrations
{
    public partial class fixedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Points");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "Points",
                nullable: true);
        }
    }
}
