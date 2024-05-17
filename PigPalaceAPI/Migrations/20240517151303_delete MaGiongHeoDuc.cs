using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class deleteMaGiongHeoDuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LICHPHOIGIONGs_GIONGHEO_MaGiongHeo",
                table: "LICHPHOIGIONGs");

            migrationBuilder.DropIndex(
                name: "IX_LICHPHOIGIONGs_MaGiongHeo",
                table: "LICHPHOIGIONGs");

            migrationBuilder.DropColumn(
                name: "MaGiongHeo",
                table: "LICHPHOIGIONGs");

            migrationBuilder.CreateIndex(
                name: "IX_LICHPHOIGIONGs_MaGiongHeoDuc",
                table: "LICHPHOIGIONGs",
                column: "MaGiongHeoDuc");

            migrationBuilder.AddForeignKey(
                name: "FK_LICHPHOIGIONGs_GIONGHEO_MaGiongHeoDuc",
                table: "LICHPHOIGIONGs",
                column: "MaGiongHeoDuc",
                principalTable: "GIONGHEO",
                principalColumn: "MaGiongHeo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LICHPHOIGIONGs_GIONGHEO_MaGiongHeoDuc",
                table: "LICHPHOIGIONGs");

            migrationBuilder.DropIndex(
                name: "IX_LICHPHOIGIONGs_MaGiongHeoDuc",
                table: "LICHPHOIGIONGs");

            migrationBuilder.AddColumn<int>(
                name: "MaGiongHeo",
                table: "LICHPHOIGIONGs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LICHPHOIGIONGs_MaGiongHeo",
                table: "LICHPHOIGIONGs",
                column: "MaGiongHeo");

            migrationBuilder.AddForeignKey(
                name: "FK_LICHPHOIGIONGs_GIONGHEO_MaGiongHeo",
                table: "LICHPHOIGIONGs",
                column: "MaGiongHeo",
                principalTable: "GIONGHEO",
                principalColumn: "MaGiongHeo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
