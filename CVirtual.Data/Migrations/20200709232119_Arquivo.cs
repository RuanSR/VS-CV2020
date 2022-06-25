using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CVirtual.Data.Migrations
{
    public partial class Arquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendentes",
                columns: table => new
                {
                    AtendenteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
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
                    Nome = table.Column<string>(nullable: false),
                    Apelido = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
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
                    DataConta = table.Column<string>(nullable: false),
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
                name: "Arquivos",
                columns: table => new
                {
                    ArquivoRegistrosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<string>(nullable: true),
                    NotaContaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.ArquivoRegistrosId);
                    table.ForeignKey(
                        name: "FK_Arquivos_NotaContas_NotaContaId",
                        column: x => x.NotaContaId,
                        principalTable: "NotaContas",
                        principalColumn: "NotaContaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistroNotas",
                columns: table => new
                {
                    RegistroNotaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataHora = table.Column<DateTime>(nullable: false),
                    NomeAtendente = table.Column<string>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    TextoDescricao = table.Column<string>(maxLength: 200, nullable: true),
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
                name: "IX_Arquivos_NotaContaId",
                table: "Arquivos",
                column: "NotaContaId");

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
                name: "Arquivos");

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
