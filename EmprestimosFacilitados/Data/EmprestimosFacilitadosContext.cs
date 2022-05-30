using Microsoft.EntityFrameworkCore;

namespace EmprestimosFacilitados.Data
{
    public class EmprestimosFacilitadosContext: DbContext
    {
        public EmprestimosFacilitadosContext(DbContextOptions<EmprestimosFacilitadosContext> options) : base(options)
        {
        }

        public DbSet<EmprestimosFacilitados.Models.Cliente> Clientes{ get; set; }

        public DbSet<EmprestimosFacilitados.Models.MeuEmprestimo> MeusEmprestimos { get; set; }
        public DbSet<EmprestimosFacilitados.Models.TipoEmprestimo> TiposEmprestimos { get; set; }
    }
}
