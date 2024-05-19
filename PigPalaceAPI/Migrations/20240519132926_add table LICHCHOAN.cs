using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addtableLICHCHOAN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LICHCHOANs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayChoAn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaChuong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHangHoa = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LuongThucAn1Con = table.Column<float>(type: "real", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LICHCHOANs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LICHCHOANs_CHUONGHEO_MaChuong",
                        column: x => x.MaChuong,
                        principalTable: "CHUONGHEO",
                        principalColumn: "MaChuong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LICHCHOANs_HANGHOAs_MaHangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HANGHOAs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LICHCHOANs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LICHCHOANs_MaChuong",
                table: "LICHCHOANs",
                column: "MaChuong");

            migrationBuilder.CreateIndex(
                name: "IX_LICHCHOANs_MaHangHoa",
                table: "LICHCHOANs",
                column: "MaHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_LICHCHOANs_UserID",
                table: "LICHCHOANs",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LICHCHOANs");
        }
    }
}
