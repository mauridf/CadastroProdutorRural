using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CadastroProdutorRural.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace CadastroProdutorRural.Services;

public interface ITokenService
{
    string CreateToken(Usuario usuario);
}
public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateToken(Usuario usuario)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Role) // Inclua a role se necessário
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
