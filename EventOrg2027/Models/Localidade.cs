using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class Localidade
    {
        public int LocalidadeId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Nome")]
        [StringLength(50, ErrorMessage = "O nome é muito extenso")]
        public string NomeLocalidade { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Descrição")]
        [StringLength(200, ErrorMessage = "A descrição é muito extensa")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a População")]
        public int Populacao { get; set; }
    }
}
