using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class camb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonajeGG_TipoPersonajeGG_TipoPersonajeid1",
                table: "PersonajeGG");

            migrationBuilder.DropIndex(
                name: "IX_PersonajeGG_TipoPersonajeid1",
                table: "PersonajeGG");

            migrationBuilder.DropColumn(
                name: "TipoPersonajeid1",
                table: "PersonajeGG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPersonajeid1",
                table: "PersonajeGG",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonajeGG_TipoPersonajeid1",
                table: "PersonajeGG",
                column: "TipoPersonajeid1");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajeGG_TipoPersonajeGG_TipoPersonajeid1",
                table: "PersonajeGG",
                column: "TipoPersonajeid1",
                principalTable: "TipoPersonajeGG",
                principalColumn: "id");
        }
    }
}
