using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimosFacilitados.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Informar nome do cliente")]
        [StringLength(100, ErrorMessage = "Máximo de 50 caracteres")]
        public string Nome{ get; set; }

        [Required(ErrorMessage = "Informar sobrenome do cliente")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string Sobrenome{ get; set; }

        [Required(ErrorMessage = "Informar CPF do cliente")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Informar e-mail")]
        [Display(Name = "e-mail")]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Informar a renda mensal")]
        [Display(Name = "Renda Mensal")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1000.00, 1000000.00, ErrorMessage = "A renda mensal tem o valor mínimo de R$1000,00")]
        public decimal RendaMensal { get; set; }

        List<TipoEmprestimo> Emprestimos { get; set; }
    }
}
