using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmprestimosFacilitados.Data;
using EmprestimosFacilitados.Models;

namespace EmprestimosFacilitados.Controllers
{
    public class TiposEmprestimosController : Controller
    {
        private readonly EmprestimosFacilitadosContext _context;

        public TiposEmprestimosController(EmprestimosFacilitadosContext context)
        {
            _context = context;
        }

        // GET: TiposEmprestimos
        public async Task<IActionResult> Index()
        {
              return _context.TiposEmprestimos != null ? 
                          View(await _context.TiposEmprestimos.ToListAsync()) :
                          Problem("Entity set 'EmprestimosFacilitadosContext.TiposEmprestimos'  is null.");
        }

        // GET: TiposEmprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposEmprestimos == null)
            {
                return NotFound();
            }

            var tipoEmprestimo = await _context.TiposEmprestimos
                .FirstOrDefaultAsync(m => m.TipoEmprestimoId == id);
            if (tipoEmprestimo == null)
            {
                return NotFound();
            }

            return View(tipoEmprestimo);
        }

        // GET: TiposEmprestimos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposEmprestimos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoEmprestimoId,Nome,QuantidadeMeses,Juros,Descricao")] TipoEmprestimo tipoEmprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEmprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEmprestimo);
        }

        // GET: TiposEmprestimos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposEmprestimos == null)
            {
                return NotFound();
            }

            var tipoEmprestimo = await _context.TiposEmprestimos.FindAsync(id);
            if (tipoEmprestimo == null)
            {
                return NotFound();
            }
            return View(tipoEmprestimo);
        }

        // POST: TiposEmprestimos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoEmprestimoId,Nome,QuantidadeMeses,Juros,Descricao")] TipoEmprestimo tipoEmprestimo)
        {
            if (id != tipoEmprestimo.TipoEmprestimoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEmprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEmprestimoExists(tipoEmprestimo.TipoEmprestimoId))
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
            return View(tipoEmprestimo);
        }

        // GET: TiposEmprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposEmprestimos == null)
            {
                return NotFound();
            }

            var tipoEmprestimo = await _context.TiposEmprestimos
                .FirstOrDefaultAsync(m => m.TipoEmprestimoId == id);
            if (tipoEmprestimo == null)
            {
                return NotFound();
            }

            return View(tipoEmprestimo);
        }

        // POST: TiposEmprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposEmprestimos == null)
            {
                return Problem("Entity set 'EmprestimosFacilitadosContext.TiposEmprestimos'  is null.");
            }
            var tipoEmprestimo = await _context.TiposEmprestimos.FindAsync(id);
            if (tipoEmprestimo != null)
            {
                _context.TiposEmprestimos.Remove(tipoEmprestimo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEmprestimoExists(int id)
        {
          return (_context.TiposEmprestimos?.Any(e => e.TipoEmprestimoId == id)).GetValueOrDefault();
        }
    }
}
