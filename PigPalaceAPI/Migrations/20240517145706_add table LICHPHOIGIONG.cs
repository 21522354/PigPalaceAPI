using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addtableLICHPHOIGIONG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LICHPHOIGIONGs",
                columns: table => new
                {
                    MaLich = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaHeoNai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaHeoDuc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayPhoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDeDuKien = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDauThai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDeChinhThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiPhoiGiong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaGiongHeoDuc = table.Column<int>(type: "int", nullable: true),
                    MaGiongHeo = table.Column<int>(type: "int", nullable: false),
                    SoHeoCai = table.Column<int>(type: "int", nullable: true),
                    SoHeoDuc = table.Column<int>(type: "int", nullable: true),
                    SoHeoChet = table.Column<int>(type: "int", nullable: true),
                    SoHeoTat = table.Column<int>(type: "int", nullable: true),
                    NguyenNhanThatBai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CachGiaiQuyet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChuTaiSaoThatBai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LICHPHOIGIONGs", x => x.MaLich);
                    table.ForeignKey(
                        name: "FK_LICHPHOIGIONGs_GIONGHEO_MaGiongHeo",
                        column: x => x.MaGiongHeo,
                        principalTable: "GIONGHEO",
                        principalColumn: "MaGiongHeo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LICHPHOIGIONGs_HEO_MaHeoDuc",
                        column: x => x.MaHeoDuc,
                        principalTable: "HEO",
                        principalColumn: "MaHeo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LICHPHOIGIONGs_HEO_MaHeoNai",
                        column: x => x.MaHeoNai,
                        principalTable: "HEO",
                        principalColumn: "MaHeo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LICHPHOIGIONGs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LICHPHOIGIONGs_MaGiongHeo",
                table: "LICHPHOIGIONGs",
                column: "MaGiongHeo");

            migrationBuilder.CreateIndex(
                name: "IX_LICHPHOIGIONGs_MaHeoDuc",
                table: "LICHPHOIGIONGs",
                column: "MaHeoDuc");

            migrationBuilder.CreateIndex(
                name: "IX_LICHPHOIGIONGs_MaHeoNai",
                table: "LICHPHOIGIONGs",
                column: "MaHeoNai");

            migrationBuilder.CreateIndex(
                name: "IX_LICHPHOIGIONGs_UserID",
                table: "LICHPHOIGIONGs",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LICHPHOIGIONGs");
        }
    }
}
