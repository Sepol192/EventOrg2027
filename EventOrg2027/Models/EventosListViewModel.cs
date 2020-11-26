using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class EventosListViewModel
    {
        public IEnumerable<Eventos> Products { get; set; }
        public PagingInfo Pagination { get; set; }
    }
}
