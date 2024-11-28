using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoStaff.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToStaff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AppStaffs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AppStaffs");
        }
    }
}
