using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class EntityFrameworkRepository : EventOrgRepository
    {
        private EventOrgDbContext dbContext;

        public EntityFrameworkRepository(EventOrgDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Eventos> Eventos => dbContext.Eventos;
        public IEnumerable<Localidade> Localidades => dbContext.Localidade;
    }
}
