using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addLoaiHangHoaField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoaiHangHoa",
                table: "HOADONHANGHOAs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LoaiHangHoa",
                table: "HANGHOAs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiHangHoa",
                table: "HOADONHANGHOAs");

            migrationBuilder.DropColumn(
                name: "LoaiHangHoa",
                table: "HANGHOAs");
        }
    }
}
