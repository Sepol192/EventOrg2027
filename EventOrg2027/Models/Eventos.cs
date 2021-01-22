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

        [Required(ErrorMessage = "Por favor, introduza o Nome")]
        [StringLength(50, ErrorMessage = "O nome é muito extenso")]
        public string NomeEventos { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Descrição")]
        [StringLength(3000, ErrorMessage = "A descrição é muito extensa")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Lotação")]
        [RegularExpression(@"(^[1-9]\d*$)", 
            ErrorMessage ="Número Inválido")]
        public int Lotacao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Data de Realização")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataRealizacao { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Hora de Realização")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        public DateTime HoraRealizacao { get; set; }


        [Required(ErrorMessage = "Por favor, insira a Localidade")]
        public int LocalidadeId { get; set; }
        public Localidade Localidade { get; set; }

        [Required(ErrorMessage = "Por favor, insira o Tipo de Evento")]
        public int TipoEventosId { get; set; }
        public TipoEventos TipoEventos { get; set; }

        [Required(ErrorMessage = "Por favor, insira o Organizador")]
        public int OrganizadorId { get; set; }
        public Organizador Organizador { get; set; }





    }
}
