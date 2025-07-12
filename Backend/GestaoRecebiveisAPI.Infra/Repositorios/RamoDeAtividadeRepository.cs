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
    public class RamoDeAtividadeRepository : IRamoDeAtividadeRepository
    {
        private readonly GestaoRecebiveisAPIContext _context;

        public RamoDeAtividadeRepository(GestaoRecebiveisAPIContext context)
        {
            _context = context;
        }

        public async Task<RamoDeAtividade> CadastrarRamoDeAtividade(string descricao)
        {
            var ramo = new RamoDeAtividade() { Descricao = descricao };

            await _context.RamosDeAtividade.AddAsync(ramo);
            await _context.SaveChangesAsync();

            return ramo;
        }

        public async Task<RamoDeAtividade> ObterPorDescricao(string descricao)
        {
            return await _context.RamosDeAtividade.AsNoTracking().FirstOrDefaultAsync(x => x.Descricao == descricao);
        }

        public async Task<RamoDeAtividade> ObterPorId(int id)
        {
            return await _context.RamosDeAtividade.AsNoTracking().FirstOrDefaultAsync(x => x.RamoAtividadeId == id);
        }
    }
}
