using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Estacionamento.Infra.Migrations
{
    public partial class Add_CreatedAt_in_PhysicalPerson_and_LegalPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "PessoaJuridica",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "PessoaFisica",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "PessoaJuridica");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "PessoaFisica");
        }
    }
}
