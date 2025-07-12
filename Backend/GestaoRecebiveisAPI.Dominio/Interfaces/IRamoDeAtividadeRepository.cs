using GestaoRecebiveisAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Interfaces
{
    public interface IRamoDeAtividadeRepository
    {
        Task<RamoDeAtividade> ObterPorId(int id);
        Task<RamoDeAtividade> ObterPorDescricao(string descricao);
        Task<RamoDeAtividade> CadastrarRamoDeAtividade(string descricao);
    }
}
