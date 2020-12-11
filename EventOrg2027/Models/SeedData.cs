using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{ 
    public class SeedData
    {
        internal static void Populate(EventOrgDbContext dbContext)
        {
            PopulateEvents(dbContext);
        }

        private static void PopulateEvents(EventOrgDbContext dbContext)
        {
            /*if (dbContext.Eventos.Any())
            {
                return;
            }
            
            if (dbContext.Localidade.Any())
            {
                return;
            }
            
              if (dbContext.TiposEventos.Any())
              {
                  return;
              }
            */
              if (dbContext.Organizador.Any())
              {
                  return;
              }

            /*dbContext.Eventos.AddRange(
                new Eventos { 
                    NomeEventos = "Concerto",
                    Descricao="Concerto José Cid na Guarda com controlo de pessoas",
                    DataRealizacao= new DateTime(2008, 3, 1, 7, 0, 0),
                    Lotacao="100"
                },
                new Eventos {
                    NomeEventos = "Cinema",
                    Descricao = "Filme da Disney",
                    DataRealizacao = new DateTime(2008, 3, 1, 7, 0, 0),
                    Lotacao = "30"

                },
                new Eventos {
                    NomeEventos = "Ricardo Jacinto MEDUSA Unit",
                    Descricao = "MEDUSA é um solo de Ricardo Jacinto pensado para violoncelo, eletrónica e objetos ressonantes.",
                    DataRealizacao = new DateTime(2020, 12, 1, 20, 0, 0),
                    Lotacao = "100"
                },
                new Eventos
                {
                    NomeEventos = "O Livro da Minha Vida",
                    Descricao = "Os autores convidados do Café Literário partilham sugestões de livros e de leituras.",
                    DataRealizacao = new DateTime(2021, 3, 1, 7, 0, 0),
                    Lotacao = "230"

                },
                new Eventos
                {
                    NomeEventos = "Agrovouga 2020",
                    Descricao = "Na visita virtual o Parque de Feiras e Exposições de Aveiro continua a ser um epicentro do evento",
                    DataRealizacao = new DateTime(2020, 12, 1, 23, 0, 0),
                    Lotacao = "80"
                                },
                new Eventos
                {
                    NomeEventos = "Ciência com ovos - Kit de atividades",
                    Descricao = "O Serviço Educativo Quero ser cientista sugere a realização da atividade",
                    DataRealizacao = new DateTime(2021, 3, 1, 12, 22, 22),
                    Lotacao = "30"

                },
                new Eventos
                {
                    NomeEventos = "Pontos de encontro",
                    Descricao = "Perdida e achada!",
                    DataRealizacao = new DateTime(2022, 3, 1, 7, 0, 0),
                    Lotacao = "1000"
                },
                new Eventos
                {
                    NomeEventos = "O IA na Noite Europeia dos Investigadores ",
                    Descricao = "O Instituto de Astrofísica e Ciências do Espaço participa na Noite Europeia de astronomia.",
                    DataRealizacao = new DateTime(2023, 1, 1, 12, 0, 0),
                    Lotacao = "800"

                }

            );*/
            /*
            dbContext.Localidade.AddRange(
                new Localidade
                {
                    NomeLocalidade = "Guarda",
                },
                new Localidade
                {
                    NomeLocalidade = "Celorico",
                },
                new Localidade
                {
                    NomeLocalidade = "Seia",
                }
                );

            dbContext.TiposEventos.AddRange(
              new TipoEventos
          {
                NomeTipoEventos = "Música",
             },
             new TipoEventos
             {
                NomeTipoEventos = "Concerto",
              },
                  new TipoEventos
             {
                    NomeTipoEventos = "Arte",
           }
          );
            dbContext.SaveChanges();*/
            /*
            for(int i = 0; i < 100; i++)
            {
                dbContext.Eventos.AddRange(
                new Eventos
                {
                    NomeEventos = "Dança contemporânea",
                    Descricao = "Que ou quem é do mesmo tempo ou da mesma época contemporâneo",
                    DataRealizacao = new DateTime(2020, 11, 1),
                    HoraRealizacao = new DateTime(7),
                    Lotacao = 50,
                    LocalidadeId=1,
                    OrganizadoresId=1,
                    TipoEventosId=1,

                }
                );

                dbContext.SaveChanges();
            }
            
            dbContext.Organizador.AddRange(
            new Organizador
            {
                    NomeOrganizador = "Dança contemporânea",
                    Contacto = "961656567",
                    DataNascimento = new DateTime(2020, 11, 1),
                    EmailAddress = "danca.hbm@gmail.com",
}
);

            dbContext.SaveChanges();
            

            /*dbContext.Localidade.AddRange(
                new Localidade
                {
                    NomeLocalidade = "Guarda",
                    Descricao = "jijoj",
                    Populacao = 122,
                },
                new Localidade
                {
                    NomeLocalidade = "Celorico",
                    Descricao = "jijoj",
                    Populacao = 122,
                },
                new Localidade
                {
                    NomeLocalidade = "Seia",
                    Descricao = "jijoj",
                    Populacao = 122,
                }
                );
            dbContext.SaveChanges();*/


            /*dbContext.Eventos.AddRange(
            new Eventos
            {
                NomeEventos = "Dança contemporânea",
                Descricao = "Que ou quem é do mesmo tempo ou da mesma época contemporâneo",
                DataRealizacao = new DateTime(2020, 11, 1),
                HoraRealizacao = new DateTime(7),
                Lotacao = 50,
                LocalidadeId = 1,
                OrganizadoresId = 1,
                TipoEventosId = 1,

            }
            );*/

            // dbContext.SaveChanges();
            for (int i = 0; i < 100; i++)
            {
                dbContext.Organizador.AddRange(
                new Organizador
                {
                    NomeOrganizador = "Fanc",
                    Contacto = "966786786",
                    DataNascimento = new DateTime(2020, 11, 1),
                    EmailAddress = "fnac@gmail.com",

                }
                );

                dbContext.SaveChanges();
            }
        }


    }
}
