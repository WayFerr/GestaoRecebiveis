using GestaoRecebiveisAPI.Application.DTOs.Response;
using GestaoRecebiveisAPI.Domain.Entidades;

namespace GestaoRecebiveisAPI.Application.Extensions
{
    public static class CalcularNotaExtension
    {
        private const decimal _taxa = 0.0465m;

        public static List<NotaFiscalCheckoutResponse> CalcularNotas(this Carrinho carrinho)
        {
            var notasCalculadas = new List<NotaFiscalCheckoutResponse>();
            var hoje = DateTime.Today;

            foreach (var item in carrinho.Itens)
            {
                var nf = item.NotaFiscal;

                var prazo = (nf.DtVencimento - hoje).Days;
                prazo = Math.Max(prazo, 0);

                var fator = (decimal)Math.Pow((double)(1 + _taxa), prazo / 30.0);
                var valorLiquido = nf.Valor / fator;

                notasCalculadas.Add(new NotaFiscalCheckoutResponse
                {
                    Numero = nf.Numero,
                    ValorBruto = nf.Valor,
                    ValorLiquido = Math.Round(valorLiquido, 2)
                });
            }

            return notasCalculadas;
        }
    }
}
