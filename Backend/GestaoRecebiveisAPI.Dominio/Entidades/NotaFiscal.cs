using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Entidades
{
    public class NotaFiscal
    {
        public int NotaFiscalId { get; set; }
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime DtVencimento { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
