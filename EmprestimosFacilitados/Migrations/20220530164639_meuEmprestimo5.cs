using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosFacilitados.Migrations
{
    public partial class meuEmprestimo5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QtdParcelasParaSeremPagas",
                table: "MeusEmprestimos",
                newName: "QtdParcelasPagas");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPago",
                table: "MeusEmprestimos",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorPago",
                table: "MeusEmprestimos");

            migrationBuilder.RenameColumn(
                name: "QtdParcelasPagas",
                table: "MeusEmprestimos",
                newName: "QtdParcelasParaSeremPagas");
        }
    }
}
