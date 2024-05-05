using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class changemaheofieldtostrig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing primary key constraint
            migrationBuilder.DropPrimaryKey("PK_HEO", "HEO");

            // Alter the column type from Guid to string
            migrationBuilder.AlterColumn<string>(
                name: "MaHeo",
                table: "HEO",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            // Add a new primary key constraint on the modified column
            migrationBuilder.AddPrimaryKey(
                name: "PK_HEO",
                table: "HEO",
                column: "MaHeo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the existing primary key constraint
        migrationBuilder.DropPrimaryKey("PK_HEO", "HEO");

        // Alter the column type back from string to Guid
        migrationBuilder.AlterColumn<Guid>(
            name: "MaHeo",
            table: "HEO",
            type: "uniqueidentifier",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)");

        // Add back the primary key constraint on the original column
        migrationBuilder.AddPrimaryKey(
            name: "PK_HEO",
            table: "HEO",
            column: "MaHeo");
        }
    }
}
