using GestaoRecebiveisAPI.Application.Interfaces;
using GestaoRecebiveisAPI.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRecebiveisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhosController : ControllerBase
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhosController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        [HttpGet("[action]/{empresaId}")]
        public async Task<IActionResult> Checkout([FromRoute] int empresaId)
        {
            var response = await _carrinhoService.RealizarCheckout(empresaId);
            return Ok(response);
        }

        [HttpPost("[action]/{empresaId}/{notaFiscalId}")]
        public async Task<IActionResult> AdicionarNota([FromRoute] int empresaId, [FromRoute] int notaFiscalId)
        {
            var totalCarrinho = await _carrinhoService.AdicionarNota(empresaId, notaFiscalId);
            return new CreatedAtRouteResult("ObterTotal", new { empresaId = totalCarrinho.EmpresaId }, totalCarrinho);
        }

        [HttpDelete("[action]/{empresaId}/{notaFiscalId}")]
        public async Task<IActionResult> RemoverNota([FromRoute] int empresaId, [FromRoute] int notaFiscalId)
        {
            var totalCarrinho = await _carrinhoService.RemoverNota(empresaId, notaFiscalId);
            return Ok(totalCarrinho);
        }

        [HttpGet("[action]/{empresaId}", Name = "ObterTotal")]
        public async Task<IActionResult> ObterTotal([FromRoute] int empresaId)
        {
            var totalCarrinho = await _carrinhoService.ObterTotalDoCarrinho(empresaId);
            return Ok(totalCarrinho);
        }
    }
}
