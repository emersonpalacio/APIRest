using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIRest.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                });

            migrationBuilder.CreateTable(
                name: "Periodos",
                columns: table => new
                {
                    IdPeriodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodos", x => x.IdPeriodo);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    IdMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstudianteIdEstudiante = table.Column<int>(type: "int", nullable: true),
                    PeriodoIdPeriodo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.IdMatricula);
                    table.ForeignKey(
                        name: "FK_Matriculas_Estudiantes_EstudianteIdEstudiante",
                        column: x => x.EstudianteIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Periodos_PeriodoIdPeriodo",
                        column: x => x.PeriodoIdPeriodo,
                        principalTable: "Periodos",
                        principalColumn: "IdPeriodo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InscripcionCursos",
                columns: table => new
                {
                    IdInscripcionCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstudianteIdEstudiante = table.Column<int>(type: "int", nullable: true),
                    PeriodoIdPeriodo = table.Column<int>(type: "int", nullable: true),
                    CursoIdCurso = table.Column<int>(type: "int", nullable: true),
                    MatriculaIdMatricula = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionCursos", x => x.IdInscripcionCurso);
                    table.ForeignKey(
                        name: "FK_InscripcionCursos_Cursos_CursoIdCurso",
                        column: x => x.CursoIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscripcionCursos_Estudiantes_EstudianteIdEstudiante",
                        column: x => x.EstudianteIdEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscripcionCursos_Matriculas_MatriculaIdMatricula",
                        column: x => x.MatriculaIdMatricula,
                        principalTable: "Matriculas",
                        principalColumn: "IdMatricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscripcionCursos_Periodos_PeriodoIdPeriodo",
                        column: x => x.PeriodoIdPeriodo,
                        principalTable: "Periodos",
                        principalColumn: "IdPeriodo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionCursos_CursoIdCurso",
                table: "InscripcionCursos",
                column: "CursoIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionCursos_EstudianteIdEstudiante",
                table: "InscripcionCursos",
                column: "EstudianteIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionCursos_MatriculaIdMatricula",
                table: "InscripcionCursos",
                column: "MatriculaIdMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionCursos_PeriodoIdPeriodo",
                table: "InscripcionCursos",
                column: "PeriodoIdPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_EstudianteIdEstudiante",
                table: "Matriculas",
                column: "EstudianteIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_PeriodoIdPeriodo",
                table: "Matriculas",
                column: "PeriodoIdPeriodo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InscripcionCursos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Periodos");
        }
    }
}
