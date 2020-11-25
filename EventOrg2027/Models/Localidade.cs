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
        [Column("LocalidadeId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int LocalidadeId { get; set; }

        [Column("NomeLocalidade")]
        [Required]
        [StringLength(50)]
        public string NomeLocalidade { get; set; }
    }
}
