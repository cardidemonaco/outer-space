using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace outer_space.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration001AddGalaxies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galaxies",
                columns: table => new
                {
                    GalaxyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GalaxyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GalaxyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galaxies", x => x.GalaxyID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galaxies");
        }
    }
}
