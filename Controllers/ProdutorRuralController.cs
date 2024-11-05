using CadastroProdutorRural.Models;
using CadastroProdutorRural.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CadastroProdutorRural.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutorRuralController : ControllerBase
{
    private readonly ProdutorRuralService _produtorRuralService;

    public ProdutorRuralController(ProdutorRuralService produtorRuralService)
    {
        _produtorRuralService = produtorRuralService;
    }

    // Endpoint para cadastrar Produtor Rural
    [HttpPost("cadastrar")]
    public async Task<IActionResult> Cadastrar([FromBody] ProdutorRural produtor)
    {
        try
        {
            var result = await _produtorRuralService.CadastrarProdutor(produtor);
            if (result)
                return Ok("Produtor Rural cadastrado com sucesso!");
            return BadRequest("CPF/CNPJ inválido ou Email já cadastrado.");
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
            return StatusCode(500, $"Erro no servidor: {ex.Message}");
        }
    }

    // Endpoint para buscar todos os Produtores Rurais
    [HttpGet("buscar-todos")]
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var produtores = await _produtorRuralService.BuscarTodos();
            return Ok(produtores);
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
            return StatusCode(500, $"Erro no servidor: {ex.Message}");
        }
    }

    // Endpoint para buscar Produtor Rural por ID
    [HttpGet("buscar-por-id/{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        try
        {
            var produtor = await _produtorRuralService.BuscarPorId(id);
            if (produtor != null)
                return Ok(produtor);
            return NotFound("Produtor Rural não encontrado.");
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
            return StatusCode(500, $"Erro no servidor: {ex.Message}");
        }
    }

    // Endpoint para buscar Produtor Rural por CPF
    [HttpGet("buscar-por-cpf/{cpf}")]
    public async Task<IActionResult> BuscarPorCPF(string cpf)
    {
        try
        {
            var produtor = await _produtorRuralService.BuscarPorCPF(cpf);
            if (produtor != null)
                return Ok(produtor);
            return NotFound("Produtor Rural não encontrado.");
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
            return StatusCode(500, $"Erro no servidor: {ex.Message}");
        }
    }

    // Endpoint para buscar Produtor Rural por CNPJ
    [HttpGet("buscar-por-cnpj/{cnpj}")]
    public async Task<IActionResult> BuscarPorCNPJ(string cnpj)
    {
        try
        {
            var produtor = await _produtorRuralService.BuscarPorCNPJ(cnpj);
            if (produtor != null)
                return Ok(produtor);
            return NotFound("Produtor Rural não encontrado.");
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
            return StatusCode(500, $"Erro no servidor: {ex.Message}");
        }
    }

    // Endpoint para atualizar um Produtor Rural
    [HttpPut("atualizar/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProdutorRural produtor)
    {
        try
        {
            produtor.Id = id;
            var result = await _produtorRuralService.Update(produtor);
            if (result)
                return Ok("Produtor Rural atualizado com sucesso!");
            return NotFound("Produtor Rural não encontrado.");
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
            return StatusCode(500, $"Erro no servidor: {ex.Message}");
        }
    }

    // Endpoint para deletar um Produtor Rural
    [HttpDelete("deletar/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _produtorRuralService.Delete(id);
            if (result)
                return Ok("Produtor Rural deletado com sucesso!");
            return NotFound("Produtor Rural não encontrado.");
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
            return StatusCode(500, $"Erro no servidor: {ex.Message}");
        }
    }
}
