using GestaoRecebiveisAPI.Domain.Entidades;
using GestaoRecebiveisAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Infra.Repositorios
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly GestaoRecebiveisAPIContext _context;

        public CarrinhoRepository(GestaoRecebiveisAPIContext context)
        {
            _context = context;
        }

        public async Task<Carrinho> AdicionarItem(int empresaId, int notaFiscalId)
        {
            var carrinho = await ObterCarrinhoPorEmpresaId(empresaId) ?? await AdicionarCarrinho(empresaId);

            if (carrinho.Itens.Any(i => i.NotaFiscalId == notaFiscalId))
                return carrinho;

            await _context.ItensCarrinhos.AddAsync(new ItemCarrinho { CarrinhoId = carrinho.CarrinhoId, NotaFiscalId = notaFiscalId });
            await _context.SaveChangesAsync();

            return carrinho;
        }

        public async Task<Carrinho> ObterCarrinhoPorEmpresaId(int empresaId)
        {
            return await _context.Carrinhos.Include(x => x.Itens).ThenInclude(i => i.NotaFiscal).AsNoTracking()
            .FirstOrDefaultAsync(x => x.EmpresaId == empresaId);
        }

        public async Task<Carrinho> RemoverItem(int empresaId, int notaFiscalId)
        {
            var carrinho = await ObterCarrinhoPorEmpresaId(empresaId);
            var item = carrinho?.Itens.FirstOrDefault(i => i.NotaFiscalId == notaFiscalId);
            if (item != null)
            {
                _context.ItensCarrinhos.Remove(item);
                await _context.SaveChangesAsync();

                return carrinho;
            }

            return carrinho;
        }

        public async Task<Carrinho> AdicionarCarrinho(int empresaId)
        {
            var carrinho = new Carrinho { EmpresaId = empresaId };

            _context.Carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();

            return carrinho;
        }

        public async Task<Carrinho> ObterCarrinhoComNotas(int empresaId)
        {
            return await _context.Carrinhos.Include(c => c.Empresa).Include(c => c.Itens)
            .ThenInclude(i => i.NotaFiscal).FirstOrDefaultAsync(c => c.EmpresaId == empresaId);
        }
    }
}
