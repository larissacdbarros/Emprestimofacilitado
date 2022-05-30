using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimosFacilitados.Models
{
    public class MeuEmprestimo
    {
        public int MeuEmprestimoId { get; set; }

        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Informe o valor do empréstimo")]
        [Display(Name = "Valor do empréstimo")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorEmprestado{ get; set; }

        [Display(Name = "Valor total a ser pago")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotalQueSerapago { get; set; }


        [Display(Name = "Valor pago até o momento")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorPago { get; set; }

        public int TipoEmprestimoId { get; set; }
        public TipoEmprestimo TipoEmprestimo { get; set; }

        [Display(Name = "Parcelas Quitadas")]
        public int QtdParcelasPagas{ get; set; } 

        [Display(Name = "Emprestimo Quitado")]
        public bool IsEmprestimoQuitado { get; set; }
        
        
    }
}
