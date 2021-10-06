using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_Empresas.Models
{
        [Table("tab_vacina_empresa")]
        public class VacinaEmpresa
        {
            [Column("emp_vac_id")]
            [Key]
            public int Id { get; set; }

        //---------------------------------------------------------------------//

        [Column("emp_id")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        //---------------------------------------------------------------------//

        [Column("vac_id")]
            public int VacinaId { get; set; }
            public Vacina Vacina { get; set; }

        


        }
}
