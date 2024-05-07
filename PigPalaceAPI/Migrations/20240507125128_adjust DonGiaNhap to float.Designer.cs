﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PigPalaceAPI.Data;

#nullable disable

namespace PigPalaceAPI.Migrations
{
    [DbContext(typeof(PigPalaceDBContext))]
    [Migration("20240507125128_adjust DonGiaNhap to float")]
    partial class adjustDonGiaNhaptofloat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.CHUONGHEO", b =>
                {
                    b.Property<Guid>("MaChuong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongHeo")
                        .HasColumnType("int");

                    b.Property<int>("SucChuaToiDa")
                        .HasColumnType("int");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaChuong");

                    b.ToTable("CHUONGHEO");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.CT_HOADONHEO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaHeo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaHoaDon")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("MaHeo");

                    b.HasIndex("MaHoaDon");

                    b.ToTable("CT_HOADONHEOs");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.GIONGHEO", b =>
                {
                    b.Property<int>("MaGiongHeo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGiongHeo"));

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenGiongHeo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaGiongHeo");

                    b.ToTable("GIONGHEO");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.HANGHOA", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("GiaTriToiThieu")
                        .HasColumnType("real");

                    b.Property<DateTime>("NgayHetHan")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenHangHoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TienMuaTrenMotDonVi")
                        .HasColumnType("real");

                    b.Property<float>("TonKho")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("HANGHOAs");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.HEO", b =>
                {
                    b.Property<string>("MaHeo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float?>("DonGiaNhap")
                        .HasColumnType("real");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTrongTrangTrai")
                        .HasColumnType("bit");

                    b.Property<Guid>("MaChuong")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaGiongHeo")
                        .HasColumnType("int");

                    b.Property<string>("MaHeoCha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaHeoMe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaLoaiHeo")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDenTrangTrai")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<float>("TrongLuong")
                        .HasColumnType("real");

                    b.HasKey("MaHeo");

                    b.HasIndex("MaChuong");

                    b.HasIndex("MaGiongHeo");

                    b.HasIndex("MaLoaiHeo");

                    b.ToTable("HEO");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.HOADONHANGHOA", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("GiaTien")
                        .HasColumnType("real");

                    b.Property<string>("LoaiHoaDon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayMua")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenCongTy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHangHoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TienTrenDVT")
                        .HasColumnType("real");

                    b.Property<float>("TongTien")
                        .HasColumnType("real");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("UserID");

                    b.ToTable("HOADONHANGHOAs");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.HOADONHEO", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiHoaDon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayMua")
                        .HasColumnType("datetime2");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SoLuong")
                        .HasColumnType("real");

                    b.Property<string>("TenCongTy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TienTrenDVT")
                        .HasColumnType("real");

                    b.Property<float>("TongTien")
                        .HasColumnType("real");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("UserID");

                    b.ToTable("HOADONHEOs");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.LOAIHEO", b =>
                {
                    b.Property<int>("MaLoaiHeo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoaiHeo"));

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenLoaiHeo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoaiHeo");

                    b.ToTable("LOAIHEO");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.PigFarm", b =>
                {
                    b.Property<Guid>("FarmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FBID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFromFB")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFromGoogle")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FarmID");

                    b.ToTable("PigFarm");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.RefreshToken", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("JwtID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.Roles", b =>
                {
                    b.Property<string>("RoleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("BasicSalary")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.RolesClaims", b =>
                {
                    b.Property<string>("RoleClaimID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActionDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleClaimID");

                    b.HasIndex("RoleID");

                    b.ToTable("RolesClaims");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CoefficientsSalary")
                        .HasColumnType("real");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.CT_HOADONHEO", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.HEO", "HEO")
                        .WithMany()
                        .HasForeignKey("MaHeo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.HOADONHEO", "HOADONHEO")
                        .WithMany()
                        .HasForeignKey("MaHoaDon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HEO");

                    b.Navigation("HOADONHEO");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.HEO", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.CHUONGHEO", "CHUONGHEO")
                        .WithMany()
                        .HasForeignKey("MaChuong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.GIONGHEO", "GIONGHEO")
                        .WithMany()
                        .HasForeignKey("MaGiongHeo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.LOAIHEO", "LOAIHEO")
                        .WithMany()
                        .HasForeignKey("MaLoaiHeo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CHUONGHEO");

                    b.Navigation("GIONGHEO");

                    b.Navigation("LOAIHEO");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.HOADONHANGHOA", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.HOADONHEO", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.RefreshToken", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.User", "CurrentUser")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentUser");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.RolesClaims", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.User", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
