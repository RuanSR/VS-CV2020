using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendentes",
                columns: table => new
                {
                    AtendenteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    NivelAcesso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendentes", x => x.AtendenteId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Apelido = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "NotaContas",
                columns: table => new
                {
                    NotaContaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LimiteConta = table.Column<double>(nullable: false),
                    TotalConta = table.Column<double>(nullable: false),
                    DataConta = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaContas", x => x.NotaContaId);
                    table.ForeignKey(
                        name: "FK_NotaContas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroNotas",
                columns: table => new
                {
                    RegistroNotaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHora = table.Column<DateTime>(nullable: false),
                    NomeAtendente = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    TextoDescricao = table.Column<string>(nullable: true),
                    NotaContaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroNotas", x => x.RegistroNotaId);
                    table.ForeignKey(
                        name: "FK_RegistroNotas_NotaContas_NotaContaId",
                        column: x => x.NotaContaId,
                        principalTable: "NotaContas",
                        principalColumn: "NotaContaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaContas_ClienteId",
                table: "NotaContas",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotas_NotaContaId",
                table: "RegistroNotas",
                column: "NotaContaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendentes");

            migrationBuilder.DropTable(
                name: "RegistroNotas");

            migrationBuilder.DropTable(
                name: "NotaContas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
