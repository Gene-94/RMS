using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistrationManagmentSimplified.DB;
using RegistrationManagmentSimplified.Models;

namespace RegistrationManagmentSimplified.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly ProjectDBContext _context;

        public EmpresasController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var gestaoinscricoesLaravelContext = _context.Empresas.Include(e => e.NrTrabalhadores);
            return View(await gestaoinscricoesLaravelContext.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.NrTrabalhadores)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewData["NrTrabalhadoresId"] = new SelectList(_context.NrTrabalhadoresOpcoes, "Id", "Id");
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEmpresa,NifEmpresa,MoradaEmpresa,PostalEmpresa,NrTrabalhadoresId,CreatedAt,UpdatedAt")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NrTrabalhadoresId"] = new SelectList(_context.NrTrabalhadoresOpcoes, "Id", "Id", empresa.NrTrabalhadoresId);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["NrTrabalhadoresId"] = new SelectList(_context.NrTrabalhadoresOpcoes, "Id", "Id", empresa.NrTrabalhadoresId);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,NomeEmpresa,NifEmpresa,MoradaEmpresa,PostalEmpresa,NrTrabalhadoresId,CreatedAt,UpdatedAt")] Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
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
            ViewData["NrTrabalhadoresId"] = new SelectList(_context.NrTrabalhadoresOpcoes, "Id", "Id", empresa.NrTrabalhadoresId);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.NrTrabalhadores)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            if (_context.Empresas == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.Empresas'  is null.");
            }
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(ulong id)
        {
          return (_context.Empresas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
