using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class add4tableHOADONHEOHOADONHANGHOAHANGHOACT_HOADONHEO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifyWeight",
                table: "HEO");

            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "HEO");

            migrationBuilder.AlterColumn<string>(
                name: "DonGiaNhap",
                table: "HEO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrongTrangTrai",
                table: "HEO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HANGHOAs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHangHoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TonKho = table.Column<float>(type: "real", nullable: false),
                    GiaTriToiThieu = table.Column<float>(type: "real", nullable: false),
                    TienMuaTrenMotDonVi = table.Column<float>(type: "real", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HANGHOAs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOADONHANGHOAs",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenHangHoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiaTien = table.Column<float>(type: "real", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienTrenDVT = table.Column<float>(type: "real", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    MaDoiTac = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADONHANGHOAs", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HOADONHANGHOAs_DOITACs_MaDoiTac",
                        column: x => x.MaDoiTac,
                        principalTable: "DOITACs",
                        principalColumn: "MaDoiTac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HOADONHANGHOAs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HOADONHEOs",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuong = table.Column<float>(type: "real", nullable: false),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienTrenDVT = table.Column<float>(type: "real", nullable: false),
                    MaDoiTac = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADONHEOs", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HOADONHEOs_DOITACs_MaDoiTac",
                        column: x => x.MaDoiTac,
                        principalTable: "DOITACs",
                        principalColumn: "MaDoiTac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HOADONHEOs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CT_HOADONHEOs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHeo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_HOADONHEOs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CT_HOADONHEOs_HEO_MaHeo",
                        column: x => x.MaHeo,
                        principalTable: "HEO",
                        principalColumn: "MaHeo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CT_HOADONHEOs_HOADONHEOs_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "HOADONHEOs",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOADONHEOs_MaHeo",
                table: "CT_HOADONHEOs",
                column: "MaHeo");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOADONHEOs_MaHoaDon",
                table: "CT_HOADONHEOs",
                column: "MaHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONHANGHOAs_MaDoiTac",
                table: "HOADONHANGHOAs",
                column: "MaDoiTac");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONHANGHOAs_UserID",
                table: "HOADONHANGHOAs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONHEOs_MaDoiTac",
                table: "HOADONHEOs",
                column: "MaDoiTac");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONHEOs_UserID",
                table: "HOADONHEOs",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_HOADONHEOs");

            migrationBuilder.DropTable(
                name: "HANGHOAs");

            migrationBuilder.DropTable(
                name: "HOADONHANGHOAs");

            migrationBuilder.DropTable(
                name: "HOADONHEOs");

            migrationBuilder.DropColumn(
                name: "IsTrongTrangTrai",
                table: "HEO");

            migrationBuilder.AlterColumn<string>(
                name: "DonGiaNhap",
                table: "HEO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifyWeight",
                table: "HEO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "HEO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
