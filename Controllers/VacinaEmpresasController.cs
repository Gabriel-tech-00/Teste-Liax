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
    public class VacinaEmpresasController : Controller
    {
        private readonly Contexto _context;

        public VacinaEmpresasController(Contexto context)
        {
            _context = context;
        }

        // GET: VacinaEmpresas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.VacinaEmpresa.Include(v => v.Empresa).Include(v => v.Vacina);
            return View(await contexto.ToListAsync());
        }

        // GET: VacinaEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacinaEmpresa = await _context.VacinaEmpresa
                .Include(v => v.Empresa)
                .Include(v => v.Vacina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacinaEmpresa == null)
            {
                return NotFound();
            }

            return View(vacinaEmpresa);
        }

        // GET: VacinaEmpresas/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome");
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id");
            return View();
        }

        // POST: VacinaEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpresaId,VacinaId")] VacinaEmpresa vacinaEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacinaEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", vacinaEmpresa.EmpresaId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", vacinaEmpresa.VacinaId);
            return View(vacinaEmpresa);
        }

        // GET: VacinaEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacinaEmpresa = await _context.VacinaEmpresa.FindAsync(id);
            if (vacinaEmpresa == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", vacinaEmpresa.EmpresaId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", vacinaEmpresa.VacinaId);
            return View(vacinaEmpresa);
        }

        // POST: VacinaEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpresaId,VacinaId")] VacinaEmpresa vacinaEmpresa)
        {
            if (id != vacinaEmpresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacinaEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacinaEmpresaExists(vacinaEmpresa.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", vacinaEmpresa.EmpresaId);
            ViewData["VacinaId"] = new SelectList(_context.Vacina, "Id", "Id", vacinaEmpresa.VacinaId);
            return View(vacinaEmpresa);
        }

        // GET: VacinaEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacinaEmpresa = await _context.VacinaEmpresa
                .Include(v => v.Empresa)
                .Include(v => v.Vacina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacinaEmpresa == null)
            {
                return NotFound();
            }

            return View(vacinaEmpresa);
        }

        // POST: VacinaEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacinaEmpresa = await _context.VacinaEmpresa.FindAsync(id);
            _context.VacinaEmpresa.Remove(vacinaEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacinaEmpresaExists(int id)
        {
            return _context.VacinaEmpresa.Any(e => e.Id == id);
        }
    }
}
