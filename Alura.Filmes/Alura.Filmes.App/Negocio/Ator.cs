using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Negocio
{
    [Table("actor")] // Mapeando a Tabela do banco de dados para classe 
    public class Ator
    {
        [Column("actor_id")] // Mapeando a Coluna do banco pra propiedade da classe
        public int Id { get; set; }
        [Column("first_name")] // Mapeando a Coluna do banco pra propiedade da classe
        public string PrimeiroNome { get; set; }
        [Column("last_name")] // Mapeando a Coluna do banco pra propiedade da classe
        public string UltimoNome { get; set; }

        public override string ToString()
        {
            return $" Ator ({Id}) : Nome : {PrimeiroNome} Ultimo Nome : {UltimoNome}  ";
        }
    }
}

// Por converção o Ef usa as propriedades da classe como o nome da coluna do Banco de Dados