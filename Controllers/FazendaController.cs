﻿using CadastroProdutorRural.Models;
using CadastroProdutorRural.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutorRural.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FazendaController : ControllerBase
{
    private readonly FazendaService _fazendaService;

    public FazendaController(FazendaService fazendaService)
    {
        _fazendaService = fazendaService;
    }

    // Endpoint para cadastrar uma Fazenda
    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] Fazenda fazenda)
    {
        try
        {
            var result = await _fazendaService.CadastrarFazenda(fazenda);
            if (!result)
                return BadRequest("Produtor não encontrado ou erro ao cadastrar a fazenda.");

            return Ok("Fazenda cadastrada com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    // Endpoint para buscar todas as Fazendas
    [HttpGet("todas")]
    public async Task<ActionResult<List<Fazenda>>> BuscarTodasFazendas()
    {
        try
        {
            var fazendas = await _fazendaService.BuscarTodasFazendas();
            return Ok(fazendas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    // Endpoint para buscar Fazenda por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Fazenda>> BuscarFazendaPorId(int id)
    {
        try
        {
            var fazenda = await _fazendaService.BuscarFazendaPorId(id);
            if (fazenda == null)
                return NotFound("Fazenda não encontrada.");

            return Ok(fazenda);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    // Endpoint para atualizar uma Fazenda
    [HttpPut("atualizar")]
    public async Task<IActionResult> Update([FromBody] Fazenda fazenda)
    {
        try
        {
            var result = await _fazendaService.Update(fazenda);
            if (!result)
                return NotFound("Fazenda não encontrada.");

            return Ok("Fazenda atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    // Endpoint para deletar uma Fazenda
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _fazendaService.Delete(id);
            if (!result)
                return NotFound("Fazenda não encontrada.");

            return Ok("Fazenda deletada com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}
