using GestaoRecebiveisAPI.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Interfaces
{
    public interface ICarrinhoService
    {
        Task<TotalCarrinhoResponse> AdicionarNota(int empresaId, int notaFiscalId);
        Task<TotalCarrinhoResponse> RemoverNota(int empresaId, int notaFiscalId);
        Task<TotalCarrinhoResponse> ObterTotalDoCarrinho(int empresaId);
    }
}
