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


        // GET: Eventos   
        public async Task<IActionResult> Index(string localEvento, string name = null, int page = 1)
        {

            IQueryable<string> genreQuery = from m in _context.Eventos
                                            orderby m.EventosId
                                            select m.Localidade.NomeLocalidade;

            var pagination = new PagingInfo

            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = _context.Eventos.Where(p => name == null 
                || p.NomeEventos.Contains(name)
                && p.Localidade.NomeLocalidade.Contains(localEvento)).Count()
            };

            return View(
                new EventosListViewModel
                {
                    Eventos = _context.Eventos.Where(p => name == null 
                    || p.NomeEventos.Contains(name) 
                    && p.Localidade.NomeLocalidade.Contains(localEvento))         
                    .OrderBy(p => p.HoraRealizacao)
                    .Skip((page - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .Include(e => e.Localidade).Include(e => e.Organizador).Include(e => e.TipoEventos),

                    Pagination = pagination,
                    Localidades = new SelectList(await genreQuery.Distinct().ToListAsync()),
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