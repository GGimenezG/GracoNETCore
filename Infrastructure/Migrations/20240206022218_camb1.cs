using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class camb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoPersonajeGG_TipoPersonajeGG_fuerteContra",
                table: "TipoPersonajeGG");

            migrationBuilder.DropIndex(
                name: "IX_TipoPersonajeGG_fuerteContra",
                table: "TipoPersonajeGG");

            migrationBuilder.DropColumn(
                name: "fuerteContra",
                table: "TipoPersonajeGG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fuerteContra",
                table: "TipoPersonajeGG",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPersonajeGG_fuerteContra",
                table: "TipoPersonajeGG",
                column: "fuerteContra");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoPersonajeGG_TipoPersonajeGG_fuerteContra",
                table: "TipoPersonajeGG",
                column: "fuerteContra",
                principalTable: "TipoPersonajeGG",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
