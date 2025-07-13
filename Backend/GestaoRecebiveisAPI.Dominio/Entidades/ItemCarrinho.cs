using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Entidades
{
    public class ItemCarrinho
    {
        public int ItemCarrinhoId { get; set; }
        public int CarrinhoId { get; set; }
        public Carrinho Carrinho { get; set; }
        public int NotaFiscalId { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
    }
}
