﻿using CadastroProdutorRural.Models;
using CadastroProdutorRural.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CulturaController : ControllerBase
    {
        private readonly CulturaService _culturaService;

        public CulturaController(CulturaService culturaService)
        {
            _culturaService = culturaService;
        }

        // Endpoint para cadastrar uma Cultura
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Cultura cultura)
        {
            try
            {
                var result = await _culturaService.CadastrarCultura(cultura);
                return Ok("Cultura cadastrada com sucesso!");
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Erro ao salvar no banco de dados: {dbEx.Message}");
            }
            catch (ArgumentException argEx)
            {
                return BadRequest($"Erro de argumento: {argEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // Endpoint para buscar todas as Culturas
        [HttpGet("todas")]
        public async Task<ActionResult<List<Cultura>>> BuscarTodos()
        {
            try
            {
                var culturas = await _culturaService.BuscarTodos();
                return Ok(culturas);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Erro ao salvar no banco de dados: {dbEx.Message}");
            }
            catch (ArgumentException argEx)
            {
                return BadRequest($"Erro de argumento: {argEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // Endpoint para buscar Cultura por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cultura>> BuscarPorId(int id)
        {
            try
            {
                var cultura = await _culturaService.BuscarPorId(id);
                if (cultura == null)
                    return NotFound("Cultura não encontrada.");

                return Ok(cultura);
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Erro ao salvar no banco de dados: {dbEx.Message}");
            }
            catch (ArgumentException argEx)
            {
                return BadRequest($"Erro de argumento: {argEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // Endpoint para atualizar uma Cultura
        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cultura cultura)
        {
            try
            {
                cultura.Id = id;
                var result = await _culturaService.Update(cultura);
                if (!result)
                    return NotFound("Cultura não encontrada.");

                return Ok("Cultura atualizada com sucesso!");
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Erro ao salvar no banco de dados: {dbEx.Message}");
            }
            catch (ArgumentException argEx)
            {
                return BadRequest($"Erro de argumento: {argEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // Endpoint para deletar uma Cultura
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _culturaService.Delete(id);
                if (!result)
                    return NotFound("Cultura não encontrada.");

                return Ok("Cultura deletada com sucesso!");
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, $"Erro ao salvar no banco de dados: {dbEx.Message}");
            }
            catch (ArgumentException argEx)
            {
                return BadRequest($"Erro de argumento: {argEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
