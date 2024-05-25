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
    [Migration("20240525092646_add table ThamSo")]
    partial class addtableThamSo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.Account", b =>
                {
                    b.Property<Guid>("AccountID")
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

                    b.Property<bool>("IsPremium")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");
                });

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

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.CT_LICHTIEM", b =>
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

                    b.Property<Guid>("MaLich")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("MaHeo");

                    b.HasIndex("MaLich");

                    b.ToTable("CT_LICHTIEMs");
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

                    b.Property<string>("LoaiHangHoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<bool>("IsThuanChung")
                        .HasColumnType("bit");

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

                    b.Property<DateTime>("NgayDenTrangTrai")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<float>("TrongLuong")
                        .HasColumnType("real");

                    b.HasKey("MaHeo");

                    b.HasIndex("MaChuong");

                    b.HasIndex("MaGiongHeo");

                    b.ToTable("HEO");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.HOADONHANGHOA", b =>
                {
                    b.Property<string>("MaHoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonViTinh")
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

                    b.Property<string>("LoaiHangHoa")
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

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.LICHCHOAN", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("LuongThucAn1Con")
                        .HasColumnType("real");

                    b.Property<Guid>("MaChuong")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaHangHoa")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayChoAn")
                        .HasColumnType("datetime2");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("MaChuong");

                    b.HasIndex("MaHangHoa");

                    b.HasIndex("UserID");

                    b.ToTable("LICHCHOANs");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.LICHPHOIGIONG", b =>
                {
                    b.Property<string>("MaLich")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CachGiaiQuyet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChuTaiSaoThatBai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiPhoiGiong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaGiongHeoDuc")
                        .HasColumnType("int");

                    b.Property<string>("MaHeoDuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaHeoNai")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayDauThai")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDeChinhThuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDeDuKien")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayPhoi")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguyenNhanThatBai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SoHeoCai")
                        .HasColumnType("int");

                    b.Property<int?>("SoHeoChet")
                        .HasColumnType("int");

                    b.Property<int?>("SoHeoDuc")
                        .HasColumnType("int");

                    b.Property<int?>("SoHeoTat")
                        .HasColumnType("int");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaLich");

                    b.HasIndex("MaGiongHeoDuc");

                    b.HasIndex("MaHeoDuc");

                    b.HasIndex("MaHeoNai");

                    b.HasIndex("UserID");

                    b.ToTable("LICHPHOIGIONGs");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.LICHTIEM", b =>
                {
                    b.Property<Guid>("MaLichTiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("LieuLuong")
                        .HasColumnType("real");

                    b.Property<int>("MaHangHoa")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTiem")
                        .HasColumnType("datetime2");

                    b.Property<string>("TinhTrang")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MaLichTiem");

                    b.HasIndex("MaHangHoa");

                    b.HasIndex("UserID");

                    b.ToTable("LICHTIEMs");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.PigFarm", b =>
                {
                    b.Property<Guid>("FarmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FarmID");

                    b.HasIndex("AccountID");

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

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.THAMSO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<Guid>("FarmID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("GiaoPhoiCanHuyetToiThieu")
                        .HasColumnType("real");

                    b.Property<float>("SoNgayToiThieuPhoiGiongLai")
                        .HasColumnType("real");

                    b.Property<float>("TrongLuongToiDaXuatChuong")
                        .HasColumnType("real");

                    b.Property<float>("TrongLuongToiThieuXuatChuong")
                        .HasColumnType("real");

                    b.Property<float>("TuoiNhapDanHeoCon")
                        .HasColumnType("real");

                    b.Property<float>("TuoiPhoiGiongToiThieuHeoCai")
                        .HasColumnType("real");

                    b.Property<float>("TuoiPhoiGiongToiThieuHeoDuc")
                        .HasColumnType("real");

                    b.Property<float>("TuoiToiDaXuatChuong")
                        .HasColumnType("real");

                    b.Property<float>("TuoiToiThieuXuatChuong")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("THAMSOS");
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

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.CT_LICHTIEM", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.HEO", "HEO")
                        .WithMany()
                        .HasForeignKey("MaHeo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.LICHTIEM", "LICHTIEM")
                        .WithMany()
                        .HasForeignKey("MaLich")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HEO");

                    b.Navigation("LICHTIEM");
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

                    b.Navigation("CHUONGHEO");

                    b.Navigation("GIONGHEO");
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

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.LICHCHOAN", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.CHUONGHEO", "CHUONGHEO")
                        .WithMany()
                        .HasForeignKey("MaChuong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.HANGHOA", "HANGHOA")
                        .WithMany()
                        .HasForeignKey("MaHangHoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CHUONGHEO");

                    b.Navigation("HANGHOA");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.LICHPHOIGIONG", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.GIONGHEO", "GIONGHEODUC")
                        .WithMany()
                        .HasForeignKey("MaGiongHeoDuc");

                    b.HasOne("PigPalaceAPI.Data.Entity.HEO", "HEODUC")
                        .WithMany()
                        .HasForeignKey("MaHeoDuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.HEO", "HEONAI")
                        .WithMany()
                        .HasForeignKey("MaHeoNai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.User", "NhanVien")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GIONGHEODUC");

                    b.Navigation("HEODUC");

                    b.Navigation("HEONAI");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.LICHTIEM", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.HANGHOA", "HANGHOA")
                        .WithMany()
                        .HasForeignKey("MaHangHoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PigPalaceAPI.Data.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HANGHOA");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PigPalaceAPI.Data.Entity.PigFarm", b =>
                {
                    b.HasOne("PigPalaceAPI.Data.Entity.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
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
