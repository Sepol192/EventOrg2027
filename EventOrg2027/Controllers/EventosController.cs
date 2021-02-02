using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventOrg2027.Data;
using EventOrg2027.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace EventOrg2027.Controllers
{
    public class EventosController : Controller
    {
        private readonly EventOrgDbContext _context;

        public EventosController(EventOrgDbContext _context)
        {
            this._context = _context;
        }
  
        public IActionResult Reservas(string name = null,int page = 1)
        {

            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.PAGE_SIZE_TABLE,
                TotalItems = _context.Inscricao.Where(x => x.UserID == User.Identity.Name && (name == null || x.EventoNome.Contains(name))).Count()
            };
            return View(
            new InscricaoListViewModel
            {
                inscricaos = _context.Inscricao.Where(x => x.UserID == User.Identity.Name && (name == null || x.EventoNome.Contains(name)))
                    .OrderByDescending(p => p.DataInscricao)
                    .Skip((page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize),
                     Pagination = pagination
                }
            );
        }


        public IActionResult Reserva(int id) {

            var evento = _context.Eventos.Where(m => m.EventosId == id).FirstOrDefault();
            var p = _context.Inscricao.Where(X => (X.UserID.Contains(User.Identity.Name) && X.EventoID == id)).Count();

            var lotacao = _context.Eventos.Where(x => x.EventosId == id).Select(x => x.Lotacao).FirstOrDefault();
            var totalinscritos = _context.Inscricao.Where(x => x.EventoID == id).Count();

            var data = _context.Eventos.Where(x => x.EventosId == id).Select(x => x.DataRealizacao).FirstOrDefault();

            if (id == 0)
            {
                return NotFound();
            }

            if ( p == 1 )
            {
                ViewBag.Message = "Utilizador já inscrito neste evento.";
                return View("ViewINSUCESSO");
            } else if (totalinscritos > lotacao - 1)
            {
                ViewBag.Message = "Inscrição excedeu o número máximo de reservas.";
                return View("ViewINSUCESSO");
            } else if (data < DateTime.Now)
            {
                ViewBag.Message = "Este evento já ocorreu.";
                return View("ViewINSUCESSO");
            }
            else { 
            Inscricao inscricao = new Inscricao();
            inscricao.DataInscricao = DateTime.Now;
            inscricao.UserID = User.Identity.Name;
            inscricao.EventoID = id;
            inscricao.EventoNome = _context.Eventos.Where(x => x.EventosId == id).Select(x => x.NomeEventos).FirstOrDefault();
            inscricao.DataRealizacao = _context.Eventos.Where(x => x.EventosId == id).Select(x => x.DataRealizacao).FirstOrDefault();
            inscricao.HoraRealizacao = _context.Eventos.Where(x => x.EventosId == id).Select(x => x.HoraRealizacao).FirstOrDefault();
            inscricao.Eventos = evento;
            _context.Inscricao.Add(inscricao);
            _context.SaveChanges(); 
            var idEvento = inscricao.ID;
            
            }
            ViewBag.Message = "Utilizador inscrito.";
            return View("ViewSUCESSO");
            
        }


        // GET: Eventos
        public async Task<IActionResult> Index(string TipoEvento,string OrgEvento,string LocalEvento, string name = null, int page = 1)
        {

            IQueryable<string> genreQuery = from m in _context.Eventos
                                            orderby m.EventosId
                                            select m.Localidade.NomeLocalidade;

            IQueryable<string> OrganizadorQuery = from m in _context.Eventos
                                            orderby m.EventosId 
                                            select m.Organizador.NomeOrganizador;

            IQueryable<string> TipoEventoQuery = from m in _context.Eventos
                                            orderby m.EventosId
                                            select m.TipoEventos.NomeTipoEventos; 

            var pagination = new PagingInfo

            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = _context.Eventos.Where(p => (name == null
                || p.NomeEventos.Contains(name))
                && (LocalEvento == null || p.Localidade.NomeLocalidade == LocalEvento)
                && (OrgEvento == null || p.Organizador.NomeOrganizador == OrgEvento)
                &&(TipoEvento == null || p.TipoEventos.NomeTipoEventos == TipoEvento)).Count()
            };

            return View(
                new EventosListViewModel
                {
                    Eventos = _context.Eventos.Where(p => (name == null
                    || p.NomeEventos.Contains(name))
                    && (LocalEvento == null || p.Localidade.NomeLocalidade == LocalEvento)
                    && (OrgEvento == null || p.Organizador.NomeOrganizador == OrgEvento)
                    && (TipoEvento == null || p.TipoEventos.NomeTipoEventos == TipoEvento))

                    .OrderByDescending(p => p.DataRealizacao)
                    .Skip((page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .Include(e => e.Localidade).Include(e => e.Organizador).Include(e => e.TipoEventos),

                    Pagination = pagination,
                    Localidades = new SelectList(await genreQuery.Distinct().ToListAsync()),
                    Organizadores = new SelectList(await OrganizadorQuery.Distinct().ToListAsync()),
                    TiposEventos = new SelectList(await TipoEventoQuery.Distinct().ToListAsync()),
                    SearchName = name

                }
            );
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var eventos = await _context.Eventos
                .Include(e => e.Localidade)
                .Include(e => e.Organizador)
                .Include(e => e.TipoEventos)
                .FirstOrDefaultAsync(m => m.EventosId == id);
            if (eventos == null)
            {
                ViewBag.Message = "Este evento talvez tenha sido eliminado.";
                return View("ViewINSUCESSO");
            }

            return View(eventos);
        }

        // GET: Eventos/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["LocalidadeId"] = new SelectList(_context.Localidade, "LocalidadeId", "NomeLocalidade");
            ViewData["OrganizadorId"] = new SelectList(_context.Organizador, "OrganizadorId", "NomeOrganizador");
            ViewData["TipoEventosId"] = new SelectList(_context.TiposEventos, "TipoEventosId", "NomeTipoEventos");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventosId,NomeEventos,Descricao,Lotacao,DataRealizacao,HoraRealizacao,LocalidadeId,TipoEventosId,OrganizadorId")] Eventos eventos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventos);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Este evento foi criado com sucesso";
                return View("ViewSUCESSO");
            }
            ViewData["LocalidadeId"] = new SelectList(_context.Localidade, "LocalidadeId", "NomeLocalidade", eventos.LocalidadeId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizador, "OrganizadorId", "NomeOrganizador", eventos.OrganizadorId);
            ViewData["TipoEventosId"] = new SelectList(_context.TiposEventos, "TipoEventosId", "NomeTipoEventos", eventos.TipoEventosId);
            return View(eventos);
        }

        // GET: Eventos/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos.FindAsync(id);
            if (eventos == null)
            {
                ViewBag.Message = "Este evento talvez tenha sido eliminado.";
                return View("ViewINSUCESSO");
            }
            ViewData["LocalidadeId"] = new SelectList(_context.Localidade, "LocalidadeId", "NomeLocalidade", eventos.LocalidadeId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizador, "OrganizadorId", "NomeOrganizador", eventos.OrganizadorId);
            ViewData["TipoEventosId"] = new SelectList(_context.TiposEventos, "TipoEventosId", "NomeTipoEventos", eventos.TipoEventosId);
            
            return View(eventos);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("EventosId,NomeEventos,Descricao,Lotacao,DataRealizacao,HoraRealizacao,LocalidadeId,TipoEventosId,OrganizadorId")] Eventos eventos)
        {
            if (id != eventos.EventosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventosExists(eventos.EventosId))
                    {
                        ViewBag.Message = "Este evento foi eliminado, pode inserir outro com as mesmas informações";
                        return View("ViewINSUCESSO");
                    }
                    else
                    {
                        ViewBag.Message = "Este evento talvez tenha eliminado, tente novamente.";
                        return View("ViewINSUCESSO");
                        throw;
                    }
                }
                ViewBag.Message = "Este evento foi editado com sucesso";
                return View("ViewSUCESSO");
            }
            ViewData["LocalidadeId"] = new SelectList(_context.Localidade, "LocalidadeId", "NomeLocalidade", eventos.LocalidadeId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizador, "OrganizadorId", "NomeOrganizador", eventos.OrganizadorId);
            ViewData["TipoEventosId"] = new SelectList(_context.TiposEventos, "TipoEventosId", "NomeTipoEventos", eventos.TipoEventosId);
            return View(eventos);
        }

        // GET: Eventos/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventos = await _context.Eventos
                .Include(e => e.Localidade)
                .Include(e => e.Organizador)
                .Include(e => e.TipoEventos)
                .FirstOrDefaultAsync(m => m.EventosId == id);
            if (eventos == null)
            {
                ViewBag.Message = "Este evento talvez tenha sido eliminado";
                return View("ViewINSUCESSO");
            }

            return View(eventos);
        }

        // POST: Eventos/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventos = await _context.Eventos.FindAsync(id);
                _context.Eventos.Remove(eventos);
                await _context.SaveChangesAsync();
            ViewBag.Message = "Este evento foi apagado com sucesso";
            return View("ViewSUCESSO");
        }

        private bool EventosExists(int id)
        {
            return _context.Eventos.Any(e => e.EventosId == id);
        }
    }
}