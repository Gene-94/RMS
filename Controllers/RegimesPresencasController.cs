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
    public class RegimesPresencasController : Controller
    {
        private readonly ProjectDBContext _context;

        public RegimesPresencasController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: RegimesPresencas
        public async Task<IActionResult> Index()
        {
              return _context.RegimesPresencas != null ? 
                          View(await _context.RegimesPresencas.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.RegimesPresencas'  is null.");
        }

        // GET: RegimesPresencas/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.RegimesPresencas == null)
            {
                return NotFound();
            }

            var regimesPresenca = await _context.RegimesPresencas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regimesPresenca == null)
            {
                return NotFound();
            }

            return View(regimesPresenca);
        }

        // GET: RegimesPresencas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegimesPresencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeRegime,CreatedAt,UpdatedAt")] RegimesPresenca regimesPresenca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regimesPresenca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regimesPresenca);
        }

        // GET: RegimesPresencas/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.RegimesPresencas == null)
            {
                return NotFound();
            }

            var regimesPresenca = await _context.RegimesPresencas.FindAsync(id);
            if (regimesPresenca == null)
            {
                return NotFound();
            }
            return View(regimesPresenca);
        }

        // POST: RegimesPresencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,NomeRegime,CreatedAt,UpdatedAt")] RegimesPresenca regimesPresenca)
        {
            if (id != regimesPresenca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regimesPresenca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegimesPresencaExists(regimesPresenca.Id))
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
            return View(regimesPresenca);
        }

        // GET: RegimesPresencas/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.RegimesPresencas == null)
            {
                return NotFound();
            }

            var regimesPresenca = await _context.RegimesPresencas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regimesPresenca == null)
            {
                return NotFound();
            }

            return View(regimesPresenca);
        }

        // POST: RegimesPresencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.RegimesPresencas == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.RegimesPresencas'  is null.");
            }
            var regimesPresenca = await _context.RegimesPresencas.FindAsync(id);
            if (regimesPresenca != null)
            {
                _context.RegimesPresencas.Remove(regimesPresenca);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegimesPresencaExists(byte id)
        {
          return (_context.RegimesPresencas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
