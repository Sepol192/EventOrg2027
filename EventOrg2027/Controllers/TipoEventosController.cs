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
        private readonly EventOrgRepository repository;


        public TipoEventosController(EventOrgRepository repository)
        {
            this.repository = repository;
        }


        // GET: TipoEventos
        public async Task<IActionResult> Index(int page = 1)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = repository.TipoEventos.Count()
            };

            return View(
                new TipoEventoListViewModel
                {
                    TipoEventos = repository.TipoEventos
                        .OrderBy(p => p.NomeTipoEventos)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize),
                    Pagination = pagination
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
                return NotFound();
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
                return RedirectToAction(nameof(Index));
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
                return NotFound();
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
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
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
                return NotFound();
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
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEventosExists(int id)
        {
            return _context.TiposEventos.Any(e => e.TipoEventosId == id);
        }
    }
 }

