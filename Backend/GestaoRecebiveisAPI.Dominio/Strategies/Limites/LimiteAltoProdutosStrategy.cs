using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Domain.Strategies.Limites
{
    public class LimiteAltoProdutosStrategy : ILimiteStrategy
    {
        public bool PodeAplicar(decimal faturamento, string ramo) =>
            faturamento > 100_000 && ramo.Equals("Produtos", StringComparison.OrdinalIgnoreCase);

        public decimal CalcularLimite(decimal faturamento) => faturamento * 0.65m;
    }
}
