using System.ComponentModel.DataAnnotations;

namespace CadastroProdutorRural.Models;

public class Fazenda
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome da Fazenda é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Id do Produtor é obrigatório.")]
    public int IdProdutor { get; set; }

    [Required(ErrorMessage = "Área Total em Hectares é obrigatória.")]
    public double AreaTotalHectares { get; set; }

    [Required(ErrorMessage = "Área Total Agricultável é obrigatória.")]
    public double AreaTotalAgricultavel { get; set; }

    [Required(ErrorMessage = "Área Total de Vegetação é obrigatória.")]
    public double AreaTotalVegetacao { get; set; }
}
