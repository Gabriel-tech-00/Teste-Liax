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
    public class LotesController : Controller
    {
        private readonly Contexto _context;

        public LotesController(Contexto context)
        {
            _context = context;
        }

        // GET: Lotes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Lote.Include(l => l.Cidade).Include(l => l.Estado).Include(l => l.Regiao).Include(l => l.Vacina);
            return View(await contexto.ToListAsync());
        }

        // GET: Lotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                .Include(l => l.Cidade)
                .Include(l => l.Estado)
                .Include(l => l.Regiao)
                .Include(l => l.Vacina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // GET: Lotes/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "Nome");
            ViewData["EstadoId"] = new SelectList(_context.Estado, "Id", "Nome");
            ViewData["RegiaoId"] = new SelectList(_context.Regiao, "Id", "Nome");
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id");
            return View();
        }

        // POST: Lotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegiaoId,EstadoId,CidadeId,Nome,VacinaId")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "Nome", lote.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "Id", "Nome", lote.EstadoId);
            ViewData["RegiaoId"] = new SelectList(_context.Regiao, "Id", "Nome", lote.RegiaoId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", lote.VacinaId);
            return View(lote);
        }

        // GET: Lotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "Nome", lote.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "Id", "Nome", lote.EstadoId);
            ViewData["RegiaoId"] = new SelectList(_context.Regiao, "Id", "Nome", lote.RegiaoId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", lote.VacinaId);
            return View(lote);
        }

        // POST: Lotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegiaoId,EstadoId,CidadeId,Nome,VacinaId")] Lote lote)
        {
            if (id != lote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoteExists(lote.Id))
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
            ViewData["CidadeId"] = new SelectList(_context.Cidade, "Id", "Nome", lote.CidadeId);
            ViewData["EstadoId"] = new SelectList(_context.Estado, "Id", "Nome", lote.EstadoId);
            ViewData["RegiaoId"] = new SelectList(_context.Regiao, "Id", "Nome", lote.RegiaoId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", lote.VacinaId);
            return View(lote);
        }

        // GET: Lotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lote = await _context.Lote
                .Include(l => l.Cidade)
                .Include(l => l.Estado)
                .Include(l => l.Regiao)
                .Include(l => l.Vacina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lote = await _context.Lote.FindAsync(id);
            _context.Lote.Remove(lote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoteExists(int id)
        {
            return _context.Lote.Any(e => e.Id == id);
        }
    }
}
