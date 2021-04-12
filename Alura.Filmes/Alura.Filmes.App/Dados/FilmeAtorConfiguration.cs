using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeAtorConfiguration : IEntityTypeConfiguration<FilmeAtor>
    {
        public void Configure(EntityTypeBuilder<FilmeAtor> builder)
        {
            builder
                  .ToTable("film_actor");
            //configurando chave composta

            builder
                    .Property<int>("film_id")
                    .IsRequired();

            builder
                    .Property<int>("actor_id")
                    .IsRequired();
            builder
                    .Property<DateTime>("last_update")
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

            builder
                   .HasKey("film_id", "actor_id");

            // Mapeando ForenKey
            builder
                .HasOne(fa => fa.Filme) // Relacionamento de ida
                .WithMany(f => f.Atores) // Relacionamento de volta
                .HasForeignKey("film_id");

            // Ator
            builder
               .HasOne(fa => fa.Ator) // Relacionamento de ida 1.0
               .WithMany(a => a.Filmografia) // Relacionamento de volta
               .HasForeignKey("actor_id");

        }
    }
}
