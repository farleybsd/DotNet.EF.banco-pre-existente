using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContexto : DbContext
    {

        public DbSet<Ator> Atores {get;set; } // DbSet tem que ser nome da tabela no banco de dados convecao 
        public DbSet<Filme> Filmes { get; set; } // DbSet tem que ser nome da tabela no banco de dados convecao
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AluraFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando Ator
            modelBuilder.ApplyConfiguration(new AtorConfiguration());

            // Configurando Filmes
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());
        }
    }
}
