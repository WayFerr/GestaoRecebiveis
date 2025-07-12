using AutoMapper;
using GestaoRecebiveisAPI.Application.DTOs.Request;
using GestaoRecebiveisAPI.Application.DTOs.Response;
using GestaoRecebiveisAPI.Application.Interfaces;
using GestaoRecebiveisAPI.Domain.Entidades;
using GestaoRecebiveisAPI.Domain.Interfaces;
using GestaoRecebiveisAPI.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly IMapper _mapper;
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService(IMapper mapper, INotaFiscalRepository notaFiscalRepository)
        {
            _mapper = mapper;
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<NotaFiscalResponse> CadastrarNotaFiscal(NotaFiscalRequest model)
        {
            var notaFiscal = _mapper.Map<NotaFiscal>(model);

            notaFiscal = await _notaFiscalRepository.CadastrarNotaFiscal(notaFiscal);

            return _mapper.Map<NotaFiscalResponse>(notaFiscal);
        }

        public async Task<NotaFiscalResponse> ObterPorId(int id)
        {
            var notaFiscal = await _notaFiscalRepository.ObterPorId(id);
            var notaFiscalResponse = _mapper.Map<NotaFiscalResponse>(notaFiscal);

            return notaFiscalResponse;
        }
    }
}
