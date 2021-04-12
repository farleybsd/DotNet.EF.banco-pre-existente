using System.Collections.Generic;

namespace Alura.Filmes.App.Negocio
{
    public class Indioma
    {
        public byte Id { get; set; } //clr para o banco para tinyint
        public string Nome { get; set; }
        public IList<Filme> FilmesFalados { get; set; }
        public IList<Filme> FilmesOriginais { get; set; }


        public Indioma()
        {
            FilmesFalados = new List<Filme>();
            FilmesOriginais = new List<Filme>();
        }
        public override string ToString()
        {
            return $"Idioma ({Id}) - Nome {Nome} ";
        }
    }
}
