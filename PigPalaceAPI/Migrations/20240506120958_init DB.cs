using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHUONGHEO",
                columns: table => new
                {
                    MaChuong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongHeo = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SucChuaToiDa = table.Column<int>(type: "int", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHUONGHEO", x => x.MaChuong);
                });

            migrationBuilder.CreateTable(
                name: "DOITACs",
                columns: table => new
                {
                    MaDoiTac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCongTy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenDoiTac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOITACs", x => x.MaDoiTac);
                });

            migrationBuilder.CreateTable(
                name: "GIONGHEO",
                columns: table => new
                {
                    MaGiongHeo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGiongHeo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIONGHEO", x => x.MaGiongHeo);
                });

            migrationBuilder.CreateTable(
                name: "LOAIHEO",
                columns: table => new
                {
                    MaLoaiHeo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiHeo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAIHEO", x => x.MaLoaiHeo);
                });

            migrationBuilder.CreateTable(
                name: "PigFarm",
                columns: table => new
                {
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFromGoogle = table.Column<bool>(type: "bit", nullable: false),
                    IsFromFB = table.Column<bool>(type: "bit", nullable: false),
                    FBID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PigFarm", x => x.FarmID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicSalary = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "HEO",
                columns: table => new
                {
                    MaHeo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLoaiHeo = table.Column<int>(type: "int", nullable: false),
                    MaGiongHeo = table.Column<int>(type: "int", nullable: false),
                    MaChuong = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrongLuong = table.Column<float>(type: "real", nullable: false),
                    MaHeoCha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaHeoMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonGiaNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifyWeight = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayDenTrangTrai = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HEO", x => x.MaHeo);
                    table.ForeignKey(
                        name: "FK_HEO_CHUONGHEO_MaChuong",
                        column: x => x.MaChuong,
                        principalTable: "CHUONGHEO",
                        principalColumn: "MaChuong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HEO_GIONGHEO_MaGiongHeo",
                        column: x => x.MaGiongHeo,
                        principalTable: "GIONGHEO",
                        principalColumn: "MaGiongHeo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HEO_LOAIHEO_MaLoaiHeo",
                        column: x => x.MaLoaiHeo,
                        principalTable: "LOAIHEO",
                        principalColumn: "MaLoaiHeo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesClaims",
                columns: table => new
                {
                    RoleClaimID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesClaims", x => x.RoleClaimID);
                    table.ForeignKey(
                        name: "FK_RolesClaims_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FarmID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoefficientsSalary = table.Column<float>(type: "real", nullable: false),
                    RoleID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HEO_MaChuong",
                table: "HEO",
                column: "MaChuong");

            migrationBuilder.CreateIndex(
                name: "IX_HEO_MaGiongHeo",
                table: "HEO",
                column: "MaGiongHeo");

            migrationBuilder.CreateIndex(
                name: "IX_HEO_MaLoaiHeo",
                table: "HEO",
                column: "MaLoaiHeo");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserID",
                table: "RefreshToken",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RolesClaims_RoleID",
                table: "RolesClaims",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DOITACs");

            migrationBuilder.DropTable(
                name: "HEO");

            migrationBuilder.DropTable(
                name: "PigFarm");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RolesClaims");

            migrationBuilder.DropTable(
                name: "CHUONGHEO");

            migrationBuilder.DropTable(
                name: "GIONGHEO");

            migrationBuilder.DropTable(
                name: "LOAIHEO");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
