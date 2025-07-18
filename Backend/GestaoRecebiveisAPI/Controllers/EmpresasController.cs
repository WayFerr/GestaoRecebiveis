﻿using GestaoRecebiveisAPI.Application.DTOs.Request;
using GestaoRecebiveisAPI.Application.Interfaces;
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

        [HttpGet("{id}", Name = "ObterEmpresaPorId")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var empresa = await _empresaService.ObterPorId(id);
            if (empresa is null) return NotFound("Empresa não encontrada");

            return Ok(empresa);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] EmpresaRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var empresa = await _empresaService.CadastrarEmpresa(model);

            return new CreatedAtRouteResult("ObterEmpresaPorId", new { id = empresa.EmpresaId }, empresa);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CalcularLimite([FromRoute] int id)
        {
            var limite = await _empresaService.CalcularLimite(id);

            return Ok(limite);
        }
    }
}
