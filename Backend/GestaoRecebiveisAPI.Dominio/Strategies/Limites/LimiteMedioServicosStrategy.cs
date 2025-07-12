using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Strategies.Limites
{
    public class LimiteMedioServicosStrategy : ILimiteStrategy
    {
        public bool PodeAplicar(decimal faturamento, string ramo) =>
            faturamento > 50_000 && faturamento <= 100_000 && ramo.Equals("Serviços", StringComparison.OrdinalIgnoreCase);

        public decimal CalcularLimite(decimal faturamento) => faturamento * 0.55m;
    }

}
