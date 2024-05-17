using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAccounttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FBID",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "Gmail",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "GoogleID",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "IsFromFB",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "IsFromGoogle",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "PigFarm");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountID",
                table: "PigFarm",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFromGoogle = table.Column<bool>(type: "bit", nullable: false),
                    IsFromFB = table.Column<bool>(type: "bit", nullable: false),
                    FBID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PigFarm_AccountID",
                table: "PigFarm",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_PigFarm_Accounts_AccountID",
                table: "PigFarm",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PigFarm_Accounts_AccountID",
                table: "PigFarm");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_PigFarm_AccountID",
                table: "PigFarm");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "PigFarm");

            migrationBuilder.AddColumn<string>(
                name: "FBID",
                table: "PigFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gmail",
                table: "PigFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoogleID",
                table: "PigFarm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFromFB",
                table: "PigFarm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFromGoogle",
                table: "PigFarm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "PigFarm",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
