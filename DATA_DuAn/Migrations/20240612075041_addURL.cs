using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA_DuAn.Migrations
{
    /// <inheritdoc />
    public partial class addURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URl",
                table: "DanhMucXe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URl",
                table: "DanhMucXe");
        }
    }
}
