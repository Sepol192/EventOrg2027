using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class EventosListViewModel
    {
        public IIncludableQueryable<Eventos, TipoEventos> Eventos { get; set; }
        public PagingInfo Pagination { get; set; } 
        public string LocalEvento { get; set; } 
        public string OrgEvento { get; set; }
        public string TipoEvento { get; set; }
        public string SearchName { get; set; }  
        public SelectList Localidades { get; set; }
        public SelectList TiposEventos { get; set; } 
        public SelectList Organizadores { get; set; } 


    }
}
