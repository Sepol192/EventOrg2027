using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class EventosListViewModel
    {
        public IIncludableQueryable<Eventos,TipoEventos> Eventos { get; set; }
        public PagingInfo Pagination { get; set; }
    }
}
