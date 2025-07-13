using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.DTOs.Response
{
    public class CheckoutResponse
    {
        public string Empresa { get; set; }
        public string Cnpj { get; set; }
        public decimal Limite { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal TotalLiquido { get; set; }
        public List<NotaFiscalCheckoutResponse> NotasFiscais { get; set; }
    }

    public class NotaFiscalCheckoutResponse
    {
        public int Numero { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
    }
}
