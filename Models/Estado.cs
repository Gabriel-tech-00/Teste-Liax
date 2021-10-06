using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Gerenciamento_Empresas.Models;

namespace Gerenciamento_Empresas.Models
{
    [Table("tab_estado")]
    public class Estado
    {
        [Key]
        [Column("est_id")]
        public int Id { get; set; }

        //---------------------------------------------------------------------//

        [Column("reg_id")]
        public int RegiaoId { get; set; }
        public Regiao Regiao { get; set; }

        

        //---------------------------------------------------------------------//
        [Required(ErrorMessage = "O nome do estado precisa ser preenchido")]
        [Column("est_nome")]
        public string Nome { get; set; }

        //---------------------------------------------------------------------//

        public ICollection<Empresa> Empresa { get; set; }

        public ICollection<Lote> Lote { get; set; }

    }

}
