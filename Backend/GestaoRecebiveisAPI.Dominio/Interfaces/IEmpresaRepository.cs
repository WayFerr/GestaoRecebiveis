using GestaoRecebiveisAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<Empresa> CadastrarEmpresa(Empresa empresa);
        Task<Empresa> ObterPorId(int id);
    }
}
