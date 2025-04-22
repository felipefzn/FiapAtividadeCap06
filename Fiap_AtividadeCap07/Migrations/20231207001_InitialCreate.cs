using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap_AtividadeCap07.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acidentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    Localizacao = table.Column<string>(maxLength: 255, nullable: false),
                    Gravidade = table.Column<string>(maxLength: 50, nullable: false),
                    DataHora = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acidentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semaforos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localizacao = table.Column<string>(maxLength: 255, nullable: false),
                    CorAtual = table.Column<string>(maxLength: 50, nullable: false),
                    UltimaTroca = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semaforos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acidentes");

            migrationBuilder.DropTable(
                name: "Semaforos");
        }
    }
}
