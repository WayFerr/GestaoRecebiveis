using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.DTOs.Request
{
    public class NotaFiscalRequest
    {
        [Required(ErrorMessage = "Número da nota fiscal é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Valor da nota fiscal é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Data de vencimento é obrigatória.")]
        [DataFutura(ErrorMessage = "A data de vencimento não pode ser anterior à data atual.")]
        public DateTime DtVencimento { get; set; }

        [Required(ErrorMessage = "Id da Empresa é obrigatório.")]
        public int EmpresaId { get; set; }
    }

    public class DataFuturaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Today;
            }
            return false;
        }
    }
}
