using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventOrg2027.Models;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin")]
        public IActionResult Index(string name = null, int page = 1)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.PAGE_SIZE_TABLE,
                TotalItems = _context.Organizador.Where(p => name == null
                || p.NomeOrganizador.Contains(name)).Count()
            };

            return View(
                new OrganizadorListViewModel
                {
                    Organizadors = _context.Organizador.Where(p => name == null
                || p.NomeOrganizador.Contains(name))
                        .OrderBy(p => p.NomeOrganizador)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize),
                    Pagination = pagination,
                    SearchName = name
                }
            );
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
                ViewBag.Message = "Este organizador talvez tenha sido eliminado.";
                return View("ViewINSUCESSO");
            }

            return View(organizador);
        }

        // GET: Organizadors/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("OrganizadorId,NomeOrganizador,Contacto,DataNascimento,EmailAddress")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizador);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Este organizador foi criado com sucesso";
                return View("ViewSUCESSO");
            }
            return View(organizador);
        }

        // GET: Organizadors/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizador.FindAsync(id);
            if (organizador == null)
            {
                ViewBag.Message = "Este organizador talvez tenha sido eliminado.";
                return View("ViewINSUCESSO");
            }
            return View(organizador);
        }

        // POST: Organizadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
                        ViewBag.Message = "Este organizador foi eliminado, pode inserir outro com as mesmas informações";
                        return View("ViewINSUCESSO");
                    }
                    else
                    {
                        ViewBag.Message = "Este organizador talvez tenha eliminado, tente novamente.";
                        return View("ViewINSUCESSO");
                        throw;
                    }
                }
                ViewBag.Message = "Este organizador foi editado com sucesso";
                return View("ViewSUCESSO");
            }
            return View(organizador);
        }

        // GET: Organizadors/Delete/5
        [Authorize(Roles = "Admin")]
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
                ViewBag.Message = "Este organizador talvez tenha sido eliminado";
                return View("ViewINSUCESSO");
            }

            return View(organizador);
        }

        // POST: Organizadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizador = await _context.Organizador.FindAsync(id);
            _context.Organizador.Remove(organizador);
            await _context.SaveChangesAsync();
            ViewBag.Message = "Este organizador foi apagado com sucesso";
            return View("ViewSUCESSO");
        }

        private bool OrganizadorExists(int id)
        {
            return _context.Organizador.Any(e => e.OrganizadorId == id);
        }
    }
}
