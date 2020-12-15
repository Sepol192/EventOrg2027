using System.Collections.Generic;

namespace EventOrg2027.Models
{
    public class TipoEventoListViewModel
    {
        public IEnumerable<TipoEventos> TipoEventos { get; set; }
        public PagingInfo Pagination { get; set; }
    }
}
