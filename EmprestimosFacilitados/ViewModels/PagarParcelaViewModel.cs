using DataAnnotationsExtensions;
using EmprestimosFacilitados.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimosFacilitados.ViewModels
{
    public class PagarParcelaViewModel
    {
        
        public int QtdParcelasParaPagar { get; set; }

        public int QtdParcelasQueDesejaPagar { get; set; } = 1;

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal{ get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorParcela{ get; set; }

        public MeuEmprestimo MeuEmprestimo { get; set; }  
        
        
    }
}
