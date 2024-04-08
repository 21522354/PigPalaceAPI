using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class change_Farm_KeyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PigFarm",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PigFarm");

            migrationBuilder.AddColumn<Guid>(
                name: "FarmID",
                table: "PigFarm",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PigFarm",
                table: "PigFarm",
                column: "FarmID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PigFarm",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "FarmID",
                table: "PigFarm");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "PigFarm",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PigFarm",
                table: "PigFarm",
                column: "ID");
        }
    }
}
