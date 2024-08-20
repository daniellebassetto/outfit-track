using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutfitTrack.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Ajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "rg",
                table: "cliente",
                type: "VARCHAR(9)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(9)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "cliente",
                type: "VARCHAR(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(256)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "cliente",
                keyColumn: "rg",
                keyValue: null,
                column: "rg",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "rg",
                table: "cliente",
                type: "VARCHAR(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(9)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "cliente",
                keyColumn: "email",
                keyValue: null,
                column: "email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "cliente",
                type: "VARCHAR(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(256)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
