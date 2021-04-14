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
                //ConvertEnumParaTabelaEextensao();

                //InserindoListandoFilme
                //InserindoListandoFilme(contexto);

                //ListandoClientesEFuncionarios
                //ListandoClientesEFuncionarios(contexto);

                //UsandoSqlRawEF

                //var atoresMaisAtuantes = contexto
                //                                .Atores
                //                                .Include(a => a.Filmografia)
                //                                .OrderByDescending(a => a.Filmografia.Count)
                //                                .Take(5);


                
                var sql = @"SELECT TOP 5
                                    A.first_name,
                                    A.last_name,
                                    COUNT(*) AS TOTAL
                            FROM actor A
	                                INNER JOIN film_actor FA ON FA.actor_id = A.actor_id
                            GROUP BY 
                                    A.first_name,
                                    A.last_name
                            ORDER BY 
                                    TOTAL
                            ";

                var  atoresMaisAtuantes = contexto.Atores.FromSql(sql);

                foreach (var ator in atoresMaisAtuantes)
                {
                    Console.WriteLine($"O Ator {ator.PrimeiroNome +"-"+ator.UltimoNome } atuou em:{ator.Filmografia.Count} filmes. ");
                }

                Console.ReadKey();

            }
        }

        private static void ListandoClientesEFuncionarios(AluraFilmesContexto contexto)
        {
            Console.WriteLine("Clientes");
            foreach (var cliente in contexto.Clientes)
            {
                Console.WriteLine(cliente);
            }

            Console.WriteLine("Funcionarios");
            foreach (var funcionario in contexto.Funcionarios)
            {
                Console.WriteLine(funcionario);
            }
        }

        private static void InserindoListandoFilme(AluraFilmesContexto contexto)
        {
            var filmes = new Filme();
            filmes.Titulo = "Cassino Royale";
            filmes.Duracao = 120;
            filmes.AnoLancamento = "2000";
            filmes.Classificacao = ClassificacaoIndicativa.MaioresQue14;
            filmes.IdiomaFalado = contexto.Idiomas.First();
            contexto.Entry(filmes).Property("last_update").CurrentValue = DateTime.Now;

            contexto.Filmes.Add(filmes);
            contexto.SaveChanges();

            var filmeInserido = contexto.Filmes.First(f => f.Titulo == filmes.Titulo);
            Console.WriteLine(filmeInserido.Classificacao.ParaString());
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
