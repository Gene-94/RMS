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
    public class NrTrabalhadoresOpcoesController : Controller
    {
        private readonly ProjectDBContext _context;

        public NrTrabalhadoresOpcoesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: NrTrabalhadoresOpcoes
        public async Task<IActionResult> Index()
        {
              return _context.NrTrabalhadoresOpcoes != null ? 
                          View(await _context.NrTrabalhadoresOpcoes.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.NrTrabalhadoresOpcoes'  is null.");
        }

        // GET: NrTrabalhadoresOpcoes/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.NrTrabalhadoresOpcoes == null)
            {
                return NotFound();
            }

            var nrTrabalhadoresOpcao = await _context.NrTrabalhadoresOpcoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nrTrabalhadoresOpcao == null)
            {
                return NotFound();
            }

            return View(nrTrabalhadoresOpcao);
        }

        // GET: NrTrabalhadoresOpcoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NrTrabalhadoresOpcoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeOpcao,CreatedAt,UpdatedAt")] NrTrabalhadoresOpcao nrTrabalhadoresOpcao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nrTrabalhadoresOpcao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nrTrabalhadoresOpcao);
        }

        // GET: NrTrabalhadoresOpcoes/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.NrTrabalhadoresOpcoes == null)
            {
                return NotFound();
            }

            var nrTrabalhadoresOpcao = await _context.NrTrabalhadoresOpcoes.FindAsync(id);
            if (nrTrabalhadoresOpcao == null)
            {
                return NotFound();
            }
            return View(nrTrabalhadoresOpcao);
        }

        // POST: NrTrabalhadoresOpcoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,NomeOpcao,CreatedAt,UpdatedAt")] NrTrabalhadoresOpcao nrTrabalhadoresOpcao)
        {
            if (id != nrTrabalhadoresOpcao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nrTrabalhadoresOpcao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NrTrabalhadoresOpcaoExists(nrTrabalhadoresOpcao.Id))
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
            return View(nrTrabalhadoresOpcao);
        }

        // GET: NrTrabalhadoresOpcoes/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.NrTrabalhadoresOpcoes == null)
            {
                return NotFound();
            }

            var nrTrabalhadoresOpcao = await _context.NrTrabalhadoresOpcoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nrTrabalhadoresOpcao == null)
            {
                return NotFound();
            }

            return View(nrTrabalhadoresOpcao);
        }

        // POST: NrTrabalhadoresOpcoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.NrTrabalhadoresOpcoes == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.NrTrabalhadoresOpcoes'  is null.");
            }
            var nrTrabalhadoresOpcao = await _context.NrTrabalhadoresOpcoes.FindAsync(id);
            if (nrTrabalhadoresOpcao != null)
            {
                _context.NrTrabalhadoresOpcoes.Remove(nrTrabalhadoresOpcao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NrTrabalhadoresOpcaoExists(byte id)
        {
          return (_context.NrTrabalhadoresOpcoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
