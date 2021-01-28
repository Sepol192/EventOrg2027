using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class Inscricao
    {
        public int ID { get; set;  } 
        public DateTime DataInscricao { get; set; }
        public string UserID { get; set; }
        public int EventoID { get; set; }
        public virtual Eventos Eventos { get; set; }


    }
}
