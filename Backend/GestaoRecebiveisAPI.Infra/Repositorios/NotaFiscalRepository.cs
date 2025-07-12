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
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly GestaoRecebiveisAPIContext _context;

        public NotaFiscalRepository(GestaoRecebiveisAPIContext context)
        {
            _context = context;
        }

        public async Task<NotaFiscal> CadastrarNotaFiscal(NotaFiscal notaFiscal)
        {
            await _context.NotasFiscais.AddAsync(notaFiscal);
            await _context.SaveChangesAsync();

            return notaFiscal;
        }

        public async Task<NotaFiscal> ObterPorId(int id)
        {
            return await _context.NotasFiscais.Include(x => x.Empresa)
                .AsNoTracking().FirstOrDefaultAsync(x => x.NotaFiscalId == id);
        }
    }
}
