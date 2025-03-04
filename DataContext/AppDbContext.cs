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
            modelBuilder.Entity<Carrinho>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Carrinho)
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<Carrinho>()
                .HasOne(c => c.Setup)
                .WithMany(s => s.Carrinho)
                .HasForeignKey(c => c.SetupId);

            modelBuilder.Entity<Cidade>()
                .HasOne(e => e.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(e => e.EstadoId)
                .IsRequired(false);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Cidade)
                .WithMany(u => u.Usuarios)
                .HasForeignKey(u => u.CidadeId);

            modelBuilder.Entity<Componente>()
                .HasMany(c => c.ComputadorComponente)
                .WithOne(cc => cc.Componente)
                .HasForeignKey(cc => cc.ComponenteId);

            modelBuilder.Entity<Computador>()
               .HasMany(c => c.SetupComputador)
               .WithOne(sc => sc.Computador)
               .HasForeignKey(sc => sc.ComputadorId);

            modelBuilder.Entity<Computador>()
                .HasMany(c => c.ComputadorComponente)
                .WithOne(cc => cc.Computador)
                .HasForeignKey(cc => cc.ComputadorID);

            modelBuilder.Entity<ComputadorComponente>()
               .HasOne(cc => cc.Computador)
               .WithMany(c => c.ComputadorComponente)
               .HasForeignKey(cc => cc.ComputadorID);

            modelBuilder.Entity<ComputadorComponente>()
                .HasOne(cc => cc.Componente)
                .WithMany(c => c.ComputadorComponente)
                .HasForeignKey(cc => cc.ComponenteId);

            modelBuilder.Entity<Endereco>()
                .HasOne(e => e.Usuario)
                .WithMany(u => u.Endereco)
                .HasForeignKey(e => e.Id_usu);

            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Usuario)
                .WithMany(u => u.Favorito)
                .HasForeignKey(f => f.UsuarioId);

            modelBuilder.Entity<Favorito>()
                .HasOne(f => f.Setup)
                .WithMany(s => s.Favoritos)
                .HasForeignKey(f => f.SetupId);

            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Carrinho)
                .WithMany(c => c.Pagamentos)
                .HasForeignKey(p => p.CarrinhoId);

            modelBuilder.Entity<Periferico>()
                .HasMany(p => p.SetupPeriferico)
                .WithOne(sp => sp.Periferico)
                .HasForeignKey(sp => sp.PerifericoId);

            modelBuilder.Entity<Setup>()
                .HasMany(s => s.Favoritos)
                .WithOne(f => f.Setup)
                .HasForeignKey(f => f.SetupId);

            modelBuilder.Entity<Setup>()
                .HasMany(s => s.Carrinho)
                .WithOne(c => c.Setup)
                .HasForeignKey(c => c.SetupId);

            modelBuilder.Entity<Setup>()
                .HasMany(s => s.SetupComputador)
                .WithOne(sc => sc.Setup)
                .HasForeignKey(sc => sc.SetupId);

            modelBuilder.Entity<Setup>()
                .HasMany(s => s.SetupPeriferico)
                .WithOne(sp => sp.Setup)
                .HasForeignKey(sp => sp.SetupId);

            modelBuilder.Entity<SetupComputador>()
                .HasOne(sc => sc.Setup)
                .WithMany(s => s.SetupComputador)
                .HasForeignKey(sc => sc.SetupId);

            modelBuilder.Entity<SetupComputador>()
                .HasOne(sc => sc.Computador)
                .WithMany(c => c.SetupComputador)
                .HasForeignKey(sc => sc.ComputadorId);

            modelBuilder.Entity<SetupPeriferico>()
                .HasOne(sp => sp.Setup)
                .WithMany(s => s.SetupPeriferico)
                .HasForeignKey(sp => sp.SetupId);

            modelBuilder.Entity<SetupPeriferico>()
                .HasOne(sp => sp.Periferico)
                .WithMany(p => p.SetupPeriferico)
                .HasForeignKey(sp => sp.PerifericoId);

            modelBuilder.Entity<Usuario>()
               .HasOne(u => u.Cidade)
               .WithMany(c => c.Usuarios)
               .HasForeignKey(u => u.CidadeId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Endereco)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.Id_usu);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Favorito)
                .WithOne(f => f.Usuario)
                .HasForeignKey(f => f.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Carrinho)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);

        }
    }
}