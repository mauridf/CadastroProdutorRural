using CadastroProdutorRural.Data;
using CadastroProdutorRural.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Services
{
    public class CulturaService
    {
        private readonly AppDbContext _context;

        public CulturaService(AppDbContext context)
        {
            _context = context;
        }

        // Método para cadastrar uma Cultura
        public async Task<bool> CadastrarCultura(Cultura cultura)
        {
            _context.Culturas.Add(cultura);
            await _context.SaveChangesAsync();
            return true;
        }

        // Método para buscar todas as Culturas
        public async Task<List<Cultura>> BuscarTodos()
        {
            return await _context.Culturas.ToListAsync();
        }

        // Método para buscar Cultura por ID
        public async Task<Cultura> BuscarPorId(int id)
        {
            return await _context.Culturas.FindAsync(id);
        }

        // Método para atualizar uma Cultura
        public async Task<bool> Update(Cultura cultura)
        {
            var existingCultura = await _context.Culturas.FindAsync(cultura.Id);
            if (existingCultura == null)
                return false;

            // Atualiza as informações da Cultura
            existingCultura.Nome = cultura.Nome;
            existingCultura.Observacao = cultura.Observacao;

            await _context.SaveChangesAsync();
            return true;
        }

        // Método para deletar uma Cultura
        public async Task<bool> Delete(int id)
        {
            var cultura = await _context.Culturas.FindAsync(id);
            if (cultura == null)
                return false;

            _context.Culturas.Remove(cultura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
