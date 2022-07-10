using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.Infra.Migrations
{
    public partial class Alter_CreatedAt_in_PhysicalPerson_and_LegalPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "PessoaJuridica",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "PessoaFisica",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PessoaJuridica",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PessoaFisica",
                newName: "createdAt");
        }
    }
}
