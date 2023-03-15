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
    public class SubsidiosController : Controller
    {
        private readonly ProjectDBContext _context;

        public SubsidiosController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: Subsidios
        public async Task<IActionResult> Index()
        {
              return _context.Subsidios != null ? 
                          View(await _context.Subsidios.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.Subsidios'  is null.");
        }

        // GET: Subsidios/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Subsidios == null)
            {
                return NotFound();
            }

            var subsidio = await _context.Subsidios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subsidio == null)
            {
                return NotFound();
            }

            return View(subsidio);
        }

        // GET: Subsidios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subsidios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,CreatedAt,UpdatedAt")] Subsidio subsidio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subsidio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subsidio);
        }

        // GET: Subsidios/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Subsidios == null)
            {
                return NotFound();
            }

            var subsidio = await _context.Subsidios.FindAsync(id);
            if (subsidio == null)
            {
                return NotFound();
            }
            return View(subsidio);
        }

        // POST: Subsidios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Tipo,CreatedAt,UpdatedAt")] Subsidio subsidio)
        {
            if (id != subsidio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subsidio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubsidioExists(subsidio.Id))
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
            return View(subsidio);
        }

        // GET: Subsidios/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Subsidios == null)
            {
                return NotFound();
            }

            var subsidio = await _context.Subsidios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subsidio == null)
            {
                return NotFound();
            }

            return View(subsidio);
        }

        // POST: Subsidios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Subsidios == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.Subsidios'  is null.");
            }
            var subsidio = await _context.Subsidios.FindAsync(id);
            if (subsidio != null)
            {
                _context.Subsidios.Remove(subsidio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubsidioExists(byte id)
        {
          return (_context.Subsidios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
