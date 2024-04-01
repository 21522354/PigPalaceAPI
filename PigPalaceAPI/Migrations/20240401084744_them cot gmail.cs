using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class themcotgmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "PigFarm",
                newName: "Gmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gmail",
                table: "PigFarm",
                newName: "Address");
        }
    }
}
