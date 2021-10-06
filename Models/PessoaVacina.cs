
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_Empresas.Models
{
    
        [Table("tab_pessoa_vacina")]
        public class PessoaVacina
        {
            [Column("pes_vac_id")]
            [Key]
            public int Id { get; set; }

            //---------------------------------------------------------------------//

            [Column("pes_id")]
            public int PessoaId { get; set; }
            public Pessoa Pessoa { get; set; }

            //---------------------------------------------------------------------//

            [Column("vac_id")]
            public int VacinaId { get; set; }
            public Vacina Vacina { get; set; }

            //---------------------------------------------------------------------//
        }
    }


