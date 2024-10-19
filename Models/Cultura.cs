using System.ComponentModel.DataAnnotations;

namespace CadastroProdutorRural.Models;

public class Cultura
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome da Cultura é obrigatório.")]
    public string Nome { get; set; }

    public string Observacao { get; set; } // Campo não obrigatório
}
