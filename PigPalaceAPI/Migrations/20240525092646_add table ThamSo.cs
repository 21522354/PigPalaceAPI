using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addtableThamSo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "THAMSOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrongLuongToiThieuXuatChuong = table.Column<float>(type: "real", nullable: false),
                    TrongLuongToiDaXuatChuong = table.Column<float>(type: "real", nullable: false),
                    TuoiToiThieuXuatChuong = table.Column<float>(type: "real", nullable: false),
                    TuoiToiDaXuatChuong = table.Column<float>(type: "real", nullable: false),
                    TuoiNhapDanHeoCon = table.Column<float>(type: "real", nullable: false),
                    GiaoPhoiCanHuyetToiThieu = table.Column<float>(type: "real", nullable: false),
                    TuoiPhoiGiongToiThieuHeoDuc = table.Column<float>(type: "real", nullable: false),
                    TuoiPhoiGiongToiThieuHeoCai = table.Column<float>(type: "real", nullable: false),
                    SoNgayToiThieuPhoiGiongLai = table.Column<float>(type: "real", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THAMSOS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "THAMSOS");
        }
    }
}
