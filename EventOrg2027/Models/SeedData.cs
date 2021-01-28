using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
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
            
            PopulateLocalidade(dbContext);
            PopulateOrganizador(dbContext);
            PopulateTiposEventos(dbContext);
            PopulateEvents(dbContext);
            SeedDevData(dbContext);

        }
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

        internal static void SeedDevData(EventOrgDbContext dbContext)
        {
            if (dbContext.Customer.Any()) return;
             
            dbContext.Customer.Add(new Customer
            {
                Name = "Marcelo",
                Email = "marcelo@ipg.pt"
            });

            dbContext.SaveChanges();
        }

        private static void PopulateLocalidade(EventOrgDbContext dbContext)
        {
            if (dbContext.Localidade.Any())
                return;

                dbContext.Localidade.AddRange(
                new Localidade
                {
                    NomeLocalidade = "Guarda",
                    Descricao = "jijoj",
                    Populacao = 122
                },
                new Localidade
                {
                    NomeLocalidade = "Celorico",
                    Descricao = "jijoj",
                    Populacao = 122
                },
                new Localidade
                {
                    NomeLocalidade = "Seia",
                    Descricao = "jijoj",
                    Populacao = 122
                }
                );
                dbContext.SaveChanges();
        }

        private static void PopulateOrganizador(EventOrgDbContext dbContext)
        {
            if (dbContext.Organizador.Any())
                return;

                dbContext.Organizador.AddRange(
                new Organizador
                {
                    NomeOrganizador = "Fanc",
                    Contacto = "966786786",
                    DataNascimento = new DateTime(2020, 11, 1),
                    EmailAddress = "fnac@gmail.com"

                },
                new Organizador
                {
                    NomeOrganizador = "Worten",
                    Contacto = "912456786",
                    DataNascimento = new DateTime(2018, 10, 21),
                    EmailAddress = "worten@outlook.pt"
                },
                new Organizador
                {
                    NomeOrganizador = "Eventos Online",
                    Contacto = "912000786",
                    DataNascimento = new DateTime(2010, 3, 21),
                    EmailAddress = "eventOrg@gmail.com"
                },
                new Organizador
                {
                    NomeOrganizador = "Gremio",
                    Contacto = "934456129",
                    DataNascimento = new DateTime(2021, 1, 18),
                    EmailAddress = "gremio9876@gmail.com"
                }
                );
                dbContext.SaveChanges();
        }

        private static void PopulateTiposEventos(EventOrgDbContext dbContext)
        {
            if (dbContext.TiposEventos.Any())
                return;
                            
            dbContext.TiposEventos.AddRange(
                 new TipoEventos
                 {
                    NomeTipoEventos = "Música"
                 },
                 new TipoEventos
                 {
                 NomeTipoEventos = "Concerto"
                 },
                 new TipoEventos
                 {
                 NomeTipoEventos = "Arte"
                 }
                 );
                 dbContext.SaveChanges();
        }

        private static void PopulateEvents(EventOrgDbContext dbContext)
        {
            int LocalidadeId = (from d in dbContext.Localidade where d.NomeLocalidade == "Guarda" select d.LocalidadeId).First();
            int LocalidadeId2 = (from d in dbContext.Localidade where d.NomeLocalidade == "Seia" select d.LocalidadeId).First();
            int LocalidadeId3 = (from d in dbContext.Localidade where d.NomeLocalidade == "Celorico" select d.LocalidadeId).First(); 

            int OrganizadorId = (from d in dbContext.Organizador where d.NomeOrganizador == "Fanc" select d.OrganizadorId).First(); 
            int OrganizadorId2 = (from d in dbContext.Organizador where d.NomeOrganizador == "Worten" select d.OrganizadorId).First();
            int OrganizadorId3 = (from d in dbContext.Organizador where d.NomeOrganizador == "Eventos Online" select d.OrganizadorId).First();

            int TipoEventosId = (from d in dbContext.TiposEventos where d.NomeTipoEventos == "Concerto" select d.TipoEventosId).First();
            int TipoEventosId2 = (from d in dbContext.TiposEventos where d.NomeTipoEventos == "Música" select d.TipoEventosId).First();
            int TipoEventosId3 = (from d in dbContext.TiposEventos where d.NomeTipoEventos == "Arte" select d.TipoEventosId).First();

            if (dbContext.Eventos.Any())
                return;

                dbContext.Eventos.AddRange(
                new Eventos
                {
                    NomeEventos = "Festival de Tunas",
                    Descricao = "O OPPIDANA é um Festival de Tunas de carácter competitivo, que se realiza na cidade da Guarda. Durante os dias 19, 20 e 21 de Março é dado a conhecer aos habitantes da cidade e da região um pouco da cultura.",
                    DataRealizacao = new DateTime(2021, 11, 1),
                    HoraRealizacao = new DateTime(2020, 2, 20, 20, 00, 0),
                    Lotacao = 150,
                    LocalidadeId = LocalidadeId,
                    OrganizadorId = OrganizadorId3,
                    TipoEventosId = TipoEventosId2
                },
                new Eventos
                {
                    NomeEventos = "Classic Cars Tour em junho",
                    Descricao = "A exemplo do que sucedeu em 2019, ano da primeira edição, o Classic Cars Tour volta a dividir-se numa prova de regularidade e num passeio com os participantes a escolherem a opção em que querem participar. Centrado no Longroiva Hotel &Termal SPA, o Classic Cars Tour terá um percurso que passará pelo território dos seis concelhos envolvidos, aí realizando paragens, visitas ou refeições. Será mais uma oportunidade, com a chancela de qualidade do Clube Escape Livre, para participantes oriundos de todo o país, e também da vizinha Espanha, conhecerem as belas paisagens, o património e a excelente gastronomia da região.",
                    DataRealizacao = new DateTime(2020, 6, 25),
                    HoraRealizacao = new DateTime(2020,2,20,16,00,0),
                    Lotacao = 50,
                    LocalidadeId = LocalidadeId2,
                    OrganizadorId = OrganizadorId,
                    TipoEventosId = TipoEventosId
                },
                new Eventos
                {
                    NomeEventos = "LENA D’ÁGUA",
                    Descricao = "Lena d’Água juntou-se, assim, a uma série de novos colaboradores nesta fase renovada da sua carreira. Aliás, em 2017, a cantora chegou à final do Festival da Canção com um tema da autoria de Pedro da Silva Martins. Pouco antes, tinha atuado na Casa Independente, em Lisboa, com os They’re Heading West (dos quais fazem parte Sérgio Nascimento, Mariana Ricardo, João Correia e Francisca Cortesão), concerto que “foi um acontecimento”, além de ter sido convidada por Benjamim para o seu concerto no CCB, no final de 2016.",
                    DataRealizacao = new DateTime(2020, 11, 22),
                    HoraRealizacao = new DateTime(2020, 2, 20, 21, 45, 0),
                    Lotacao = 20,
                    LocalidadeId = LocalidadeId3,
                    OrganizadorId = OrganizadorId2,
                    TipoEventosId = TipoEventosId3
                });
                dbContext.SaveChanges();
            }
        

        

        

    }
}
