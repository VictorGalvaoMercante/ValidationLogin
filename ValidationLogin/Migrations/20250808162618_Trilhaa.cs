using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidationLogin.Migrations
{
    /// <inheritdoc />
    public partial class Trilhaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Trilha");

            migrationBuilder.DropColumn(
                name: "img",
                table: "Trilha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Trilha",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Trilha",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
