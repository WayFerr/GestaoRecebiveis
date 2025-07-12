using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.DTOs.Response
{
    public class EmpresaResponse
    {
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public decimal FaturamentoMensal { get; set; }
        public string DsRamoAtividade { get; set; }
    }
}
