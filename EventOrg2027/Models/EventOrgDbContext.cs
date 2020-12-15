using Microsoft.EntityFrameworkCore;

namespace EventOrg2027.Models
{
    public class EventOrgDbContext : DbContext
    {
        public EventOrgDbContext(DbContextOptions<EventOrgDbContext> options) : base(options) { }
        public DbSet<Localidade> Localidade { get; set; }
        public DbSet<TipoEventos> TiposEventos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Organizador> Organizador { get; set; }
    }
}
