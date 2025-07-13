using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.DTOs.Response
{
    public class TotalCarrinhoResponse
    {
        public int CarrinhoId { get; set; }
        public int EmpresaId { get; set; }
        public decimal TotalCarrinho { get; set; }
    }
}
