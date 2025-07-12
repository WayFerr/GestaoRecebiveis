using GestaoRecebiveisAPI.Application.DTOs.Request;
using GestaoRecebiveisAPI.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<EmpresaResponse> CadastrarEmpresa(EmpresaRequest model);
        Task<EmpresaResponse> ObterPorId(int id);
        Task<LimiteEmpresaResponse> CalcularLimite(int id);
    }
}
