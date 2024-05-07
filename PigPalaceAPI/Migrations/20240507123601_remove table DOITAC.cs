using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class removetableDOITAC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HOADONHANGHOAs_DOITACs_MaDoiTac",
                table: "HOADONHANGHOAs");

            migrationBuilder.DropForeignKey(
                name: "FK_HOADONHEOs_DOITACs_MaDoiTac",
                table: "HOADONHEOs");

            migrationBuilder.DropTable(
                name: "DOITACs");

            migrationBuilder.DropIndex(
                name: "IX_HOADONHEOs_MaDoiTac",
                table: "HOADONHEOs");

            migrationBuilder.DropIndex(
                name: "IX_HOADONHANGHOAs_MaDoiTac",
                table: "HOADONHANGHOAs");

            migrationBuilder.DropColumn(
                name: "MaDoiTac",
                table: "HOADONHEOs");

            migrationBuilder.DropColumn(
                name: "MaDoiTac",
                table: "HOADONHANGHOAs");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "HOADONHEOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HOADONHEOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "HOADONHEOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenCongTy",
                table: "HOADONHEOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenKhachHang",
                table: "HOADONHEOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "HOADONHANGHOAs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HOADONHANGHOAs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SDT",
                table: "HOADONHANGHOAs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenCongTy",
                table: "HOADONHANGHOAs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenKhachHang",
                table: "HOADONHANGHOAs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "HOADONHEOs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "HOADONHEOs");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "HOADONHEOs");

            migrationBuilder.DropColumn(
                name: "TenCongTy",
                table: "HOADONHEOs");

            migrationBuilder.DropColumn(
                name: "TenKhachHang",
                table: "HOADONHEOs");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "HOADONHANGHOAs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "HOADONHANGHOAs");

            migrationBuilder.DropColumn(
                name: "SDT",
                table: "HOADONHANGHOAs");

            migrationBuilder.DropColumn(
                name: "TenCongTy",
                table: "HOADONHANGHOAs");

            migrationBuilder.DropColumn(
                name: "TenKhachHang",
                table: "HOADONHANGHOAs");

            migrationBuilder.AddColumn<int>(
                name: "MaDoiTac",
                table: "HOADONHEOs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaDoiTac",
                table: "HOADONHANGHOAs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DOITACs",
                columns: table => new
                {
                    MaDoiTac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenCongTy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDoiTac = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOITACs", x => x.MaDoiTac);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HOADONHEOs_MaDoiTac",
                table: "HOADONHEOs",
                column: "MaDoiTac");

            migrationBuilder.CreateIndex(
                name: "IX_HOADONHANGHOAs_MaDoiTac",
                table: "HOADONHANGHOAs",
                column: "MaDoiTac");

            migrationBuilder.AddForeignKey(
                name: "FK_HOADONHANGHOAs_DOITACs_MaDoiTac",
                table: "HOADONHANGHOAs",
                column: "MaDoiTac",
                principalTable: "DOITACs",
                principalColumn: "MaDoiTac",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HOADONHEOs_DOITACs_MaDoiTac",
                table: "HOADONHEOs",
                column: "MaDoiTac",
                principalTable: "DOITACs",
                principalColumn: "MaDoiTac",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
