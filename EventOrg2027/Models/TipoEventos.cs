using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class TipoEventos
    {

        public int TipoEventosId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Nome")]
        [StringLength(50, ErrorMessage = "O nome é muito extenso")]
        public string NomeTipoEventos { get; set; }
    }
}
