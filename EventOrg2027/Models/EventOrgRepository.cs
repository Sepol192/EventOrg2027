using System.Collections.Generic;

namespace EventOrg2027.Models
{
    public interface EventOrgRepository
    {
        public IEnumerable<Eventos> Eventos { get; }
        public IEnumerable<Localidade> Localidades { get; }
        public IEnumerable<Organizador> Organizadors { get; }
        public IEnumerable<TipoEventos> TipoEventos { get; }
    }
}
