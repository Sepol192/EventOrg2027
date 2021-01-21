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

                dbContext.Organizador.AddRange(
                new Organizador
                {
                    NomeOrganizador = "Fanc",
                    Contacto = "966786786",
                    DataNascimento = new DateTime(2020, 11, 1),
                    EmailAddress = "fnac@gmail.com",

                },
                new Organizador
                {
                    NomeOrganizador = "Worten",
                    Contacto = "912456786",
                    DataNascimento = new DateTime(2018, 10, 21),
                    EmailAddress = "fnac@gmail.com",
                },
                new Organizador
                {
                    NomeOrganizador = "Eventos Online",
                    Contacto = "212000786",
                    DataNascimento = new DateTime(2010, 3, 21),
                    EmailAddress = "fnac@gmail.com",
                },
                new Organizador
                {
                    NomeOrganizador = "Gremio",
                    Contacto = "934456129",
                    DataNascimento = new DateTime(2021, 1, 18),
                    EmailAddress = "fnac@gmail.com",
                }
                );
                dbContext.SaveChanges();

            }
            int LocalidadeId = (from d in dbContext.Localidade where d.NomeLocalidade == "Guarda" select d.LocalidadeId).First();
            int OrganizadorId = (from d in dbContext.Organizador where d.NomeOrganizador == "Fanc" select d.OrganizadorId).First();
            int TipoEventosId = (from d in dbContext.TiposEventos where d.NomeTipoEventos == "Concerto" select d.TipoEventosId).First();
            if (!dbContext.Eventos.Any())
            {
                dbContext.Eventos.AddRange(
                new Eventos
                {
                    NomeEventos = "Festival de Tunas",
                    Descricao = "do Teatro Municipal da Guarda, muitota cidade.",
                    DataRealizacao = new DateTime(2021, 11, 1),
                    HoraRealizacao = new DateTime(20),
                    Lotacao = 150,
                    LocalidadeId = LocalidadeId,
                    OrganizadorId = OrganizadorId,
                    TipoEventosId = TipoEventosId,
                },
                new Eventos
                {
                    NomeEventos = "Classic Cars Tour em junho",
                    Descricao = "o em comunicado.",
                    DataRealizacao = new DateTime(2020, 6, 25),
                    HoraRealizacao = new DateTime(16),
                    Lotacao = 50,
                    LocalidadeId = LocalidadeId,
                    OrganizadorId = OrganizadorId,
                    TipoEventosId = TipoEventosId,
                },
                new Eventos
                {
                    NomeEventos = "LENA D’ÁGUA",
                    Descricao = "s discos de originais, em 2019 com o disco ",
                    DataRealizacao = new DateTime(2020, 11, 22),
                    HoraRealizacao = new DateTime(9),
                    Lotacao = 20,
                    LocalidadeId = LocalidadeId,
                    OrganizadorId = OrganizadorId,
                    TipoEventosId = TipoEventosId,
                }
                );
                dbContext.SaveChanges();
            }
        }

        internal static void SeedDevData(EventOrgDbContext db)
        {
            if (db.Customer.Any()) return;

            db.Customer.Add(new Customer
            {
                Name = "Marcelo",
                Email = "marcelo@ipg.pt"
            });

            db.SaveChanges();
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
    }
}
