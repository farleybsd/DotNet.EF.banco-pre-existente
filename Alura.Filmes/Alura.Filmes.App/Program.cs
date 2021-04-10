using Alura.Filmes.App.Dados;
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
                foreach (var ator in contexto.Atores)
                {
                    Console.WriteLine(ator.PrimeiroNome);
                }
            }

            Console.ReadKey();
        }
    }
}