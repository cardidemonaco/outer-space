using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace outer_space.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration002AddGalaxyDiameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalaxyDiameterInParsecs",
                table: "Galaxies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GalaxyDiameterInParsecs",
                table: "Galaxies");
        }
    }
}
