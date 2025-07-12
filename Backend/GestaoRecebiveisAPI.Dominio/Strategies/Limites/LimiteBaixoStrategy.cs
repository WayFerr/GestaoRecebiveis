using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Strategies.Limites
{
    public class LimiteBaixoStrategy : ILimiteStrategy
    {
        public bool PodeAplicar(decimal faturamento, string ramo) =>
            faturamento >= 10_000 && faturamento <= 50_000;

        public decimal CalcularLimite(decimal faturamento) => faturamento * 0.5m;
    }
}
