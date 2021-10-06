using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciamento_Empresas.Models
{
    [Table("tab_vacina")]
    public class Vacina
    {
        [Column("vac_id")]
        [Key]
        public int Id { get; set; }

        //---------------------------------------------------------------------//

        [Column("vac_nome")]
        public string Nome { get; set; }

        //---------------------------------------------------------------------//

        [Column("vac_data_fabricacao")]
        public DateTime Data { get; set; }

        //---------------------------------------------------------------------//

        public ICollection<Lote> Lote { get; set; }
        public ICollection<PessoaVacina> PessoalVacina { get; set; }
    }
}

