using GestaoRecebiveisAPI.Application.DTOs.Response;
using GestaoRecebiveisAPI.Application.Interfaces;
using GestaoRecebiveisAPI.Domain.Entidades;
using GestaoRecebiveisAPI.Domain.Interfaces;
using GestaoRecebiveisAPI.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly GestaoRecebiveisAPIContext _context;
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IEmpresaService _empresaService;
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public CarrinhoService(GestaoRecebiveisAPIContext context, ICarrinhoRepository carrinhoRepository, IEmpresaService empresaService,
            INotaFiscalRepository notaFiscalRepository)
        {
            _context = context;
            _carrinhoRepository = carrinhoRepository;
            _empresaService = empresaService;
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<TotalCarrinhoResponse> AdicionarNota(int empresaId, int notaFiscalId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var carrinho = await _carrinhoRepository.ObterCarrinhoPorEmpresaId(empresaId);

                var totalAtual = carrinho?.Itens.Sum(i => i.NotaFiscal.Valor) ?? 0;

                var notaFiscal = carrinho?.Itens.Select(x => x.NotaFiscal)
                    .FirstOrDefault(n => n.NotaFiscalId == notaFiscalId);

                if (notaFiscal == null)
                {
                    notaFiscal = await _notaFiscalRepository.ObterPorId(notaFiscalId);
                    if (notaFiscal == null || notaFiscal.EmpresaId != empresaId)
                        throw new Exception("Nota inválida");
                }

                var limite = await _empresaService.CalcularLimite(empresaId);

                if (totalAtual + notaFiscal.Valor > limite.LimiteAntecipacao)
                    throw new InvalidOperationException("Valor total ultrapassa o limite de crédito da empresa.");

                carrinho = await _carrinhoRepository.AdicionarItem(empresaId, notaFiscalId);
                await transaction.CommitAsync();

                var response = new TotalCarrinhoResponse()
                {
                    CarrinhoId = carrinho.CarrinhoId,
                    EmpresaId = empresaId,
                    TotalCarrinho = totalAtual + notaFiscal.Valor
                };

                return response;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<TotalCarrinhoResponse> ObterTotalDoCarrinho(int empresaId)
        {
            var carrinho = await _carrinhoRepository.ObterCarrinhoPorEmpresaId(empresaId);

            var carrinhoResponse = new TotalCarrinhoResponse()
            {
                CarrinhoId = carrinho.CarrinhoId,
                EmpresaId = empresaId,
                TotalCarrinho = carrinho?.Itens.Sum(i => i.NotaFiscal.Valor) ?? 0
            };

            return carrinhoResponse;
        }

        public async Task<TotalCarrinhoResponse> RemoverNota(int empresaId, int notaFiscalId)
        {
            var carrinho = await _carrinhoRepository.RemoverItem(empresaId, notaFiscalId);

            var totalAtual = carrinho?.Itens.Sum(i => i.NotaFiscal.Valor) ?? 0;

            var response = new TotalCarrinhoResponse()
            {
                CarrinhoId = carrinho.CarrinhoId,
                EmpresaId = empresaId,
                TotalCarrinho = totalAtual
            };

            return response;
        }
    }
}
