using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fd.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bait",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preparation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bait", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bottomorph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: true),
                    Lng = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiraryId = table.Column<long>(type: "bigint", nullable: false),
                    FishId = table.Column<long>(type: "bigint", nullable: false),
                    BaitId = table.Column<long>(type: "bigint", nullable: true),
                    Techinique = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    FightTime = table.Column<double>(type: "float", nullable: true),
                    Release = table.Column<bool>(type: "bit", nullable: false),
                    CatchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripResult_Diary_DiaryId",
                        column: x => x.DiaryId,
                        principalTable: "Diary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SgData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SgData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SgData_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solunar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SunRise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SunSet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoonRise = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoonSet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoonFraction = table.Column<double>(type: "float", nullable: true),
                    CivilDawn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CivilDusk = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoonClosestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoonClosestTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoonClosestValue = table.Column<double>(type: "float", nullable: true),
                    MoonCurrentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoonCurrentTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoonCurrenttValue = table.Column<double>(type: "float", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solunar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solunar_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tide",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<double>(type: "float", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tide", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tide_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Whether",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirTemperature = table.Column<double>(type: "float", nullable: true),
                    Pressure = table.Column<double>(type: "float", nullable: true),
                    CloudCover = table.Column<double>(type: "float", nullable: true),
                    CurrentDirection = table.Column<double>(type: "float", nullable: true),
                    CurrentSpeed = table.Column<double>(type: "float", nullable: true),
                    Gust = table.Column<double>(type: "float", nullable: true),
                    Humidity = table.Column<double>(type: "float", nullable: true),
                    SeaLevel = table.Column<double>(type: "float", nullable: true),
                    SwellDirection = table.Column<double>(type: "float", nullable: true),
                    SwellHeight = table.Column<double>(type: "float", nullable: true),
                    SwellPeriod = table.Column<double>(type: "float", nullable: true),
                    waterTemperature = table.Column<double>(type: "float", nullable: true),
                    waveDirection = table.Column<double>(type: "float", nullable: true),
                    waveHeight = table.Column<double>(type: "float", nullable: true),
                    wavePeriod = table.Column<double>(type: "float", nullable: true),
                    windDirection = table.Column<double>(type: "float", nullable: true),
                    windSpeed = table.Column<double>(type: "float", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Whether", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Whether_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SgData_LocationId",
                table: "SgData",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Solunar_LocationId",
                table: "Solunar",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tide_LocationId",
                table: "Tide",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TripResult_DiaryId",
                table: "TripResult",
                column: "DiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Whether_LocationId",
                table: "Whether",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bait");

            migrationBuilder.DropTable(
                name: "SgData");

            migrationBuilder.DropTable(
                name: "Solunar");

            migrationBuilder.DropTable(
                name: "Tide");

            migrationBuilder.DropTable(
                name: "TripResult");

            migrationBuilder.DropTable(
                name: "Whether");

            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
