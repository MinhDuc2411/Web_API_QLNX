using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA_DuAn.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucXe",
                columns: table => new
                {
                    MaXe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BienSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HangXe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MauSac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaThue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucXe", x => x.MaXe);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cccd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "HopDongThue",
                columns: table => new
                {
                    MaHopDong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    MaXe = table.Column<int>(type: "int", nullable: false),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongThue", x => x.MaHopDong);
                    table.ForeignKey(
                        name: "FK_HopDongThue_DanhMucXe_MaXe",
                        column: x => x.MaXe,
                        principalTable: "DanhMucXe",
                        principalColumn: "MaXe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongThue_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongThue_nhanViens_MaNV",
                        column: x => x.MaNV,
                        principalTable: "nhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thanhToans",
                columns: table => new
                {
                    MaTT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHopDong = table.Column<int>(type: "int", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhuongThuc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thanhToans", x => x.MaTT);
                    table.ForeignKey(
                        name: "FK_thanhToans_HopDongThue_MaHopDong",
                        column: x => x.MaHopDong,
                        principalTable: "HopDongThue",
                        principalColumn: "MaHopDong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThue_MaKH",
                table: "HopDongThue",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThue_MaNV",
                table: "HopDongThue",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongThue_MaXe",
                table: "HopDongThue",
                column: "MaXe");

            migrationBuilder.CreateIndex(
                name: "IX_thanhToans_MaHopDong",
                table: "thanhToans",
                column: "MaHopDong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "thanhToans");

            migrationBuilder.DropTable(
                name: "HopDongThue");

            migrationBuilder.DropTable(
                name: "DanhMucXe");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "nhanViens");
        }
    }
}
