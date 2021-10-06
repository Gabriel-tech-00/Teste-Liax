using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Gerenciamento_Empresas.Models;

namespace Gerenciamento_Empresas.Models
{
    [Table("tab_cidade")]
    public class Cidade
    {
        [Key]
        [Column("cid_id")]
        public int Id { get; set; }

        [Column("est_id")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        //---------------------------------------------------------------------//
        [Required(ErrorMessage = "O nome da cidade precisa ser preenchido")]
        [Column("cid_nome")]
        public string Nome { get; set; }

        //---------------------------------------------------------------------//
        public ICollection<Empresa> Empresa { get; set; }

        public ICollection<Lote> Lote { get; set; }

    }

}

