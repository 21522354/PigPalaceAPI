using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addtableHeoChuongHeoLoaiHeoGiongHeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHUONGHEO",
                columns: table => new
                {
                    MaChuong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongHeo = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SucChuaToiDa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHUONGHEO", x => x.MaChuong);
                });

            migrationBuilder.CreateTable(
                name: "GIONGHEO",
                columns: table => new
                {
                    MaGiongHeo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGiongHeo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIONGHEO", x => x.MaGiongHeo);
                });

            migrationBuilder.CreateTable(
                name: "LOAIHEO",
                columns: table => new
                {
                    MaLoaiHeo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiHeo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIHEO", x => x.MaLoaiHeo);
                });

            migrationBuilder.CreateTable(
                name: "HEO",
                columns: table => new
                {
                    MaHeo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaLoaiHeo = table.Column<int>(type: "int", nullable: false),
                    MaGiongHeo = table.Column<int>(type: "int", nullable: false),
                    MaChuong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrongLuong = table.Column<float>(type: "real", nullable: false),
                    MaHeoCha = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHeoMe = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonGiaNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifyWeight = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HEO", x => x.MaHeo);
                    table.ForeignKey(
                        name: "FK_HEO_CHUONGHEO_MaChuong",
                        column: x => x.MaChuong,
                        principalTable: "CHUONGHEO",
                        principalColumn: "MaChuong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HEO_GIONGHEO_MaGiongHeo",
                        column: x => x.MaGiongHeo,
                        principalTable: "GIONGHEO",
                        principalColumn: "MaGiongHeo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HEO_LOAIHEO_MaLoaiHeo",
                        column: x => x.MaLoaiHeo,
                        principalTable: "LOAIHEO",
                        principalColumn: "MaLoaiHeo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HEO_MaChuong",
                table: "HEO",
                column: "MaChuong");

            migrationBuilder.CreateIndex(
                name: "IX_HEO_MaGiongHeo",
                table: "HEO",
                column: "MaGiongHeo");

            migrationBuilder.CreateIndex(
                name: "IX_HEO_MaLoaiHeo",
                table: "HEO",
                column: "MaLoaiHeo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HEO");

            migrationBuilder.DropTable(
                name: "CHUONGHEO");

            migrationBuilder.DropTable(
                name: "GIONGHEO");

            migrationBuilder.DropTable(
                name: "LOAIHEO");
        }
    }
}
