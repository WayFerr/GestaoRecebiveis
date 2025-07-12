using GestaoRecebiveisAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Interfaces
{
    public interface INotaFiscalRepository
    {
        Task<NotaFiscal> CadastrarNotaFiscal(NotaFiscal notaFiscal);
        Task<NotaFiscal> ObterPorId(int id);
    }
}
