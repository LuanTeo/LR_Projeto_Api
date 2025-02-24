using LR_Projeto_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LR_Projeto_Api.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Carrinho> Carrinho { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Componente> Componentes { get; set; }

        public DbSet<Computador> Computadores { get; set; }

        public DbSet<ComputadorComponente> ComputadoresComponentes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Favorito> Favoritos { get; set; }

        public DbSet<Pagamento> Pagamentos { get; set; }

        public DbSet<Periferico> Perifericos { get; set; }

        public DbSet<Setup> Setups { get; set; }

        public DbSet<SetupComputador> SetupsComputadores { get; set; }

        public DbSet<SetupPeriferico> SetupsPerifericos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
                .HasOne(e => e.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(e => e.EstadoId)
                .IsRequired(false);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Cidade)
                .WithMany(u => u.Usuarios)
                .HasForeignKey(u => u.CidadeId);

            //terminar 
        }
    }
}
