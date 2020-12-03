using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public interface EventOrgRepository
    { 
        public IEnumerable<Eventos> Eventos { get;  }
        public IEnumerable<Localidade> Localidades { get; }
    }
}
