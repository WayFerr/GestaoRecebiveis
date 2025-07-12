using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.DTOs.Request
{
    public class EmpresaRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CNPJ é obrigatório", AllowEmptyStrings = false)]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve ter exatamente 14 caracteres")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Faturamento mensal é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Faturamento deve ser maior que zero")]
        public decimal FaturamentoMensal { get; set; }
        [Required(ErrorMessage = "Ramo de Atividade é obrigatório", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "Ramo de Atividade deve ter no máximo 100 caracteres")]
        public string DsRamoAtividade { get; set; }
    }
}
