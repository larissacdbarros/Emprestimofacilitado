using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimosFacilitados.Models
{
    public class TipoEmprestimo
    {
        public int TipoEmprestimoId { get; set; }

        [Required(ErrorMessage = "Informar o tipo de ingresso")]
        [Display(Name = "Tipo de Emprestimo")]
        [StringLength(80, ErrorMessage = "Máximo de 80 caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Informar quantidade de parcelas")]
        [Display(Name = "Quantidade de meses para pagar o empréstimo")]
        [Range(5, 360, ErrorMessage = "O mínimo de parcelas é 5 e o máximo 360")]
        public int QuantidadeMeses { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public double Juros { get; set; }

        [Required(ErrorMessage = "Adicionar descrição")]
        [Display(Name = "Descrição a respeito desse tipo de empréstimo")]
        [StringLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        public string Descricao { get; set; }

    }
}
