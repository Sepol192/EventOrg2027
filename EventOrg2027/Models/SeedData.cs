using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Data
{ 
    public class SeedData
    {
        internal static void Populate(EventOrgDbContext dbContext)
        {
            PopulateEvents(dbContext);
        }

        private static void PopulateEvents(EventOrgDbContext dbContext)
        {
            if (dbContext.Eventos.Any())
            {
                return;
            }

            dbContext.Eventos.AddRange(
                new Models.Eventos { 
                    NomeEventos = "Concerto José Cid",
                    Descricao="Concerto José Cid na Guarda com controlo de pessoas",
                    DataRealizacao= new DateTime(2008, 3, 1, 7, 0, 0),
                    Lotacao="100"
                },
                new Models.Eventos {
                    NomeEventos = "Concerto José Cid",
                    Descricao = "Concerto José Cid na Guarda com controlo de pessoas",
                    DataRealizacao = new DateTime(2008, 3, 1, 7, 0, 0),
                    Lotacao = "100"

                }
            );

            dbContext.SaveChanges();
        }
    }
}
