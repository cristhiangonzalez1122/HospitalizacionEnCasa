using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class Entidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EnfermeraId",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Especialidad",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FamiliarId",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "personas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HorasLaborales",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Latitud",
                table: "personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Longitud",
                table: "personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parentesco",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistroRethus",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TarjetaProfesional",
                table: "personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entorno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignosVitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Signo = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignosVitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignosVitales_personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SugerenciasCuidados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SugerenciasCuidados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SugerenciasCuidados_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personas_EnfermeraId",
                table: "personas",
                column: "EnfermeraId");

            migrationBuilder.CreateIndex(
                name: "IX_personas_FamiliarId",
                table: "personas",
                column: "FamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_personas_HistoriaId",
                table: "personas",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_personas_MedicoId",
                table: "personas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_SignosVitales_PacienteId",
                table: "SignosVitales",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SugerenciasCuidados_HistoriaId",
                table: "SugerenciasCuidados",
                column: "HistoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_personas_Historias_HistoriaId",
                table: "personas",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_EnfermeraId",
                table: "personas",
                column: "EnfermeraId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_FamiliarId",
                table: "personas",
                column: "FamiliarId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_MedicoId",
                table: "personas",
                column: "MedicoId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personas_Historias_HistoriaId",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_EnfermeraId",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_FamiliarId",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_MedicoId",
                table: "personas");

            migrationBuilder.DropTable(
                name: "SignosVitales");

            migrationBuilder.DropTable(
                name: "SugerenciasCuidados");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropIndex(
                name: "IX_personas_EnfermeraId",
                table: "personas");

            migrationBuilder.DropIndex(
                name: "IX_personas_FamiliarId",
                table: "personas");

            migrationBuilder.DropIndex(
                name: "IX_personas_HistoriaId",
                table: "personas");

            migrationBuilder.DropIndex(
                name: "IX_personas_MedicoId",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "EnfermeraId",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Especialidad",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "FamiliarId",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "HistoriaId",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "HorasLaborales",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Parentesco",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "RegistroRethus",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "TarjetaProfesional",
                table: "personas");
        }
    }
}
