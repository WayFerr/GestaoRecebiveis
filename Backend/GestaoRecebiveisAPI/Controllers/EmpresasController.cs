using GestaoRecebiveisAPI.Application.DTOs.Request;
using GestaoRecebiveisAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoRecebiveisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresasController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("{id}", Name = "GetEmpresaById")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var empresa = await _empresaService.ObterPorId(id);
                if (empresa is null) return NotFound("Empresa não encontrada");

                return Ok(empresa);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpresaRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var empresa = await _empresaService.CadastrarEmpresa(model);

                return new CreatedAtRouteResult("GetEmpresaById", new { id = empresa.EmpresaId }, empresa);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado");
            }
        }
    }
}
