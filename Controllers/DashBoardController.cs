using CadastroProdutorRural.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutorRural.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashBoardController : ControllerBase
    {
        private readonly DashBoardService _dashBoardService;

        public DashBoardController(DashBoardService dashBoardService)
        {
            _dashBoardService = dashBoardService;
        }

        // Endpoint para obter total de fazendas cadastradas
        [HttpGet("total-fazendas")]
        public async Task<IActionResult> TotalFazendas()
        {
            var total = await _dashBoardService.TotalFazendas();
            return Ok(new { TotalFazendas = total });
        }

        // Endpoint para obter total de hectares de todas as fazendas
        [HttpGet("total-hectares-fazendas")]
        public async Task<IActionResult> TotalHectaresFazendas()
        {
            var totalHectares = await _dashBoardService.TotalHectaresFazendas();
            return Ok(new { TotalHectares = totalHectares });
        }

        // Endpoint para obter total de produtores rurais cadastrados por estado (UF)
        [HttpGet("produtores-por-estado")]
        public async Task<IActionResult> TotalProdutoresPorEstado()
        {
            var totalPorEstado = await _dashBoardService.TotalProdutoresPorEstado();
            return Ok(totalPorEstado);
        }

        // Endpoint para obter total de culturas plantadas, separado por cultura
        [HttpGet("culturas-plantadas")]
        public async Task<IActionResult> TotalCulturasPlantadas()
        {
            var totalCulturas = await _dashBoardService.TotalCulturasPlantadas();
            return Ok(totalCulturas);
        }

        // Endpoint para obter total de uso do solo
        [HttpGet("uso-solo")]
        public async Task<IActionResult> TotalUsoSolo()
        {
            var usoSolo = await _dashBoardService.TotalUsoSolo();
            return Ok(usoSolo);
        }
    }
}
