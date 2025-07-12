using GestaoRecebiveisAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Application.Interfaces
{
    public interface IRamoDeAtividadeService
    {
        Task<RamoDeAtividade> GarantirRamoDeAtividade(string descricao);
    }
}
