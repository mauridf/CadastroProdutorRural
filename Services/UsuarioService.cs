using CadastroProdutorRural.Data;
using CadastroProdutorRural.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Services;
public class UsuarioService
{
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;

    public UsuarioService(AppDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    // Cadastrar usuário com senha criptografada
    public async Task<bool> RegisterUsuario(Usuario usuario)
    {
        // Verifica se o email já está registrado
        if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
            return false;

        // Criptografa a senha
        usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash);
        usuario.DataDesativacao = null; // DataDesativacao inicialmente nula
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return true;
    }

    // Desativar usuário, marcando a DataDesativacao
    public async Task<bool> DesativarUsuario(int usuarioId)
    {
        var usuario = await _context.Usuarios.FindAsync(usuarioId);
        if (usuario == null || usuario.DataDesativacao != null)
            return false; // Retorna falso se o usuário não existir ou já estiver desativado

        usuario.DataDesativacao = DateTime.Now;
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return true;
    }

    // Ativar usuário, marcando a DataDesativacao
    public async Task<bool> AtivarUsuario(int usuarioId)
    {
        var usuario = await _context.Usuarios.FindAsync(usuarioId);
        if (usuario == null || usuario.DataDesativacao == null)
            return false; // Retorna falso se o usuário não existir ou já estiver ativado

        usuario.DataDesativacao = null;
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return true;
    }

    // Login com validação de email, senha e geração de token JWT
    public async Task<string?> Login(string email, string senha)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.DataDesativacao == null);
        if (usuario != null && BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
        {
            return _tokenService.CreateToken(usuario); // Gera o token JWT
        }
        return null;
    }

    // Pesquisar usuário pelo email
    public async Task<Usuario?> GetUsuarioByEmail(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }
}
