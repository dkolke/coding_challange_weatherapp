using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingChallangeWeatherapp.Migrations
{
    public partial class initaldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    All = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lon = table.Column<float>(type: "real", nullable: false),
                    Lat = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temp = table.Column<float>(type: "real", nullable: false),
                    Feels_Like = table.Column<float>(type: "real", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: true),
                    Humidity = table.Column<short>(type: "smallint", nullable: false),
                    Temp_Min = table.Column<float>(type: "real", nullable: false),
                    Temp_Max = table.Column<float>(type: "real", nullable: false),
                    Sea_Level = table.Column<int>(type: "int", nullable: true),
                    Grnd_Level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    One_Hour = table.Column<float>(type: "real", nullable: false),
                    Three_Hour = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    One_Hour = table.Column<float>(type: "real", nullable: false),
                    Three_Hour = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Main = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<float>(type: "real", nullable: false),
                    Deg = table.Column<short>(type: "smallint", nullable: false),
                    Gust = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visibility = table.Column<float>(type: "real", nullable: false),
                    Timezone = table.Column<int>(type: "int", nullable: false),
                    CoordId = table.Column<int>(type: "int", nullable: true),
                    WeatherId = table.Column<int>(type: "int", nullable: true),
                    MainId = table.Column<int>(type: "int", nullable: true),
                    WindId = table.Column<int>(type: "int", nullable: true),
                    CloudsId = table.Column<int>(type: "int", nullable: true),
                    RainId = table.Column<int>(type: "int", nullable: true),
                    SnowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherData_Clouds_CloudsId",
                        column: x => x.CloudsId,
                        principalTable: "Clouds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherData_Coord_CoordId",
                        column: x => x.CoordId,
                        principalTable: "Coord",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherData_Main_MainId",
                        column: x => x.MainId,
                        principalTable: "Main",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherData_Rain_RainId",
                        column: x => x.RainId,
                        principalTable: "Rain",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherData_Snow_SnowId",
                        column: x => x.SnowId,
                        principalTable: "Snow",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherData_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WeatherData_Wind_WindId",
                        column: x => x.WindId,
                        principalTable: "Wind",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_CloudsId",
                table: "WeatherData",
                column: "CloudsId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_CoordId",
                table: "WeatherData",
                column: "CoordId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_MainId",
                table: "WeatherData",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_RainId",
                table: "WeatherData",
                column: "RainId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_SnowId",
                table: "WeatherData",
                column: "SnowId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_WeatherId",
                table: "WeatherData",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_WindId",
                table: "WeatherData",
                column: "WindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherData");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coord");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Rain");

            migrationBuilder.DropTable(
                name: "Snow");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Wind");
        }
    }
}
