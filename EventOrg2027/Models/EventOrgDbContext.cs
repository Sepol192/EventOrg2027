using EventOrg2027.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class EventOrgDbContext:DbContext
    {
        public EventOrgDbContext(DbContextOptions<EventOrgDbContext> options) : base(options){}
        public DbSet<Localidade> Localidade { get; set; }
        public DbSet<TipoEventos> TiposEventos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<EventOrg2027.Models.Organizador> Organizador { get; set; }
    }
}
