using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciamento_Empresas.Models
{
    [Table("tab_pessoa")]
    public class Pessoa
    {

        [Column("pes_id")]
        public int Id { get; set; }

        //---------------------------------------------------------------------//

        [Column("pes_cpf")]
        [Key]
        public int Cpf { get; set; }

        //---------------------------------------------------------------------//

        [Column("pes_nome")]
        public string Nome { get; set; }

        //---------------------------------------------------------------------//

        [Column("loc_id")]
        public int LocalId { get; set; }
        public Locais Locais { get; set; }

        public ICollection<PessoaVacina> PessoalVacina { get; set; }

    }
}