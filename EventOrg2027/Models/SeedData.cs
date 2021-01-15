using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{ 
    public class SeedData
    {
        private const string DEFAULT_ADMIN_USER = "admin@ipg.pt";
        private const string DEFAULT_ADMIN_PASSWORD = "Admin123";

        private const string ROLE_ADMINISTRATOR = "Admin";
        private const string ROLE_CUSTOMER = "Customer";

        internal static void Populate(EventOrgDbContext dbContext)
        {
            PopulateEvents(dbContext);
        }

        private static void PopulateEvents(EventOrgDbContext dbContext)
        {
            
            
            if (!dbContext.Localidade.Any())
            {
                dbContext.Localidade.AddRange(
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
                dbContext.SaveChanges();

            }
            
              if (!dbContext.TiposEventos.Any())
              {
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
                dbContext.SaveChanges();

            }
           
              if (!dbContext.Organizador.Any())
              {
                for (int i = 0; i < 7; i++)
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
            int LocalidadeId = (from d in dbContext.Localidade where d.NomeLocalidade == "Guarda" select d.LocalidadeId).First();
            int OrganizadorId = (from d in dbContext.Organizador where d.NomeOrganizador == "Fanc" select d.OrganizadorId).First();
            int TipoEventosId = (from d in dbContext.TiposEventos where d.NomeTipoEventos == "Concerto" select d.TipoEventosId).First();
            if (!dbContext.Eventos.Any())
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            dbContext.Eventos.AddRange(
                            new Eventos
                            {
                                NomeEventos = "Dança contemporânea",
                                Descricao = "Que ou quem é do mesmo tempo ou da mesma época contemporâneo",
                                DataRealizacao = new DateTime(2020, 11, 1),
                                HoraRealizacao = new DateTime(7),
                                Lotacao = 50,
                                LocalidadeId = LocalidadeId,
                                OrganizadorId = OrganizadorId,
                                TipoEventosId = TipoEventosId,
                            }
                            );
                            dbContext.SaveChanges();
                        }
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

            );
            

            
            dbContext.Organizador.AddRange(
            new Organizador
            {
                    NomeOrganizador = "Dança contemporânea",
                    Contacto = "961656567",
                    DataNascimento = new DateTime(2020, 11, 1),
                    EmailAddress = "danca.hbm@gmail.com",
                  }
            );


            dbContext.Eventos.AddRange(
            new Eventos
            {
                NomeEventos = "Dança contemporânea",
                Descricao = "Que ou quem é do mesmo tempo ou da mesma época contemporâneo",
                DataRealizacao = new DateTime(2020, 11, 1),
                HoraRealizacao = new DateTime(7),
                Lotacao = 50,
                LocalidadeId = 1,
                OrganizadorId = 1,
                TipoEventosId = 1,

            }
            );*/

            // dbContext.SaveChanges();

        }

        /*internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByNameAsync(DEFAULT_ADMIN_USER);

            if(user == null)
            {
                user = new IdentityUser(DEFAULT_ADMIN_USER);
                await userManager.CreateAsync(user, DEFAULT_ADMIN_PASSWORD);
            }

        }*/


        internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_USER, DEFAULT_ADMIN_PASSWORD, ROLE_ADMINISTRATOR);
        }

        private static async Task EnsureUserIsCreated(UserManager<IdentityUser> userManager, string username, string password, string role)
        {
            IdentityUser user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        internal static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {

            await EnsureRoleIsCreated(roleManager, ROLE_ADMINISTRATOR);
            await EnsureRoleIsCreated(roleManager, ROLE_CUSTOMER);
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        internal static async Task SeedDevUsersAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, "marcelo@ipg.pt", "Marcelo123", ROLE_CUSTOMER);
        }
    }
}
