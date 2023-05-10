using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedSocial.Server.Migrations
{
    /// <inheritdoc />
    public partial class Amigos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAmigos = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MiPerfilId = table.Column<int>(type: "int", nullable: false),
                    PerfilAmigoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amigos_Perfiles_MiPerfilId",
                        column: x => x.MiPerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Amigos_Perfiles_PerfilAmigoId",
                        column: x => x.PerfilAmigoId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextoHistoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PerfilCreacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historias_Perfiles_PerfilCreacionId",
                        column: x => x.PerfilCreacionId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesAmistad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerfilSolictaId = table.Column<int>(type: "int", nullable: false),
                    PerfilSolicitaId = table.Column<int>(type: "int", nullable: true),
                    PerfilSolicitadoId = table.Column<int>(type: "int", nullable: false),
                    Aceptado = table.Column<bool>(type: "bit", nullable: false),
                    AceptarMensajes = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesAmistad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesAmistad_Perfiles_PerfilSolicitaId",
                        column: x => x.PerfilSolicitaId,
                        principalTable: "Perfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitudesAmistad_Perfiles_PerfilSolicitadoId",
                        column: x => x.PerfilSolicitadoId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: false),
                    TextoRespuesta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PerfilRespuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuestas_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Respuestas_Perfiles_PerfilRespuestaId",
                        column: x => x.PerfilRespuestaId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_MiPerfilId",
                table: "Amigos",
                column: "MiPerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_PerfilAmigoId",
                table: "Amigos",
                column: "PerfilAmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_PerfilCreacionId",
                table: "Historias",
                column: "PerfilCreacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_HistoriaId",
                table: "Respuestas",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PerfilRespuestaId",
                table: "Respuestas",
                column: "PerfilRespuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAmistad_PerfilSolicitadoId",
                table: "SolicitudesAmistad",
                column: "PerfilSolicitadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAmistad_PerfilSolicitaId",
                table: "SolicitudesAmistad",
                column: "PerfilSolicitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "SolicitudesAmistad");

            migrationBuilder.DropTable(
                name: "Historias");
        }
    }
}
