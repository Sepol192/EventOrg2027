using System;
using System.ComponentModel.DataAnnotations;
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
