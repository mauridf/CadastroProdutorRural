using CadastroProdutorRural.Data;
using CadastroProdutorRural.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Services
{
    public class FazendaCulturaService
    {
        private readonly AppDbContext _context;

        public FazendaCulturaService(AppDbContext context)
        {
            _context = context;
        }

        // Método para cadastrar uma FazendaCultura
        public async Task<bool> CadastrarFazendaCultura(FazendaCultura fazendaCultura)
        {
            _context.FazendaCulturas.Add(fazendaCultura);
            await _context.SaveChangesAsync();
            return true;
        }

        // Método para buscar todas as FazendaCulturas
        public async Task<List<FazendaCultura>> BuscarTodos()
        {
            return await _context.FazendaCulturas
                .Include(fc => fc.Fazenda)
                .Include(fc => fc.Cultura)
                .ToListAsync();
        }

        // Método para buscar FazendaCultura por ID
        public async Task<FazendaCultura> BuscarPorId(int id)
        {
            return await _context.FazendaCulturas
                .Include(fc => fc.Fazenda)
                .Include(fc => fc.Cultura)
                .FirstOrDefaultAsync(fc => fc.IdFazenda == id);
        }

        // Método para atualizar uma FazendaCultura
        public async Task<bool> Update(FazendaCultura fazendaCultura)
        {
            var existingFazendaCultura = await _context.FazendaCulturas.FindAsync(fazendaCultura.IdFazenda);
            if (existingFazendaCultura == null)
                return false;

            // Atualiza as informações da FazendaCultura
            existingFazendaCultura.IdCultura = fazendaCultura.IdCultura;
            existingFazendaCultura.AreaHectares = fazendaCultura.AreaHectares;

            await _context.SaveChangesAsync();
            return true;
        }

        // Método para deletar uma FazendaCultura
        public async Task<bool> Delete(int id)
        {
            var fazendaCultura = await _context.FazendaCulturas.FindAsync(id);
            if (fazendaCultura == null)
                return false;

            _context.FazendaCulturas.Remove(fazendaCultura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
