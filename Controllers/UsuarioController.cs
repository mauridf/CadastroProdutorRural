using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CadastroProdutorRural.Models;
using CadastroProdutorRural.Services;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    // Endpoint para cadastrar usuário
    [HttpPost("cadastrar-usuario")]
    public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario usuario)
    {
        try
        {
            if (usuario == null)
                return BadRequest("Usuário não pode ser nulo.");

            var success = await _usuarioService.RegisterUsuario(usuario);
            if (success)
            {
                return Ok("Usuário registrado com sucesso!");
            }
            return BadRequest("Erro ao registrar o usuário. Verifique se o email já está em uso.");
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
            return StatusCode(500, $"Erro ao registrar o usuário: {ex.Message}");
        }
    }

    // Endpoint para desativar um usuário
    [HttpPost("desativar/{id}")]
    public async Task<IActionResult> DesativarUsuario(int id)
    {
        try
        {
            var success = await _usuarioService.DesativarUsuario(id);
            if (success)
            {
                return Ok("Usuário desativado com sucesso.");
            }
            return NotFound("Usuário não encontrado ou já desativado.");
        }
        catch (DbUpdateException dbEx)
        {
            return StatusCode(500, $"Erro ao salvar no banco de dados: {dbEx.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao desativar o usuário: {ex.Message}");
        }
    }

    // Endpoint para ativar um usuário
    [HttpPost("ativar/{id}")]
    public async Task<IActionResult> AtivarUsuario(int id)
    {
        try
        {
            var success = await _usuarioService.AtivarUsuario(id);
            if (success)
            {
                return Ok("Usuário Ativado com sucesso.");
            }
            return NotFound("Usuário não encontrado ou já ativado.");
        }
        catch (DbUpdateException dbEx)
        {
            return StatusCode(500, $"Erro ao salvar no banco de dados: {dbEx.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao desativar o usuário: {ex.Message}");
        }
    }

    // Endpoint para login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string senha)
    {
        try
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                return BadRequest("Email e senha são obrigatórios.");

            var token = await _usuarioService.Login(email, senha);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return Unauthorized("Email ou senha inválidos.");
        }
        catch (ArgumentException argEx)
        {
            return BadRequest($"Erro de argumento: {argEx.Message}");
        }
        catch (DbUpdateException dbEx)
        {
            return StatusCode(500, $"Erro ao acessar o banco de dados: {dbEx.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao efetuar login: {ex.Message}");
        }
    }

    // Novo endpoint para buscar um usuário pelo email
    [HttpGet("buscar-por-email")]
    public async Task<IActionResult> GetUsuarioByEmail(string email)
    {
        try
        {
            var usuario = await _usuarioService.GetUsuarioByEmail(email);
            if (usuario != null)
                return Ok(usuario);
            return NotFound("Usuário não encontrado.");
        }
        catch (ArgumentException argEx)
        {
            return BadRequest($"Erro de argumento: {argEx.Message}");
        }
        catch (DbUpdateException dbEx)
        {
            return StatusCode(500, $"Erro ao acessar o banco de dados: {dbEx.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro no servidor: {ex.Message}");
        }
    }
}
