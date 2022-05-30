using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimosFacilitados.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RendaMensal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "TiposEmprestimos",
                columns: table => new
                {
                    TipoEmprestimoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    QuantidadeMeses = table.Column<int>(type: "int", nullable: false),
                    Juros = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEmprestimos", x => x.TipoEmprestimoId);
                });

            migrationBuilder.CreateTable(
                name: "MeusEmprestimos",
                columns: table => new
                {
                    MeuEmprestimoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ValorEmprestado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorTotalQueSerapago = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TipoEmprestimoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeusEmprestimos", x => x.MeuEmprestimoId);
                    table.ForeignKey(
                        name: "FK_MeusEmprestimos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeusEmprestimos_TiposEmprestimos_TipoEmprestimoId",
                        column: x => x.TipoEmprestimoId,
                        principalTable: "TiposEmprestimos",
                        principalColumn: "TipoEmprestimoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeusEmprestimos_ClienteId",
                table: "MeusEmprestimos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MeusEmprestimos_TipoEmprestimoId",
                table: "MeusEmprestimos",
                column: "TipoEmprestimoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeusEmprestimos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposEmprestimos");
        }
    }
}
