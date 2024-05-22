using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addtableLICHTIEMandCT_LICHTIEM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LICHTIEMs",
                columns: table => new
                {
                    MaLichTiem = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayTiem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaHangHoa = table.Column<int>(type: "int", nullable: false),
                    LieuLuong = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LICHTIEMs", x => x.MaLichTiem);
                    table.ForeignKey(
                        name: "FK_LICHTIEMs_HANGHOAs_MaHangHoa",
                        column: x => x.MaHangHoa,
                        principalTable: "HANGHOAs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LICHTIEMs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CT_LICHTIEMs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLich = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaHeo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_LICHTIEMs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CT_LICHTIEMs_HEO_MaHeo",
                        column: x => x.MaHeo,
                        principalTable: "HEO",
                        principalColumn: "MaHeo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CT_LICHTIEMs_LICHTIEMs_MaLich",
                        column: x => x.MaLich,
                        principalTable: "LICHTIEMs",
                        principalColumn: "MaLichTiem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_LICHTIEMs_MaHeo",
                table: "CT_LICHTIEMs",
                column: "MaHeo");

            migrationBuilder.CreateIndex(
                name: "IX_CT_LICHTIEMs_MaLich",
                table: "CT_LICHTIEMs",
                column: "MaLich");

            migrationBuilder.CreateIndex(
                name: "IX_LICHTIEMs_MaHangHoa",
                table: "LICHTIEMs",
                column: "MaHangHoa");

            migrationBuilder.CreateIndex(
                name: "IX_LICHTIEMs_UserID",
                table: "LICHTIEMs",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_LICHTIEMs");

            migrationBuilder.DropTable(
                name: "LICHTIEMs");
        }
    }
}
