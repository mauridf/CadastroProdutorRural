using System.ComponentModel.DataAnnotations;

namespace CadastroProdutorRural.Models;

public class FazendaCultura
{
    [Required(ErrorMessage = "Id da Fazenda é obrigatório.")]
    public int IdFazenda { get; set; }
    public Fazenda Fazenda { get; set; }

    [Required(ErrorMessage = "Id da Cultura é obrigatório.")]
    public int IdCultura { get; set; }
    public Cultura Cultura { get; set; }

    [Required(ErrorMessage = "Área em Hectares é obrigatória.")]
    public double AreaHectares { get; set; }
}
