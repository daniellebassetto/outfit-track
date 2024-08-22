using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutfitTrack.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantidade",
                table: "produto",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }
    }
}
