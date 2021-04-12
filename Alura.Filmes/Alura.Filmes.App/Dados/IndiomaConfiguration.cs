using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class IndiomaConfiguration : IEntityTypeConfiguration<Indioma>
    {
        public void Configure(EntityTypeBuilder<Indioma> builder)
        {
            // Mapeando a Tabela
            builder
                .ToTable("language");

            //Mapeando a chave Primaria
            builder
                .Property(l => l.Id)
                .HasColumnName("language_id");
            
            //Mapeando a Coluna Nome
            builder
                .Property(l => l.Nome)
                .HasColumnName("name")
                .HasColumnType("char(20)")
                .IsRequired();

            // shadow Propety
            builder
                        .Property<DateTime>("last_update")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()") //Adicionando Valor Default Shadow Protetys no BD
                        .IsRequired(); //mapeando uma coluna no banco que não  e importante para o negocio
        }
    }
}
