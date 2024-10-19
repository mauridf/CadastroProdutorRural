using CadastroProdutorRural.Data;
using CadastroProdutorRural.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Services;

public class FazendaService
{
    private readonly AppDbContext _context;

    public FazendaService(AppDbContext context)
    {
        _context = context;
    }

    // Método para cadastrar uma Fazenda
    public async Task<bool> CadastrarFazenda(Fazenda fazenda)
    {
        // Verifica se o Produtor existe
        var produtorExists = await _context.ProdutoresRurais.AnyAsync(p => p.Id == fazenda.IdProdutor);
        if (!produtorExists)
            return false;

        _context.Fazendas.Add(fazenda);
        await _context.SaveChangesAsync();
        return true;
    }

    // Método para buscar todas as Fazendas
    public async Task<List<Fazenda>> BuscarTodasFazendas()
    {
        return await _context.Fazendas.Include(f => f.IdProdutor).ToListAsync();
    }

    // Método para buscar Fazenda por ID
    public async Task<Fazenda> BuscarFazendaPorId(int id)
    {
        return await _context.Fazendas.FindAsync(id);
    }

    // Método para atualizar uma Fazenda
    public async Task<bool> Update(Fazenda fazenda)
    {
        var existingFazenda = await _context.Fazendas.FindAsync(fazenda.Id);
        if (existingFazenda == null)
            return false;

        // Atualiza as informações da Fazenda
        existingFazenda.Nome = fazenda.Nome;
        existingFazenda.IdProdutor = fazenda.IdProdutor;
        existingFazenda.AreaTotalHectares = fazenda.AreaTotalHectares;
        existingFazenda.AreaTotalAgricultavel = fazenda.AreaTotalAgricultavel;
        existingFazenda.AreaTotalVegetacao = fazenda.AreaTotalVegetacao;

        await _context.SaveChangesAsync();
        return true;
    }

    // Método para deletar uma Fazenda
    public async Task<bool> Delete(int id)
    {
        var fazenda = await _context.Fazendas.FindAsync(id);
        if (fazenda == null)
            return false;

        _context.Fazendas.Remove(fazenda);
        await _context.SaveChangesAsync();
        return true;
    }
}
