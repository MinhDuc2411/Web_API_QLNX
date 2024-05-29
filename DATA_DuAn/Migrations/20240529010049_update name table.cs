using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA_DuAn.Migrations
{
    /// <inheritdoc />
    public partial class updatenametable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongThue_nhanViens_MaNV",
                table: "HopDongThue");

            migrationBuilder.DropForeignKey(
                name: "FK_thanhToans_HopDongThue_MaHopDong",
                table: "thanhToans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_thanhToans",
                table: "thanhToans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_nhanViens",
                table: "nhanViens");

            migrationBuilder.RenameTable(
                name: "thanhToans",
                newName: "ThanhToan");

            migrationBuilder.RenameTable(
                name: "nhanViens",
                newName: "NhanVien");

            migrationBuilder.RenameIndex(
                name: "IX_thanhToans_MaHopDong",
                table: "ThanhToan",
                newName: "IX_ThanhToan_MaHopDong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThanhToan",
                table: "ThanhToan",
                column: "MaTT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhanVien",
                table: "NhanVien",
                column: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongThue_NhanVien_MaNV",
                table: "HopDongThue",
                column: "MaNV",
                principalTable: "NhanVien",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToan_HopDongThue_MaHopDong",
                table: "ThanhToan",
                column: "MaHopDong",
                principalTable: "HopDongThue",
                principalColumn: "MaHopDong",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDongThue_NhanVien_MaNV",
                table: "HopDongThue");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToan_HopDongThue_MaHopDong",
                table: "ThanhToan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThanhToan",
                table: "ThanhToan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhanVien",
                table: "NhanVien");

            migrationBuilder.RenameTable(
                name: "ThanhToan",
                newName: "thanhToans");

            migrationBuilder.RenameTable(
                name: "NhanVien",
                newName: "nhanViens");

            migrationBuilder.RenameIndex(
                name: "IX_ThanhToan_MaHopDong",
                table: "thanhToans",
                newName: "IX_thanhToans_MaHopDong");

            migrationBuilder.AddPrimaryKey(
                name: "PK_thanhToans",
                table: "thanhToans",
                column: "MaTT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_nhanViens",
                table: "nhanViens",
                column: "MaNV");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDongThue_nhanViens_MaNV",
                table: "HopDongThue",
                column: "MaNV",
                principalTable: "nhanViens",
                principalColumn: "MaNV",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_thanhToans_HopDongThue_MaHopDong",
                table: "thanhToans",
                column: "MaHopDong",
                principalTable: "HopDongThue",
                principalColumn: "MaHopDong",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
