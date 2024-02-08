using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjetoGG",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(270)", maxLength: 270, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    tipo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    valor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetoGG", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RecompensaGG",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    experiencia = table.Column<int>(type: "integer", nullable: false),
                    monedas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecompensaGG", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPersonajeGG",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(270)", maxLength: 270, nullable: false),
                    fuerteContra = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersonajeGG", x => x.id);
                    table.ForeignKey(
                        name: "FK_TipoPersonajeGG_TipoPersonajeGG_fuerteContra",
                        column: x => x.fuerteContra,
                        principalTable: "TipoPersonajeGG",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjetosRecompensa",
                columns: table => new
                {
                    Recompensasid = table.Column<int>(type: "integer", nullable: false),
                    objetosid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosRecompensa", x => new { x.Recompensasid, x.objetosid });
                    table.ForeignKey(
                        name: "FK_ObjetosRecompensa_ObjetoGG_objetosid",
                        column: x => x.objetosid,
                        principalTable: "ObjetoGG",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjetosRecompensa_RecompensaGG_Recompensasid",
                        column: x => x.Recompensasid,
                        principalTable: "RecompensaGG",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonajeGG",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(270)", maxLength: 270, nullable: false),
                    tipoId = table.Column<int>(type: "integer", nullable: false),
                    estamina = table.Column<int>(type: "integer", nullable: false),
                    inteligencia = table.Column<int>(type: "integer", nullable: false),
                    fuerza = table.Column<int>(type: "integer", nullable: false),
                    resistencia = table.Column<int>(type: "integer", nullable: false),
                    defensa = table.Column<int>(type: "integer", nullable: false),
                    experiencia = table.Column<double>(type: "double precision", nullable: false),
                    nivel = table.Column<int>(type: "integer", nullable: false),
                    HP = table.Column<int>(type: "integer", nullable: false),
                    MP = table.Column<int>(type: "integer", nullable: false),
                    TipoPersonajeid1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonajeGG", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonajeGG_TipoPersonajeGG_TipoPersonajeid1",
                        column: x => x.TipoPersonajeid1,
                        principalTable: "TipoPersonajeGG",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PersonajeGG_TipoPersonajeGG_tipoId",
                        column: x => x.tipoId,
                        principalTable: "TipoPersonajeGG",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnemigoGG",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    recompensaId = table.Column<int>(type: "integer", nullable: false),
                    TipoPersonajeid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemigoGG", x => x.id);
                    table.ForeignKey(
                        name: "FK_EnemigoGG_PersonajeGG_id",
                        column: x => x.id,
                        principalTable: "PersonajeGG",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnemigoGG_RecompensaGG_recompensaId",
                        column: x => x.recompensaId,
                        principalTable: "RecompensaGG",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EnemigoGG_TipoPersonajeGG_TipoPersonajeid",
                        column: x => x.TipoPersonajeid,
                        principalTable: "TipoPersonajeGG",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnemigoGG_TipoPersonajeid",
                table: "EnemigoGG",
                column: "TipoPersonajeid");

            migrationBuilder.CreateIndex(
                name: "IX_EnemigoGG_recompensaId",
                table: "EnemigoGG",
                column: "recompensaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetosRecompensa_objetosid",
                table: "ObjetosRecompensa",
                column: "objetosid");

            migrationBuilder.CreateIndex(
                name: "IX_PersonajeGG_TipoPersonajeid1",
                table: "PersonajeGG",
                column: "TipoPersonajeid1");

            migrationBuilder.CreateIndex(
                name: "IX_PersonajeGG_tipoId",
                table: "PersonajeGG",
                column: "tipoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPersonajeGG_fuerteContra",
                table: "TipoPersonajeGG",
                column: "fuerteContra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnemigoGG");

            migrationBuilder.DropTable(
                name: "ObjetosRecompensa");

            migrationBuilder.DropTable(
                name: "PersonajeGG");

            migrationBuilder.DropTable(
                name: "ObjetoGG");

            migrationBuilder.DropTable(
                name: "RecompensaGG");

            migrationBuilder.DropTable(
                name: "TipoPersonajeGG");
        }
    }
}
