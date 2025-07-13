using GestaoRecebiveisAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Interfaces
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho> ObterCarrinhoPorEmpresaId(int empresaId);
        Task<Carrinho> AdicionarItem(int empresaId, int notaFiscalId);
        Task<Carrinho> RemoverItem(int empresaId, int notaFiscalId);
        Task<Carrinho> AdicionarCarrinho(int empresaId);
    }
}
