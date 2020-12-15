using System.ComponentModel.DataAnnotations;

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
