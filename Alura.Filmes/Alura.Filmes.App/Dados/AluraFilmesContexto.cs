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

        public DbSet<Ator> Atores {get;set;} // DbSet tem que ser nome da tabela no banco de dados convecao
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AluraFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ator>()
                        .ToTable("actor");

            modelBuilder.Entity<Ator>()
                        .Property(a => a.Id) // Nome Na Classe Ator
                        .HasColumnName("actor_id"); // Nome da Coluna no Banco De Dados

            modelBuilder.Entity<Ator>()
                        .Property(a => a.PrimeiroNome) // Nome Na Classe Ator
                        .HasColumnName("first_name") // Nome da Coluna no Banco De Dados
                        .HasColumnType("varchar(45)") // Tipo Da Coluna No Banco De Dados
                        .IsRequired(); // Nao Aceita Valor Null

            modelBuilder.Entity<Ator>()
                       .Property(a => a.UltimoNome) // Nome Na Classe Ator
                       .HasColumnName("last_name") // Nome da Coluna no Banco De Dados
                       .HasColumnType("varchar(45)") // Tipo Da Coluna No Banco De Dados
                       .IsRequired(); // Nao Aceita Valor Null

            modelBuilder.Entity<Ator>()
                        .Property<DateTime>("last_update")
                        .HasColumnType("datetime")
                        .IsRequired(); //mapeando uma coluna no banco que não  e importante para o negocio
        }
    }
}
