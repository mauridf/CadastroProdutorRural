using CadastroProdutorRural.Data;
using CadastroProdutorRural.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CadastroProdutorRural.Services;

public class ProdutorRuralService
{
    private readonly AppDbContext _context;

    public ProdutorRuralService(AppDbContext context)
    {
        _context = context;
    }

    // Método para cadastrar o Produtor Rural
    public async Task<bool> CadastrarProdutor(ProdutorRural produtor)
    {
        // Verifica se o CPF é válido (CNPJ não precisa ser verificado se for nulo ou em branco)
        if (!ValidarCPF(produtor.CPF))
            return false;

        // Verifica se o CNPJ é válido apenas se não for nulo ou em branco
        if (!string.IsNullOrWhiteSpace(produtor.CNPJ) && !ValidarCNPJ(produtor.CNPJ))
            return false;

        // Verifica se o email já está registrado
        if (await _context.ProdutoresRurais.AnyAsync(p => p.Email == produtor.Email))
            return false;

        _context.ProdutoresRurais.Add(produtor);
        await _context.SaveChangesAsync();
        return true;
    }

    // Método para buscar todos os Produtores Rurais
    public async Task<List<ProdutorRural>> BuscarTodos()
    {
        return await _context.ProdutoresRurais.ToListAsync();
    }

    // Método para buscar Produtor Rural por ID
    public async Task<ProdutorRural> BuscarPorId(int id)
    {
        return await _context.ProdutoresRurais.FindAsync(id);
    }

    // Método para buscar Produtor Rural por CPF
    public async Task<ProdutorRural> BuscarPorCPF(string cpf)
    {
        return await _context.ProdutoresRurais.FirstOrDefaultAsync(p => p.CPF == cpf);
    }

    // Método para buscar Produtor Rural por CNPJ
    public async Task<ProdutorRural> BuscarPorCNPJ(string cnpj)
    {
        return await _context.ProdutoresRurais.FirstOrDefaultAsync(p => p.CNPJ == cnpj);
    }

    // Método para atualizar um Produtor Rural
    public async Task<bool> Update(ProdutorRural produtor)
    {
        var existingProdutor = await _context.ProdutoresRurais.FindAsync(produtor.Id);
        if (existingProdutor == null)
            return false;

        // Atualiza as informações do Produtor Rural
        existingProdutor.Nome = produtor.Nome;
        existingProdutor.CPF = produtor.CPF;

        // Verifica se o NomeFantasia e CNPJ estão preenchidos e válidos
        existingProdutor.NomeFantasia = string.IsNullOrWhiteSpace(produtor.NomeFantasia) ? null : produtor.NomeFantasia;
        existingProdutor.CNPJ = string.IsNullOrWhiteSpace(produtor.CNPJ) ? null : produtor.CNPJ;

        existingProdutor.Email = produtor.Email;
        existingProdutor.Telefone = produtor.Telefone;
        existingProdutor.Endereco = produtor.Endereco;
        existingProdutor.Cidade = produtor.Cidade;
        existingProdutor.UF = produtor.UF;
        existingProdutor.CEP = produtor.CEP;

        await _context.SaveChangesAsync();
        return true;
    }

    // Método para deletar um Produtor Rural
    public async Task<bool> Delete(int id)
    {
        var produtor = await _context.ProdutoresRurais.FindAsync(id);
        if (produtor == null)
            return false;

        _context.ProdutoresRurais.Remove(produtor);
        await _context.SaveChangesAsync();
        return true;
    }

    // Métodos para validação de CPF e CNPJ
    private bool ValidarCPF(string cpf)
    {
        // Lógica para validação de CPF
        return Regex.IsMatch(cpf, @"^\d{11}$"); // Exemplo simples
    }

    private bool ValidarCNPJ(string cnpj)
    {
        // Lógica para validação de CNPJ
        return Regex.IsMatch(cnpj, @"^\d{14}$"); // Exemplo simples
    }
}
