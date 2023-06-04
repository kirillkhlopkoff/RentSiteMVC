using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentSiteProject.Migrations
{
    /// <inheritdoc />
    public partial class ArraysPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainPhoto",
                table: "Apartments",
                newName: "Photos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photos",
                table: "Apartments",
                newName: "MainPhoto");
        }
    }
}
