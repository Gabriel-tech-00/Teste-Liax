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
    public class PessoaVacinasController : Controller
    {
        private readonly Contexto _context;

        public PessoaVacinasController(Contexto context)
        {
            _context = context;
        }

        // GET: PessoaVacinas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.PessoaVacina.Include(p => p.Pessoa).Include(p => p.Vacina);
            return View(await contexto.ToListAsync());
        }

        // GET: PessoaVacinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaVacina = await _context.PessoaVacina
                .Include(p => p.Pessoa)
                .Include(p => p.Vacina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaVacina == null)
            {
                return NotFound();
            }

            return View(pessoaVacina);
        }

        // GET: PessoaVacinas/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Cpf", "Cpf");
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id");
            return View();
        }

        // POST: PessoaVacinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PessoaId,VacinaId")] PessoaVacina pessoaVacina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pessoaVacina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Cpf", "Cpf", pessoaVacina.PessoaId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", pessoaVacina.VacinaId);
            return View(pessoaVacina);
        }

        // GET: PessoaVacinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaVacina = await _context.PessoaVacina.FindAsync(id);
            if (pessoaVacina == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Cpf", "Cpf", pessoaVacina.PessoaId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", pessoaVacina.VacinaId);
            return View(pessoaVacina);
        }

        // POST: PessoaVacinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PessoaId,VacinaId")] PessoaVacina pessoaVacina)
        {
            if (id != pessoaVacina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoaVacina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaVacinaExists(pessoaVacina.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoa, "Cpf", "Cpf", pessoaVacina.PessoaId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", pessoaVacina.VacinaId);
            return View(pessoaVacina);
        }

        // GET: PessoaVacinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaVacina = await _context.PessoaVacina
                .Include(p => p.Pessoa)
                .Include(p => p.Vacina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaVacina == null)
            {
                return NotFound();
            }

            return View(pessoaVacina);
        }

        // POST: PessoaVacinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoaVacina = await _context.PessoaVacina.FindAsync(id);
            _context.PessoaVacina.Remove(pessoaVacina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaVacinaExists(int id)
        {
            return _context.PessoaVacina.Any(e => e.Id == id);
        }
    }
}
