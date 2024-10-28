using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motoland.Migrations.CarAdDb
{
    /// <inheritdoc />
    public partial class CarMirgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePaths",
                table: "CarAds",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePaths",
                table: "CarAds");
        }
    }
}
