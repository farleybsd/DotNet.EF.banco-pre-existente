using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Alura.Filmes.App.Negocio.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
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


                //SelectUsandoRawSql
                //SelectUsandoRawSql(contexto);

                //ExeculteProcedureEF
                //ExeculteProcedureEF(contexto);

                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";

               var registros =  contexto
                                   .Database
                                   .ExecuteSqlCommand(sql);

                Console.WriteLine($"O total de registros afetados e {registros}.");

                var deleteSql = "DELETE FROM language WHERE name LIKE 'Teste%'";
                registros = contexto.Database.ExecuteSqlCommand(deleteSql);
                System.Console.WriteLine($"O total de registros afetados é {registros}.");

                Console.ReadKey();

            }
        }

        static void StoredProcedure(DbContext contexto)
        {
            var categ = "Action";

            var paramCateg = new SqlParameter("category_name", categ);
            var paramTotal = new SqlParameter
            {
                ParameterName = "@total_actors",
                Size = 4,
                Direction = System.Data.ParameterDirection.Output
            };


            contexto
                .Database
                .ExecuteSqlCommand("total_actors_from_given_category @category_name , @total_actors OUT", paramCateg, paramTotal);

            Console.WriteLine($"O Total de atores na categoria {categ} é de {paramTotal.Value}.");
        }

        private static void ExeculteProcedureEF(AluraFilmesContexto contexto)
        {
            var categ = "Action";

            var paramCateg = new SqlParameter("category_name", categ);
            var paramTotal = new SqlParameter
            {
                ParameterName = "@total_actors",
                Size = 4,
                Direction = System.Data.ParameterDirection.Output
            };


            contexto
                .Database
                .ExecuteSqlCommand("total_actors_from_given_category @category_name , @total_actors OUT", paramCateg, paramTotal);

            Console.WriteLine($"O Total de atores na categoria {categ} é de {paramTotal.Value}.");
        }

        private static void SelectUsandoRawSql(AluraFilmesContexto contexto)
        {
            var sql = @"SELECT
                                    a.*
                            FROM actor a
	                            inner join top5_most_starred_actors filmes on filmes.actor_id = a.actor_id
                            ";

            var atoresMaisAtuantes = contexto
                                            .Atores
                                            .FromSql(sql)
                                            .Include(a => a.Filmografia);

            foreach (var ator in atoresMaisAtuantes)
            {
                Console.WriteLine($"O Ator {ator.PrimeiroNome + "-" + ator.UltimoNome } atuou em:{ator.Filmografia.Count} filmes. ");
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
