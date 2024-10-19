using CadastroProdutorRural.Data;
using CadastroProdutorRural.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Services
{
    public class DashBoardService
    {
        private readonly AppDbContext _context;

        public DashBoardService(AppDbContext context)
        {
            _context = context;
        }

        // Total de fazendas cadastradas
        public async Task<int> TotalFazendas()
        {
            return await _context.Fazendas.CountAsync();
        }

        // Total de hectares de todas as fazendas
        public async Task<double> TotalHectaresFazendas()
        {
            return await _context.Fazendas.SumAsync(f => f.AreaTotalHectares);
        }

        // Total de produtores rurais cadastrados por estado (UF)
        public async Task<Dictionary<string, int>> TotalProdutoresPorEstado()
        {
            return await _context.ProdutoresRurais
                .GroupBy(p => p.UF)
                .Select(g => new
                {
                    Estado = g.Key,
                    Total = g.Count()
                })
                .ToDictionaryAsync(g => g.Estado, g => g.Total);
        }

        // Total de culturas plantadas, separado por cultura
        public async Task<Dictionary<string, double>> TotalCulturasPlantadas() // Mudei para double
        {
            return await _context.FazendaCulturas
                .Include(fc => fc.Cultura)
                .GroupBy(fc => fc.Cultura.Nome)
                .Select(g => new
                {
                    Cultura = g.Key,
                    Total = g.Sum(fc => fc.AreaHectares) // Total da área destinada àquela cultura
                })
                .ToDictionaryAsync(g => g.Cultura, g => (double)g.Total); // A conversão para double
        }

        // Total de uso do solo
        public async Task<object> TotalUsoSolo()
        {
            var totalAgricultavel = await _context.Fazendas.SumAsync(f => f.AreaTotalAgricultavel);
            var totalVegetacao = await _context.Fazendas.SumAsync(f => f.AreaTotalVegetacao);
            var totalCulturas = await _context.FazendaCulturas.SumAsync(fc => fc.AreaHectares);

            return new
            {
                AreaAgricultavel = totalAgricultavel,
                AreaVegetacao = totalVegetacao,
                AreaDestinadaCulturas = totalCulturas
            };
        }
    }
}