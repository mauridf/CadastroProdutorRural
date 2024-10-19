using System.ComponentModel.DataAnnotations;

namespace CadastroProdutorRural.Models;

public class ProdutorRural
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome do Produtor Rural é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "CPF é obrigatório.")]
    public string CPF { get; set; }

    public string NomeFantasia { get; set; } // Campo não obrigatório

    public string CNPJ { get; set; } // Campo não obrigatório

    [Required(ErrorMessage = "Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Telefone é obrigatório.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Endereço é obrigatório.")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "Cidade é obrigatória.")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "UF é obrigatória.")]
    public string UF { get; set; }

    [Required(ErrorMessage = "CEP é obrigatório.")]
    public string CEP { get; set; }
}
