using LR_Projeto_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LR_Projeto_Api.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Componente> Componentes { get; set; }

        public DbSet<Periferico> Perifericos { get; set; }

        public DbSet<Setup> Setups { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Estado>  Estados { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>()
                .HasOne(e => e.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(e => e.EstadoId)
                .IsRequired(false);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Cidade)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(u => u.CidadeId)
                
        }
    }
}
