﻿// <auto-generated />
using System;
using DATA_DuAn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DATA_DuAn.Migrations
{
    [DbContext(typeof(CarRentalDbContext))]
    [Migration("20240611043510_addmodelImage")]
    partial class addmodelImage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DATA_DuAn.Models.DanhMucXe", b =>
                {
                    b.Property<int>("MaXe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaXe"));

                    b.Property<string>("BienSo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GiaThue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HangXe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MauSac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaXe");

                    b.ToTable("DanhMucXe");
                });

            modelBuilder.Entity("DATA_DuAn.Models.HopDongThue", b =>
                {
                    b.Property<int>("MaHopDong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHopDong"));

                    b.Property<int>("MaKH")
                        .HasColumnType("int");

                    b.Property<int>("MaNV")
                        .HasColumnType("int");

                    b.Property<int>("MaXe")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TinhTrang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaHopDong");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaNV");

                    b.HasIndex("MaXe");

                    b.ToTable("HopDongThue");
                });

            modelBuilder.Entity("DATA_DuAn.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSizeInBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DATA_DuAn.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKH"));

                    b.Property<string>("Cccd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKH")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKH");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("DATA_DuAn.Models.NhanVien", b =>
                {
                    b.Property<int>("MaNV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNV"));

                    b.Property<string>("ChucVu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNV")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaNV");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("DATA_DuAn.Models.ThanhToan", b =>
                {
                    b.Property<int>("MaTT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTT"));

                    b.Property<int>("MaHopDong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongThuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SoTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaTT");

                    b.HasIndex("MaHopDong");

                    b.ToTable("ThanhToan");
                });

            modelBuilder.Entity("DATA_DuAn.Models.HopDongThue", b =>
                {
                    b.HasOne("DATA_DuAn.Models.KhachHang", "KhachHang")
                        .WithMany("HopDongThues")
                        .HasForeignKey("MaKH")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DATA_DuAn.Models.NhanVien", "NhanVien")
                        .WithMany("HopDongThues")
                        .HasForeignKey("MaNV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DATA_DuAn.Models.DanhMucXe", "DanhMucXe")
                        .WithMany("HopDongThues")
                        .HasForeignKey("MaXe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucXe");

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("DATA_DuAn.Models.ThanhToan", b =>
                {
                    b.HasOne("DATA_DuAn.Models.HopDongThue", "HopDongThue")
                        .WithMany("ThanhToans")
                        .HasForeignKey("MaHopDong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HopDongThue");
                });

            modelBuilder.Entity("DATA_DuAn.Models.DanhMucXe", b =>
                {
                    b.Navigation("HopDongThues");
                });

            modelBuilder.Entity("DATA_DuAn.Models.HopDongThue", b =>
                {
                    b.Navigation("ThanhToans");
                });

            modelBuilder.Entity("DATA_DuAn.Models.KhachHang", b =>
                {
                    b.Navigation("HopDongThues");
                });

            modelBuilder.Entity("DATA_DuAn.Models.NhanVien", b =>
                {
                    b.Navigation("HopDongThues");
                });
#pragma warning restore 612, 618
        }
    }
}
