using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class Eventos
    {

        public int EventosId { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeEventos { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public string HoraInicio { get; set; }

        public string Lotacao { get; set; } 

        [DataType(DataType.Date)]
        public DateTime DataRealizacao { get; set; } 

        public Localidade localidade  { get; set; }

        public TipoEventos tipoEventos { get; set; }




    }
}
