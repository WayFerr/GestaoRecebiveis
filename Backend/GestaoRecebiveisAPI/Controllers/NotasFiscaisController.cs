using GestaoRecebiveisAPI.Application.DTOs.Request;
using GestaoRecebiveisAPI.Application.Interfaces;
using GestaoRecebiveisAPI.Application.Services;
using GestaoRecebiveisAPI.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRecebiveisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasFiscaisController : ControllerBase
    {
        private readonly INotaFiscalService _notaFiscalService;

        public NotasFiscaisController(INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet("{id}", Name = "GetNotaFiscalById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var notaFiscal = await _notaFiscalService.ObterPorId(id);
            if (notaFiscal is null) return NotFound("Nota fiscal não encontrada");

            return Ok(notaFiscal);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CadastrarNotaFiscal([FromBody] NotaFiscalRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var notaFiscal = await _notaFiscalService.CadastrarNotaFiscal(model);

            return new CreatedAtRouteResult("GetNotaFiscalById", new { id = notaFiscal.NotaFiscalId}, notaFiscal);
        }
    }
}
