﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventOrg2027.Data;
using EventOrg2027.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventOrg2027.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly EventOrgDbContext _context;
        


        public LocalidadesController(EventOrgDbContext context)
        {
            _context = context;
        }

        // GET: Localidades
        [Authorize(Roles = "Admin")]
        public IActionResult Index(string name = null, int page = 1)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.PAGE_SIZE_TABLE,
                TotalItems = _context.Localidade.Count()
            };

            return View(
                new LocalidadesListViewModel
                {
                    Localidades = _context.Localidade.Where(p => name == null
                || p.NomeLocalidade.Contains(name))
                        .OrderBy(p => p.NomeLocalidade)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize),
                    Pagination = pagination,
                    SearchName = name
                }
            );
        }

        // GET: Localidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidade
                .FirstOrDefaultAsync(m => m.LocalidadeId == id);
            if (localidade == null)
            {
                ViewBag.Message = "Esta localidade talvez tenha sido eliminada.";
                return View("ViewINSUCESSO");
            }

            return View(localidade);
        }

        // GET: Localidades/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Localidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("LocalidadeId,NomeLocalidade,Descricao,Populacao")] Localidade localidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localidade);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Esta localidade foi criada com sucesso";
                return View("ViewSUCESSO");
            }
            return View(localidade);
        }

        // GET: Localidades/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidade.FindAsync(id);
            if (localidade == null)
            {
                ViewBag.Message = "Esta localidade talvez tenha sido eliminada.";
                return View("ViewINSUCESSO");
            }
            return View(localidade);
        }

        // POST: Localidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("LocalidadeId,NomeLocalidade,Descricao,Populacao")] Localidade localidade)
        {
            if (id != localidade.LocalidadeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalidadeExists(localidade.LocalidadeId))
                    {
                        ViewBag.Message = "Esta localidade foi eliminada, pode inserir outra com as mesmas informações";
                        return View("ViewINSUCESSO");
                    }
                    else
                    {
                        ViewBag.Message = "Esta localidade talvez tenha eliminada, tente novamente.";
                        return View("ViewINSUCESSO");
                        throw;
                    }
                }
                ViewBag.Message = "Esta localidade foi editada com sucesso";
                return View("ViewSUCESSO");
            }
            return View(localidade);
        }

        // GET: Localidades/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localidade = await _context.Localidade
                .FirstOrDefaultAsync(m => m.LocalidadeId == id);
            if (localidade == null)
            {
                ViewBag.Message = "Esta localidade talvez tenha sido eliminada.";
                return View("ViewINSUCESSO");
            }

            return View(localidade);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localidade = await _context.Localidade.FindAsync(id);
            _context.Localidade.Remove(localidade);
            await _context.SaveChangesAsync();
            ViewBag.Message = "Esta localidade foi apagada com sucesso";
            return View("ViewSUCESSO");
        }

        private bool LocalidadeExists(int id)
        {
            return _context.Localidade.Any(e => e.LocalidadeId == id);
        }
    }
}
