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
    public class OrganizadorsController : Controller
    {
        private readonly EventOrgDbContext _context;

        public OrganizadorsController(EventOrgDbContext context)
        {
            _context = context;
        }

        // GET: Organizadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organizador.ToListAsync());
        }

        // GET: Organizadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizador
                .FirstOrDefaultAsync(m => m.OrganizadorId == id);
            if (organizador == null)
            {
                return NotFound();
            }

            return View(organizador);
        }

        // GET: Organizadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizadorId,NomeOrganizador,Contacto,DataNascimento,EmailAddress")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizador);
        }

        // GET: Organizadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizador.FindAsync(id);
            if (organizador == null)
            {
                return NotFound();
            }
            return View(organizador);
        }

        // POST: Organizadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizadorId,NomeOrganizador,Contacto,DataNascimento,EmailAddress")] Organizador organizador)
        {
            if (id != organizador.OrganizadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizadorExists(organizador.OrganizadorId))
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
            return View(organizador);
        }

        // GET: Organizadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizador
                .FirstOrDefaultAsync(m => m.OrganizadorId == id);
            if (organizador == null)
            {
                return NotFound();
            }

            return View(organizador);
        }

        // POST: Organizadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizador = await _context.Organizador.FindAsync(id);
            _context.Organizador.Remove(organizador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizadorExists(int id)
        {
            return _context.Organizador.Any(e => e.OrganizadorId == id);
        }
    }
}
