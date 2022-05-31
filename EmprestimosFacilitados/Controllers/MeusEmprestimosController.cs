using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmprestimosFacilitados.Data;
using EmprestimosFacilitados.Models;
using EmprestimosFacilitados.ViewModels;

namespace EmprestimosFacilitados.Controllers
{
    public class MeusEmprestimosController : Controller
    {
        private readonly EmprestimosFacilitadosContext _context;
        
        [ViewData]
        public int valor { get; set; }

        public MeusEmprestimosController(EmprestimosFacilitadosContext context)
        {
            _context = context;
        }

        // GET: MeusEmprestimos
        public async Task<IActionResult> Index()
        {
            var emprestimosFacilitadosContext = _context.MeusEmprestimos.Include(m => m.Cliente).Include(m => m.TipoEmprestimo);
            return View(await emprestimosFacilitadosContext.ToListAsync());
        }

        // GET: MeusEmprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeusEmprestimos == null)
            {
                return NotFound();
            }

            var meuEmprestimo = await _context.MeusEmprestimos
                .Include(m => m.Cliente)
                .Include(m => m.TipoEmprestimo)
                .FirstOrDefaultAsync(m => m.MeuEmprestimoId == id);
            if (meuEmprestimo == null)
            {
                return NotFound();
            }

            return View(meuEmprestimo);
        }

