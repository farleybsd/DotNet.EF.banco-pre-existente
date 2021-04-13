using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Alura.Filmes.App.Negocio.Enum;
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
                //resitricacaoCheckClassificacao(contexto);

                //ConvertEnumParaTabelaEextensao
                ConvertEnumParaTabelaEextensao();

                Console.ReadKey();

            }
        }

        private static void ConvertEnumParaTabelaEextensao()
        {
            var livre = ClassificacaoIndicativa.MaioresQue18;
            Console.WriteLine(livre.ParaString());
            Console.WriteLine("G".ParaValor());
        }

        private static void resitricacaoCheckClassificacao(AluraFilmesContexto contexto)
        {
            var filmes = new Filme();
            filmes.Titulo = "Senhor Dos Aneis";
            filmes.Duracao = 120;
            filmes.AnoLancamento = "2000";
            filmes.Classificacao = ClassificacaoIndicativa.Livre;
            filmes.IdiomaFalado = contexto.Idiomas.First();
            contexto.Entry(filmes).Property("last_update").CurrentValue = DateTime.Now;

            contexto.Filmes.Add(filmes);
            contexto.SaveChanges();
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
