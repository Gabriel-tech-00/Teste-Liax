using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Gerenciamento_Empresas.Models;


namespace Gerenciamento_Empresas.Models
{
    [Table("tab_lote")]
    public class Lote
    {
        [Key]
        [Column("loc_id")]
        public int Id { get; set; }

        //---------------------------------------------------------------------//
        
        [Column("reg_id")]
        public int RegiaoId { get; set; }
        public Regiao Regiao { get; set; }

        //---------------------------------------------------------------------//


        [Column("est_id")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        //---------------------------------------------------------------------//



        [Column("cid_id")]
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        //---------------------------------------------------------------------//

        [Required(ErrorMessage = "O nome do local precisa ser preenchido")]

        [Column("loc_nome")]

        public string Nome { get; set; }

        //---------------------------------------------------------------------//

        [Column("vac_id")]
        public int VacinaId { get; set; }
        public Vacina Vacina { get; set; }

        //---------------------------------------------------------------------//

    }

}
