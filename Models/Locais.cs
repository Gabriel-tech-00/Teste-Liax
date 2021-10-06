using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Gerenciamento_Empresas.Models;


namespace Gerenciamento_Empresas.Models
{
    [Table("tab_locais")]
    public class Locais
    {
        [Key]
        [Column("loc_id")]
        public int Id { get; set; }

        //---------------------------------------------------------------------//
        [Required(ErrorMessage = "O nome do local precisa ser preenchido")]

        [Column("loc_nome")]
        public string Nome { get; set; }

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

        [Column("loc_endereco")]
        public string Endereco { get; set; }

        //---------------------------------------------------------------------//

    }

}