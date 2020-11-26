using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class EntityFrameworkRepository : EventOrgRepository
    {
        private EventOrgRepository dbContext;

        public EntityFrameworkRepository(EventOrgRepository dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Eventos> Eventos => dbContext.Eventos;
    }
}
