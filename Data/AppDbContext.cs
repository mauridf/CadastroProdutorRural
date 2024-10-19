using CadastroProdutorRural.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroProdutorRural.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<ProdutorRural> ProdutoresRurais { get; set; }
    public DbSet<Fazenda> Fazendas { get; set; }
    public DbSet<Cultura> Culturas { get; set; }
    public DbSet<FazendaCultura> FazendaCulturas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FazendaCultura>()
            .HasKey(fc => new { fc.IdFazenda, fc.IdCultura });

        base.OnModelCreating(modelBuilder);
    }
}
