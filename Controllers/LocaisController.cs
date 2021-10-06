using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gerenciamento_Empresas.Models;

namespace Gerenciamento_Empresas.Controllers
{
    public class LocaisController : Controller
    {
        private readonly Contexto _context;

        public LocaisController(Contexto context)
        {
            _context = context;
        }

        // GET: Locais
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Locais.Include(l => l.Cidade).Include(l => l.Estado).Include(l => l.Regiao);
            return View(await contexto.ToListAsync());
        }

        // GET: Locais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locais = await _context.Locais
                .Include(l => l.Cidade)
                .Include(l => l.Estado)
                .Include(l => l.Regiao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locais == null)
            {
                return NotFound();
            }

            return View(locais);
        }

        // GET: Locais/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "Nome");
            ViewData["EstadoId"] = new SelectList(_context.Estado, "Id", "Nome");
            ViewData["RegiaoId"] = new SelectList(_context.Regiao, "Id", "Nome");
            return View();
        }

        // POST: Locais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,RegiaoId,EstadoId,CidadeId,Endereco")] Locais locais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "Nome", locais.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "Id", "Nome", locais.EstadoId);
            ViewData["RegiaoId"] = new SelectList(_context.Regiao, "Id", "Nome", locais.RegiaoId);
            return View(locais);
        }

        // GET: Locais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locais = await _context.Locais.FindAsync(id);
            if (locais == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "Nome", locais.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "Id", "Nome", locais.EstadoId);
            ViewData["RegiaoId"] = new SelectList(_context.Regiao, "Id", "Nome", locais.RegiaoId);
            return View(locais);
        }

        // POST: Locais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,RegiaoId,EstadoId,CidadeId,Endereco")] Locais locais)
        {
            if (id != locais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocaisExists(locais.Id))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "Nome", locais.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "Id", "Nome", locais.EstadoId);
            ViewData["RegiaoId"] = new SelectList(_context.Regiao, "Id", "Nome", locais.RegiaoId);
            return View(locais);
        }

        // GET: Locais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locais = await _context.Locais
                .Include(l => l.Cidade)
                .Include(l => l.Estado)
                .Include(l => l.Regiao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locais == null)
            {
                return NotFound();
            }

            return View(locais);
        }

        // POST: Locais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locais = await _context.Locais.FindAsync(id);
            _context.Locais.Remove(locais);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocaisExists(int id)
        {
            return _context.Locais.Any(e => e.Id == id);
        }
    }
}
