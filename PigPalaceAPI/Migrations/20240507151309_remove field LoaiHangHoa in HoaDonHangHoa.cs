using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class removefieldLoaiHangHoainHoaDonHangHoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoaiHoaDon",
                table: "HOADONHANGHOAs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LoaiHoaDon",
                table: "HOADONHANGHOAs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
