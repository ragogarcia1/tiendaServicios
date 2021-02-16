using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.Api.Autor.Migrations
{
    public partial class MigrationPostgreInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    BookAuthorId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BornDay = table.Column<DateTime>(nullable: true),
                    BookAuthorGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.BookAuthorId);
                });

            migrationBuilder.CreateTable(
                name: "AcademicGrade",
                columns: table => new
                {
                    AcademicGradeId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    AcademicCenter = table.Column<string>(nullable: true),
                    GradeDate = table.Column<DateTime>(nullable: true),
                    BookAuthorId = table.Column<int>(nullable: false),
                    AcademicGradeGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGrade", x => x.AcademicGradeId);
                    table.ForeignKey(
                        name: "FK_AcademicGrade_BookAuthor_BookAuthorId",
                        column: x => x.BookAuthorId,
                        principalTable: "BookAuthor",
                        principalColumn: "BookAuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGrade_BookAuthorId",
                table: "AcademicGrade",
                column: "BookAuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGrade");

            migrationBuilder.DropTable(
                name: "BookAuthor");
        }
    }
}
