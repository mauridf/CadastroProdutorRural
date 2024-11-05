using CadastroProdutorRural.Models;
using CadastroProdutorRural.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FazendaCulturaController : ControllerBase
    {
        private readonly FazendaCulturaService _fazendaCulturaService;

        public FazendaCulturaController(FazendaCulturaService fazendaCulturaService)
        {
            _fazendaCulturaService = fazendaCulturaService;
        }

        // Endpoint para cadastrar uma FazendaCultura
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] FazendaCultura fazendaCultura)
        {
            try
            {
                await _fazendaCulturaService.CadastrarFazendaCultura(fazendaCultura);
                return Ok("FazendaCultura cadastrada com sucesso!");
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

        // Endpoint para buscar todas as FazendaCulturas
        [HttpGet("todas")]
        public async Task<ActionResult<List<FazendaCultura>>> BuscarTodos()
        {
            try
            {
                var fazendaCulturas = await _fazendaCulturaService.BuscarTodos();
                return Ok(fazendaCulturas);
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

        // Endpoint para buscar FazendaCultura por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<FazendaCultura>> BuscarPorId(int id)
        {
            try
            {
                var fazendaCultura = await _fazendaCulturaService.BuscarPorId(id);
                if (fazendaCultura == null)
                    return NotFound("FazendaCultura não encontrada.");

                return Ok(fazendaCultura);
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

        // Endpoint para atualizar uma FazendaCultura
        [HttpPut("atualizar")]
        public async Task<IActionResult> Update([FromBody] FazendaCultura fazendaCultura)
        {
            try
            {
                var result = await _fazendaCulturaService.Update(fazendaCultura);
                if (!result)
                    return NotFound("FazendaCultura não encontrada.");

                return Ok("FazendaCultura atualizada com sucesso!");
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

        // Endpoint para deletar uma FazendaCultura
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _fazendaCulturaService.Delete(id);
                if (!result)
                    return NotFound("FazendaCultura não encontrada.");

                return Ok("FazendaCultura deletada com sucesso!");
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
