using System.Collections.Generic;

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
        public IEnumerable<Organizador> Organizadors => dbContext.Organizador;
        public IEnumerable<TipoEventos> TipoEventos => dbContext.TiposEventos;

    }
}
