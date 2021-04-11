using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Select ta tabela Atores

            using (var contexto = new AluraFilmesContexto())
            {
                //contexto.LogSQLToConsole();

                //foreach (var ator in contexto.Atores)
                //{
                //    Console.WriteLine(ator);
                //}

                // Insert  Shadow Protetys
                var ator = new Ator();
                ator.PrimeiroNome = "Farley";
                ator.UltimoNome = "Rufino";
                //Shadow Protetys
                contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;// Colocando um valor obrigario para o banco 
                                                                                        //  mais que nao e importante para o negocio

                contexto.Atores.Add(ator);
                contexto.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}