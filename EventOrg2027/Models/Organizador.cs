using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace EventOrg2027.Models
{
    public class Organizador
    { 
        public int OrganizadorId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Nome do Organizador")]
        [StringLength(50)]
        public string NomeOrganizador { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Contacto")]
        [RegularExpressionAttribute("^9[1236]{1}[0-9]{7}$",
        ErrorMessage = "Contato Inválido ")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

    }
}
