using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnIsThuanChungintoHeo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HEO_LOAIHEO_MaLoaiHeo",
                table: "HEO");

            migrationBuilder.DropTable(
                name: "LOAIHEO");

            migrationBuilder.DropIndex(
                name: "IX_HEO_MaLoaiHeo",
                table: "HEO");

            migrationBuilder.DropColumn(
                name: "MaLoaiHeo",
                table: "HEO");

            migrationBuilder.AddColumn<bool>(
                name: "IsThuanChung",
                table: "HEO",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsThuanChung",
                table: "HEO");

            migrationBuilder.AddColumn<int>(
                name: "MaLoaiHeo",
                table: "HEO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LOAIHEO",
                columns: table => new
                {
                    MaLoaiHeo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenLoaiHeo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIHEO", x => x.MaLoaiHeo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HEO_MaLoaiHeo",
                table: "HEO",
                column: "MaLoaiHeo");

            migrationBuilder.AddForeignKey(
                name: "FK_HEO_LOAIHEO_MaLoaiHeo",
                table: "HEO",
                column: "MaLoaiHeo",
                principalTable: "LOAIHEO",
                principalColumn: "MaLoaiHeo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
