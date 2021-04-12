using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                // Select ta tabela Atores
                //SelecionarTodosAtores(contexto);

                // Insert  Shadow Protetys
                //InsertShadowProterys(contexto);

                //Selecionando Um Ator
                //SelecionandoUmAtor(contexto);

                // Selecionando Filmes 
                //SelecionandoFilmes(contexto);

                // Selecionar Elenco
                //elecionaElenco(contexto);

                //AtoresQueAturamDeterminadosFilmes

                var filme = contexto
                                    .Filmes
                                    .Include(f => f.Atores)
                                    .First();
                Console.WriteLine(filme);
                Console.WriteLine("Elenco:");

                foreach (var ator in filme.Atores)
                {
                    Console.WriteLine(ator);
                }
            }

            Console.ReadKey();
        }

        private static void elecionaElenco(AluraFilmesContexto contexto)
        {
            foreach (var elenco in contexto.Elenco)
            {
                //Shadow Protetys
                var entidade = contexto.Entry(elenco);
                var filmId = entidade.Property("film_id").CurrentValue;
                var actorId = entidade.Property("actor_id").CurrentValue;
                var last_Update = entidade.Property("last_update").CurrentValue;
                Console.WriteLine($"Filme {filmId} - Ator {actorId} - Last_Update {last_Update} ");
            }
        }

        private static void SelecionandoFilmes(AluraFilmesContexto contexto)
        {
            foreach (var filme in contexto.Filmes)
            {
                Console.WriteLine(filme);
            }
        }

        private static void SelecionandoUmAtor(AluraFilmesContexto contexto)
        {
            // Listar os 10 atores modificados recentemente usando uma coluna que so existe no banco de dados
            var atores = contexto.Atores
                                 .OrderByDescending(a => EF.Property<DateTime>(a, "last_update"))
                                 .Take(10);

            foreach (var ator in atores)
            {
                Console.WriteLine(ator + "-" + contexto.Entry(ator).Property("last_update").CurrentValue);
            }

            //var ator = contexto.Atores.First();
            //Console.WriteLine(ator);
            //Console.WriteLine(contexto.Entry(ator).Property("last_update").CurrentValue);
        }

        private static void SelecionarTodosAtores(AluraFilmesContexto contexto)
        {
            foreach (var ator in contexto.Atores)
            {
                Console.WriteLine(ator);
               
            }
        }

        private static void InsertShadowProterys(AluraFilmesContexto contexto)
        {
            var ator = new Ator();
            ator.PrimeiroNome = "Farley";
            ator.UltimoNome = "Rufino";
            //Shadow Protetys
            //contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;// Colocando um valor obrigario para o banco 
                                                                                     //  mais que nao e importante para o negocio

            contexto.Atores.Add(ator);
            contexto.SaveChanges();
        }
    }
}