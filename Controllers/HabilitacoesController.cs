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
    public class HabilitacoesController : Controller
    {
        private readonly ProjectDBContext _context;

        public HabilitacoesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: Habilitacoes
        public async Task<IActionResult> Index()
        {
              return _context.Habilitacoes != null ? 
                          View(await _context.Habilitacoes.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.Habilitacoes'  is null.");
        }

        // GET: Habilitacoes/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Habilitacoes == null)
            {
                return NotFound();
            }

            var habilitacao = await _context.Habilitacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilitacao == null)
            {
                return NotFound();
            }

            return View(habilitacao);
        }

        // GET: Habilitacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habilitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDescritivo,CreatedAt,UpdatedAt")] Habilitacao habilitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habilitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habilitacao);
        }

        // GET: Habilitacoes/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Habilitacoes == null)
            {
                return NotFound();
            }

            var habilitacao = await _context.Habilitacoes.FindAsync(id);
            if (habilitacao == null)
            {
                return NotFound();
            }
            return View(habilitacao);
        }

        // POST: Habilitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,NomeDescritivo,CreatedAt,UpdatedAt")] Habilitacao habilitacao)
        {
            if (id != habilitacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habilitacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilitacaoExists(habilitacao.Id))
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
            return View(habilitacao);
        }

        // GET: Habilitacoes/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Habilitacoes == null)
            {
                return NotFound();
            }

            var habilitacao = await _context.Habilitacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilitacao == null)
            {
                return NotFound();
            }

            return View(habilitacao);
        }

        // POST: Habilitacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Habilitacoes == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.Habilitacoes'  is null.");
            }
            var habilitacao = await _context.Habilitacoes.FindAsync(id);
            if (habilitacao != null)
            {
                _context.Habilitacoes.Remove(habilitacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabilitacaoExists(byte id)
        {
          return (_context.Habilitacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
