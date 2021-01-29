using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class LocalidadesListViewModel
    {
        public IEnumerable<Localidade> Localidades { get; set; }

        public PagingInfo Pagination { get; set; }

        public string SearchName { get; set; }
    }
}
