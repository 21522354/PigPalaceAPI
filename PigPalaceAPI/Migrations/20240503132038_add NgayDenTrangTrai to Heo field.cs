using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class addNgayDenTrangTraitoHeofield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NgayDenTrangTrai",
                table: "HEO",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NgayDenTrangTrai",
                table: "HEO");
        }
    }
}
