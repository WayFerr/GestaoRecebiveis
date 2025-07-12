using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Strategies.Limites
{
    public interface ILimiteStrategy
    {
        bool PodeAplicar(decimal faturamento, string ramo);
        decimal CalcularLimite(decimal faturamento);
    }
}
