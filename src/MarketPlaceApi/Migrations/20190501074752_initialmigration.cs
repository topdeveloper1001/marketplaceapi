using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketPlaceApi.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DeviceIdentifier = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: true),
                    BuildingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trends",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Interval = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    TimeOut = table.Column<int>(nullable: true),
                    TreadsNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DeviceId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ObjectType = table.Column<string>(nullable: true),
                    ObjectId = table.Column<string>(nullable: true),
                    AssetId = table.Column<string>(nullable: true),
                    Archive = table.Column<bool>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<string>(nullable: true),
                    BuildingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trend_Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: true),
                    TrendId = table.Column<Guid>(nullable: true),
                    PointCounts = table.Column<int>(nullable: true),
                    TimeOutCounts = table.Column<int>(nullable: true),
                    ErrorCount = table.Column<int>(nullable: true),
                    Notifications = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trend_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trend_Events_Trends_TrendId",
                        column: x => x.TrendId,
                        principalTable: "Trends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Point_Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PointId = table.Column<Guid>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point_Priorities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Point_Priorities_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trend_Points",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrendId = table.Column<Guid>(nullable: true),
                    PointId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trend_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trend_Points_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trend_Points_Trends_TrendId",
                        column: x => x.TrendId,
                        principalTable: "Trends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Point_Priorities_PointId",
                table: "Point_Priorities",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_DeviceId",
                table: "Points",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trend_Events_TrendId",
                table: "Trend_Events",
                column: "TrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Trend_Points_PointId",
                table: "Trend_Points",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Trend_Points_TrendId",
                table: "Trend_Points",
                column: "TrendId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Point_Priorities");

            migrationBuilder.DropTable(
                name: "Trend_Events");

            migrationBuilder.DropTable(
                name: "Trend_Points");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Trends");

            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
