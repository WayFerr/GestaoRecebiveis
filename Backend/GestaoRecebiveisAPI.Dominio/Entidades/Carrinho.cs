using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Entidades
{
    public class Carrinho
    {
        public Carrinho()
        {
            Itens = new Collection<ItemCarrinho>();
        }

        public int CarrinhoId { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public ICollection<ItemCarrinho> Itens { get; set; }
    }
}
