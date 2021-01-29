using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class TipoEventoListViewModel
    {
        public IEnumerable<TipoEventos> TipoEventos { get; set; }
        public PagingInfo Pagination { get; set; }
        public string SearchName { get; set; }
    } 
}
