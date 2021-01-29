using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventOrg2027.Models;

namespace EventOrg2027.Controllers
{
    public class TipoEventosController : Controller
    {
        private readonly EventOrgDbContext _context;
        


        public TipoEventosController(EventOrgDbContext context)
        {
            _context = context;
        }


        // GET: TipoEventos
        public IActionResult Index(string name = null, int page = 1)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = _context.TiposEventos.Count()
            };

            return View(
                new TipoEventoListViewModel
                {
                    TipoEventos = _context.TiposEventos.Where(p => name == null
                || p.NomeTipoEventos.Contains(name))
                        .OrderBy(p => p.NomeTipoEventos)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize),
                    Pagination = pagination,
                    SearchName = name
                }
            );
        }

        // GET: TipoEventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEventos = await _context.TiposEventos
                .FirstOrDefaultAsync(m => m.TipoEventosId == id);
            if (tipoEventos == null)
            {
                ViewBag.Message = "Este tipo de evento talvez tenha sido eliminado.";
                return View("ViewINSUCESSO");
            }

            return View(tipoEventos);
        }

        // GET: TipoEventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoEventosId,NomeTipoEventos")] TipoEventos tipoEventos)
        {
            if (ModelState.IsValid) 
            {
                _context.Add(tipoEventos);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Este tipo de evento foi criado com sucesso";
                return View("ViewSUCESSO");
            }
            return View(tipoEventos);
        }

        // GET: TipoEventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEventos = await _context.TiposEventos.FindAsync(id);
            if (tipoEventos == null)
            {
                ViewBag.Message = "Este tipo de evento talvez tenha sido eliminado.";
                return View("ViewINSUCESSO");
            }
            return View(tipoEventos);
        }

        // POST: TipoEventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoEventosId,NomeTipoEventos")] TipoEventos tipoEventos)
        {
            if (id != tipoEventos.TipoEventosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEventos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEventosExists(tipoEventos.TipoEventosId))
                    {
                        ViewBag.Message = "Este tipo de evento foi eliminado, pode inserir outro com as mesmas informações";
                        return View("ViewINSUCESSO");
                    }
                    else
                    {
                        ViewBag.Message = "Este tipo de evento talvez tenha eliminado, tente novamente.";
                        return View("ViewINSUCESSO");
                        throw;
                    }
                }
                ViewBag.Message = "Este tipo de evento foi editado com sucesso";
                return View("ViewSUCESSO");
            }
            return View(tipoEventos);
        }

        // GET: TipoEventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEventos = await _context.TiposEventos
                .FirstOrDefaultAsync(m => m.TipoEventosId == id);
            if (tipoEventos == null)
            {
                ViewBag.Message = "Este tipo de evento talvez tenha sido eliminado.";
                return View("ViewINSUCESSO");
            }

            return View(tipoEventos);
        }

        // POST: TipoEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEventos = await _context.TiposEventos.FindAsync(id);
            _context.TiposEventos.Remove(tipoEventos);
            await _context.SaveChangesAsync();
            ViewBag.Message = "Este tipo de evento foi apagado com sucesso";
            return View("ViewSUCESSO");
        }

        private bool TipoEventosExists(int id)
        {
            return _context.TiposEventos.Any(e => e.TipoEventosId == id);
        }
    }
 }

