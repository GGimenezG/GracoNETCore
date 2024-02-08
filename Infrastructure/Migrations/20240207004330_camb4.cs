using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class camb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnemigoGG_TipoPersonajeGG_TipoPersonajeid",
                table: "EnemigoGG");

            migrationBuilder.DropIndex(
                name: "IX_EnemigoGG_TipoPersonajeid",
                table: "EnemigoGG");

            migrationBuilder.DropColumn(
                name: "TipoPersonajeid",
                table: "EnemigoGG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPersonajeid",
                table: "EnemigoGG",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnemigoGG_TipoPersonajeid",
                table: "EnemigoGG",
                column: "TipoPersonajeid");

            migrationBuilder.AddForeignKey(
                name: "FK_EnemigoGG_TipoPersonajeGG_TipoPersonajeid",
                table: "EnemigoGG",
                column: "TipoPersonajeid",
                principalTable: "TipoPersonajeGG",
                principalColumn: "id");
        }
    }
}
