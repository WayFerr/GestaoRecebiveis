using AutoMapper;
using GestaoRecebiveisAPI.Application.DTOs.Request;
using GestaoRecebiveisAPI.Application.DTOs.Response;
using GestaoRecebiveisAPI.Application.Interfaces;
using GestaoRecebiveisAPI.Domain.Entidades;
using GestaoRecebiveisAPI.Domain.Interfaces;
using GestaoRecebiveisAPI.Domain.Strategies.Limites;
using GestaoRecebiveisAPI.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly GestaoRecebiveisAPIContext _context;
        private readonly IMapper _mapper;
        private readonly IEnumerable<ILimiteStrategy> _strategies;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IRamoDeAtividadeService _ramoDeAtividadeService;

        public EmpresaService(GestaoRecebiveisAPIContext context, IMapper mapper, IEnumerable<ILimiteStrategy> strategies,
            IEmpresaRepository empresaRepository, IRamoDeAtividadeService ramoDeAtividadeService)
        {
            _mapper = mapper;
            _context = context;
            _strategies = strategies;
            _empresaRepository = empresaRepository;
            _ramoDeAtividadeService = ramoDeAtividadeService;
        }

        public async Task<EmpresaResponse> CadastrarEmpresa(EmpresaRequest model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var ramo = await _ramoDeAtividadeService.GarantirRamoDeAtividade(model.DsRamoAtividade.Trim());
                var empresa = _mapper.Map<Empresa>(model);
                empresa.RamoAtividadeId = ramo.RamoAtividadeId;

                empresa = await _empresaRepository.CadastrarEmpresa(empresa);
                var response = _mapper.Map<EmpresaResponse>(empresa);

                await transaction.CommitAsync();
                return response;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<EmpresaResponse> ObterPorId(int id)
        {
            var empresa = await _empresaRepository.ObterPorId(id);
            var empresaResponse = _mapper.Map<EmpresaResponse>(empresa);

            return empresaResponse;
        }

        public async Task<LimiteEmpresaResponse> CalcularLimite(int id)
        {
            var empresa = await _empresaRepository.ObterPorId(id) ?? throw new Exception("Empresa não encontrada.");

            var regraCalculo = _strategies.FirstOrDefault(x => x.PodeAplicar(empresa.FaturamentoMensal, empresa.RamoDeAtividade.Descricao));

            if (regraCalculo is null)
                throw new InvalidOperationException("Nenhuma regra de limite aplicável encontrada.");

            var limiteResponse = new LimiteEmpresaResponse()
            {
                Id = empresa.EmpresaId,
                Nome = empresa.Nome,
                LimiteAntecipacao = regraCalculo.CalcularLimite(empresa.FaturamentoMensal)
            };

            return limiteResponse;
        }
    }
}
