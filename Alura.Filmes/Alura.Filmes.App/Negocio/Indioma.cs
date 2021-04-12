namespace Alura.Filmes.App.Negocio
{
    public class Indioma
    {
        public byte Id { get; set; } //clr para o banco para tinyint
        public string Nome { get; set; }

        public override string ToString()
        {
            return $"Idioma ({Id}) - Nome {Nome} ";
        }
    }
}
