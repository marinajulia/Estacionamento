using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.Infra.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaFisica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaJuridica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailsPessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoaFisica = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsPessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailsPessoaFisica_PessoaFisica_IdPessoaFisica",
                        column: x => x.IdPessoaFisica,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefonesPessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoaFisica = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonesPessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefonesPessoaFisica_PessoaFisica_IdPessoaFisica",
                        column: x => x.IdPessoaFisica,
                        principalTable: "PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailsPessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoaJuridica = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsPessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailsPessoaJuridica_PessoaJuridica_IdPessoaJuridica",
                        column: x => x.IdPessoaJuridica,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelefonesPessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoaJuridica = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonesPessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefonesPessoaJuridica_PessoaJuridica_IdPessoaJuridica",
                        column: x => x.IdPessoaJuridica,
                        principalTable: "PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailsPessoaFisica_IdPessoaFisica",
                table: "EmailsPessoaFisica",
                column: "IdPessoaFisica");

            migrationBuilder.CreateIndex(
                name: "IX_EmailsPessoaJuridica_IdPessoaJuridica",
                table: "EmailsPessoaJuridica",
                column: "IdPessoaJuridica");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonesPessoaFisica_IdPessoaFisica",
                table: "TelefonesPessoaFisica",
                column: "IdPessoaFisica");

            migrationBuilder.CreateIndex(
                name: "IX_TelefonesPessoaJuridica_IdPessoaJuridica",
                table: "TelefonesPessoaJuridica",
                column: "IdPessoaJuridica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailsPessoaFisica");

            migrationBuilder.DropTable(
                name: "EmailsPessoaJuridica");

            migrationBuilder.DropTable(
                name: "TelefonesPessoaFisica");

            migrationBuilder.DropTable(
                name: "TelefonesPessoaJuridica");

            migrationBuilder.DropTable(
                name: "PessoaFisica");

            migrationBuilder.DropTable(
                name: "PessoaJuridica");
        }
    }
}
