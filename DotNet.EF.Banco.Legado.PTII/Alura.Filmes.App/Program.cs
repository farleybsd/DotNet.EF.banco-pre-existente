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

                // GerandoConstraintEFParaBancoDados
                //GerandoConstraintEFParaBancoDados(contexto);


                // resitricacaoCheckClassificacao
                var indioma = new Idioma()
                {
                    Nome = "English",

                };
                

                var filmes = new Filme();
                filmes.Titulo = "Senhor Dos Aneis";
                filmes.Duracao = 120;
                filmes.AnoLancamento = "2000";
                filmes.Classificacao = "Merda";
                filmes.IdiomaFalado = indioma;
                contexto.Entry(filmes).Property("last_update").CurrentValue = DateTime.Now;

                contexto.Filmes.Add(filmes);
                contexto.SaveChanges();

                Console.ReadKey();

            }
        }

        private static void GerandoConstraintEFParaBancoDados(AluraFilmesContexto contexto)
        {
            var ator1 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
            var ator2 = new Ator { PrimeiroNome = "Emma", UltimoNome = "Watson" };
            contexto.Atores.AddRange(ator1, ator2);
            contexto.SaveChanges();

            var emmaWatson = contexto.Atores
                .Where(a => a.PrimeiroNome == "Emma" && a.UltimoNome == "Watson");
            Console.WriteLine($"Total de atores enconrados: {emmaWatson.Count()}.");
        }
    }
}
