using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace CadastroProdutorRural.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória.")]
    public string SenhaHash { get; set; }

    [Required(ErrorMessage = "Role é obrigatória.")]
    public string Role { get; set; }

    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public DateTime? DataDesativacao { get; set; }
}
