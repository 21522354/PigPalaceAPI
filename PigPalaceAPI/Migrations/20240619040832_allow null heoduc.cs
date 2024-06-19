using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class allownullheoduc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LICHPHOIGIONGs_HEO_MaHeoDuc",
                table: "LICHPHOIGIONGs");

            migrationBuilder.AlterColumn<string>(
                name: "MaHeoDuc",
                table: "LICHPHOIGIONGs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_LICHPHOIGIONGs_HEO_MaHeoDuc",
                table: "LICHPHOIGIONGs",
                column: "MaHeoDuc",
                principalTable: "HEO",
                principalColumn: "MaHeo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LICHPHOIGIONGs_HEO_MaHeoDuc",
                table: "LICHPHOIGIONGs");

            migrationBuilder.AlterColumn<string>(
                name: "MaHeoDuc",
                table: "LICHPHOIGIONGs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LICHPHOIGIONGs_HEO_MaHeoDuc",
                table: "LICHPHOIGIONGs",
                column: "MaHeoDuc",
                principalTable: "HEO",
                principalColumn: "MaHeo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
