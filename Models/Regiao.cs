using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Gerenciamento_Empresas.Models;

namespace Gerenciamento_Empresas.Models
{
    [Table("tab_regiao")]
    public class Regiao
    {
        [Key]
        [Column("reg_id")]
        public int Id { get; set; }

        //---------------------------------------------------------------------//
        [Required(ErrorMessage = "O nome da região precisa ser preenchido")]
        [Column("reg_nome")]
        public string Nome { get; set; }

        //---------------------------------------------------------------------//

        public ICollection<Empresa> Empresa { get; set; }
        public ICollection<Estado> Estado { get; set; }
        public ICollection<Cidade> Cidade { get; set; }
        public ICollection<Lote> Lote { get; set; }


    }

}
