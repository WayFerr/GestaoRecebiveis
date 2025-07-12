using GestaoRecebiveisAPI.Application.Interfaces;
using GestaoRecebiveisAPI.Domain.Entidades;
using GestaoRecebiveisAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Services
{
    public class RamoDeAtividadeService : IRamoDeAtividadeService
    {
        private readonly IRamoDeAtividadeRepository _ramoDeAtividadeRepository;

        public RamoDeAtividadeService(IRamoDeAtividadeRepository ramoDeAtividadeRepository)
        {
            _ramoDeAtividadeRepository = ramoDeAtividadeRepository;
        }

        public async Task<RamoDeAtividade> GarantirRamoDeAtividade(string descricao)
        {
            var ramo = await _ramoDeAtividadeRepository.ObterPorDescricao(descricao)
                ?? await _ramoDeAtividadeRepository.CadastrarRamoDeAtividade(descricao);

            return ramo;
        }
    }
}
