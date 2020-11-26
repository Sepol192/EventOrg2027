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

        [Required]
        [StringLength(50)]
        public string NomeLocalidade { get; set; }
    }
}
