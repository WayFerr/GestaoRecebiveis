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
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly GestaoRecebiveisAPIContext _context;

        public EmpresaRepository(GestaoRecebiveisAPIContext context)
        {
            _context = context;
        }

        public async Task<Empresa> CadastrarEmpresa(Empresa empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();

            return empresa;
        }

        public async Task<Empresa> ObterPorId(int id)
        {
            return await _context.Empresas.Include(x => x.RamoDeAtividade)
                .AsNoTracking().FirstOrDefaultAsync(x => x.EmpresaId == id);
        }
    }
}
