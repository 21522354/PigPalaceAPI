using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class adjusttablefarm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "PigFarm",
                newName: "GoogleID");

            migrationBuilder.AddColumn<string>(
                name: "FBID",
                table: "PigFarm",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFromFB",
                table: "PigFarm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFromGoogle",
                table: "PigFarm",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FBID",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "IsFromFB",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "IsFromGoogle",
                table: "PigFarm");

            migrationBuilder.RenameColumn(
                name: "GoogleID",
                table: "PigFarm",
                newName: "UserName");
        }
    }
}
