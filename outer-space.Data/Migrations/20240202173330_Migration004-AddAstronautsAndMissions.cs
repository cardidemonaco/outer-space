using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace outer_space.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration004AddAstronautsAndMissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Astronauts",
                columns: table => new
                {
                    AstronautID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AstronautNameFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AstronautNameLast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AstronautBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AstornautDeathDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astronauts", x => x.AstronautID);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MissionDateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MissionDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionID);
                });

            migrationBuilder.CreateTable(
                name: "MissionAstronauts",
                columns: table => new
                {
                    MissionID = table.Column<int>(type: "int", nullable: false),
                    AstronautID = table.Column<int>(type: "int", nullable: false),
                    MissionAstronautRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionAstronauts", x => new { x.MissionID, x.AstronautID });
                    table.ForeignKey(
                        name: "FK_MissionAstronauts_Astronauts_AstronautID",
                        column: x => x.AstronautID,
                        principalTable: "Astronauts",
                        principalColumn: "AstronautID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionAstronauts_Missions_MissionID",
                        column: x => x.MissionID,
                        principalTable: "Missions",
                        principalColumn: "MissionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionAstronauts_AstronautID",
                table: "MissionAstronauts",
                column: "AstronautID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionAstronauts");

            migrationBuilder.DropTable(
                name: "Astronauts");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
