using System;
using System.ComponentModel.DataAnnotations;

namespace EventOrg2027.Models
{
    public class Eventos
    {
        public int EventosId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Nome")]
        [StringLength(50, ErrorMessage = "O nome é muito extenso")]
        public string NomeEventos { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Descrição")]
        [StringLength(200, ErrorMessage = "A descrição é muito extensa")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Lotação")]
        public int Lotacao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Data de Realização")]
        [DataType(DataType.Date)]
        public DateTime DataRealizacao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Hora de Realização")]
        [DataType(DataType.Time)]
        public DateTime HoraRealizacao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a localidade")]
        public int LocalidadeId { get; set; }
        public Localidade Localidade { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o tipo de evento")]
        public int TipoEventosId { get; set; }
        public TipoEventos TipoEventos { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o organizador")]
        public int OrganizadoresId { get; set; }
        public Organizador Organizador { get; set; }





    }
}
