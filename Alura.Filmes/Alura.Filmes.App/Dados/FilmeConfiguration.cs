using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            // Configurando Filmes
           builder
                       .ToTable("film");

           builder// Nome da Classe Filme
                       .Property(f => f.Id) // Nome Na Classe Filme
                       .HasColumnName("film_id"); // Nome da Coluna no Banco De Dadosna no banco que não  e importante para o negocio

           builder
                       .Property(f => f.Titulo) // Nome Na Classe Filme
                       .HasColumnName("title") // Nome da Coluna no Banco De Dados
                       .HasColumnType("varchar(255)") // Tipo Da Coluna No Banco De Dados
                       .IsRequired(); // Nao Aceita Valor Null

           builder
                      .Property(f => f.Descricao) // Nome Na Classe Filme
                      .HasColumnName("description") // Nome da Coluna no Banco De Dados
                      .HasColumnType("text"); // Tipo Da Coluna No Banco De Dados

           builder
                      .Property(f => f.AnoLancamento) // Nome Na Classe Filme
                      .HasColumnName("release_year") // Nome da Coluna no Banco De Dados
                      .HasColumnType("varchar(4)"); // Tipo Da Coluna No Banco De Dados

           builder
                      .Property(f => f.Duracao) // Nome Na Classe Filme
                      .HasColumnName("length"); // Nome da Coluna no Banco De Dados

           builder
                        .Property<DateTime>("last_update")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()") //Adicionando Valor Default Shadow Protetys no BD
                        .IsRequired(); //mapeando uma coluna no banco que não  e importante para o negocio

            // Relacionamento com Idioma

            builder
                      .Property<byte>("language_id"); //FK
            builder
                      .Property<byte>("original_language_id"); //FK

            builder
                    .HasOne(f => f.IdiomaFalado)
                    .WithMany(i => i.FilmesFalados)
                    .HasForeignKey("language_id");

            builder
                   .HasOne(f => f.IdiomaOriginal)
                   .WithMany(i => i.FilmesOriginais)
                   .HasForeignKey("original_language_id");

        }
    }
}
