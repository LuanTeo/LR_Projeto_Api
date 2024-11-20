using LR_Projeto_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LR_Projeto_Api.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Componente> Componentes { get; set; }
    }
}
