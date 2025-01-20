using Microsoft.EntityFrameworkCore;
using Oficina.API.Models;

namespace Oficina.API.Context
{
    public sealed class OficinaContext : DbContext
    {
        public OficinaContext()
        {

        }
        public OficinaContext(DbContextOptions<OficinaContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<OrdemServico> OrdemServicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasMany(c => c.Enderecos).WithOne().OnDelete(DeleteBehavior.Cascade);
                c.HasMany(c => c.Veiculos).WithOne().OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
