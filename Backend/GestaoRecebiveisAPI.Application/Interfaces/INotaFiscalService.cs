using GestaoRecebiveisAPI.Application.DTOs.Request;
using GestaoRecebiveisAPI.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Interfaces
{
    public interface INotaFiscalService
    {
        Task<NotaFiscalResponse> ObterPorId(int id);
        Task<NotaFiscalResponse> CadastrarNotaFiscal(NotaFiscalRequest model);
    }
}
