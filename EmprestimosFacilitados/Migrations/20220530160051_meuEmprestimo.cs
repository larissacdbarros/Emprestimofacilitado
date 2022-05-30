using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosFacilitados.Migrations
{
    public partial class meuEmprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmprestimoQuitado",
                table: "MeusEmprestimos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "QtdParcelasParaSeremPagas",
                table: "MeusEmprestimos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmprestimoQuitado",
                table: "MeusEmprestimos");

            migrationBuilder.DropColumn(
                name: "QtdParcelasParaSeremPagas",
                table: "MeusEmprestimos");
        }
    }
}