        // GET: MeusEmprestimos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");
            ViewData["TipoEmprestimoId"] = new SelectList(_context.TiposEmprestimos, "TipoEmprestimoId", "Nome");
            return View();
        }

        // POST: MeusEmprestimos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeuEmprestimoId,ClienteId,ValorEmprestado,ValorTotalQueSerapago,ValorPago,TipoEmprestimoId,QtdParcelasPagas,IsEmprestimoQuitado")] MeuEmprestimo meuEmprestimo)
        {
            ModelState.Remove("Cliente");
            ModelState.Remove("TipoEmprestimo");
            if (ModelState.IsValid)
            {
                TipoEmprestimo tipoEmprestimo = _context.TiposEmprestimos.FirstOrDefault(t => t.TipoEmprestimoId == meuEmprestimo.TipoEmprestimoId);
                meuEmprestimo.ValorTotalQueSerapago = meuEmprestimo.ValorEmprestado * Convert.ToDecimal(tipoEmprestimo.Juros);
                _context.Add(meuEmprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf", meuEmprestimo.ClienteId);
            ViewData["TipoEmprestimoId"] = new SelectList(_context.TiposEmprestimos, "TipoEmprestimoId", "Descricao", meuEmprestimo.TipoEmprestimoId);
            return View(meuEmprestimo);
        }

        // GET: MeusEmprestimos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeusEmprestimos == null)
            {
                return NotFound();
            }

            var meuEmprestimo = await _context.MeusEmprestimos.FindAsync(id);
            if (meuEmprestimo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", meuEmprestimo.ClienteId);
            ViewData["TipoEmprestimoId"] = new SelectList(_context.TiposEmprestimos, "TipoEmprestimoId", "Nome", meuEmprestimo.TipoEmprestimoId);
            return View(meuEmprestimo);
        }

        // POST: MeusEmprestimos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeuEmprestimoId,ClienteId,ValorEmprestado,ValorTotalQueSerapago,ValorPago,TipoEmprestimoId,QtdParcelasPagas,IsEmprestimoQuitado")] MeuEmprestimo meuEmprestimo)
        {
            if (id != meuEmprestimo.MeuEmprestimoId)
            {
                return NotFound();
            }

            ModelState.Remove("Cliente");
            ModelState.Remove("TipoEmprestimo");
            if (ModelState.IsValid)
            {
                try
                {
                    TipoEmprestimo tipoEmprestimo = _context.TiposEmprestimos.FirstOrDefault(t => t.TipoEmprestimoId == meuEmprestimo.TipoEmprestimoId);
                    meuEmprestimo.ValorTotalQueSerapago = meuEmprestimo.ValorEmprestado * Convert.ToDecimal(tipoEmprestimo.Juros);
                    _context.Update(meuEmprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeuEmprestimoExists(meuEmprestimo.MeuEmprestimoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Cpf", meuEmprestimo.ClienteId);
            ViewData["TipoEmprestimoId"] = new SelectList(_context.TiposEmprestimos, "TipoEmprestimoId", "Descricao", meuEmprestimo.TipoEmprestimoId);
            return View(meuEmprestimo);
        }

        // GET: MeusEmprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeusEmprestimos == null)
            {
                return NotFound();
            }

            var meuEmprestimo = await _context.MeusEmprestimos
                .Include(m => m.Cliente)
                .Include(m => m.TipoEmprestimo)
                .FirstOrDefaultAsync(m => m.MeuEmprestimoId == id);
            if (meuEmprestimo == null)
            {
                return NotFound();
            }

            return View(meuEmprestimo);
        }

        // POST: MeusEmprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeusEmprestimos == null)
            {
                return Problem("Entity set 'EmprestimosFacilitadosContext.MeusEmprestimos'  is null.");
            }
            var meuEmprestimo = await _context.MeusEmprestimos.FindAsync(id);
            if (meuEmprestimo != null)
            {
                _context.MeusEmprestimos.Remove(meuEmprestimo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeuEmprestimoExists(int id)
        {
            return (_context.MeusEmprestimos?.Any(e => e.MeuEmprestimoId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> PagarParcela(int id)
        {
            if (id == null || _context.MeusEmprestimos == null)
            {
                return NotFound();
            }
            var pagarParcela = new PagarParcelaViewModel()
            {
                MeuEmprestimo = await _context.MeusEmprestimos
                .Include(m => m.Cliente)
                .Include(m => m.TipoEmprestimo)
                .FirstOrDefaultAsync(m => m.MeuEmprestimoId == id)
            };

            valor = 456;

            if (pagarParcela.MeuEmprestimo == null)
            {
                return NotFound();
            }
            pagarParcela.QtdParcelasParaPagar = pagarParcela.MeuEmprestimo.TipoEmprestimo.QuantidadeMeses - pagarParcela.MeuEmprestimo.QtdParcelasPagas;
            pagarParcela.ValorParcela = pagarParcela.MeuEmprestimo.ValorTotalQueSerapago / pagarParcela.MeuEmprestimo.TipoEmprestimo.QuantidadeMeses;
            return View(pagarParcela);
        }

        [HttpPost]
        public async Task<IActionResult> PagarParcela(int id, [Bind("QtdParcelasParaPagar, QtdParcelasQueDesejaPagar, ValorTotal, ValorParcela, MeuEmprestimo")] PagarParcelaViewModel pagarParcelaViewModel)
        {

            ModelState.Remove("MeuEmprestimo.Cliente");
            ModelState.Remove("MeuEmprestimo.TipoEmprestimo");
            ModelState.Remove("MeuEmprestimo.MeuEmprestimoId");
            if (ModelState.IsValid)
            {
                try
                {
                    TipoEmprestimo tipoEmprestimo = _context.TiposEmprestimos.FirstOrDefault(t => t.TipoEmprestimoId == pagarParcelaViewModel.MeuEmprestimo.TipoEmprestimoId);
                    pagarParcelaViewModel.MeuEmprestimo.QtdParcelasPagas += pagarParcelaViewModel.QtdParcelasQueDesejaPagar;
                    pagarParcelaViewModel.MeuEmprestimo.ValorPago += (pagarParcelaViewModel.ValorParcela * pagarParcelaViewModel.QtdParcelasQueDesejaPagar);
                    if(pagarParcelaViewModel.MeuEmprestimo.QtdParcelasPagas >= tipoEmprestimo.QuantidadeMeses)
                    {
                        pagarParcelaViewModel.MeuEmprestimo.IsEmprestimoQuitado = true;
                    }
                    else
                    {
                        pagarParcelaViewModel.MeuEmprestimo.IsEmprestimoQuitado = false;
                    }
                    
                    _context.Update(pagarParcelaViewModel.MeuEmprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeuEmprestimoExists(pagarParcelaViewModel.MeuEmprestimo.MeuEmprestimoId))
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

            return View(pagarParcelaViewModel);

        }





    }
}
