using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class AtorConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            // Configurando Ator
            builder
                        .ToTable("actor");

            builder
                        .Property(a => a.Id) // Nome Na Classe Ator
                        .HasColumnName("actor_id"); // Nome da Coluna no Banco De Dados

            builder
                        .Property(a => a.PrimeiroNome) // Nome Na Classe Ator
                        .HasColumnName("first_name") // Nome da Coluna no Banco De Dados
                        .HasColumnType("varchar(45)") // Tipo Da Coluna No Banco De Dados
                        .IsRequired(); // Nao Aceita Valor Null

            builder
                       .Property(a => a.UltimoNome) // Nome Na Classe Ator
                       .HasColumnName("last_name") // Nome da Coluna no Banco De Dados
                       .HasColumnType("varchar(45)") // Tipo Da Coluna No Banco De Dados
                       .IsRequired(); // Nao Aceita Valor Null

            builder
                        .Property<DateTime>("last_update")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()") //Adicionando Valor Default Shadow Protetys no BD
                        .IsRequired(); //mapeando uma coluna no banco que não  e importante para o negocio
        }
    }
}
