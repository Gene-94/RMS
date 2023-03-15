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
    public class EstadosCivisController : Controller
    {
        private readonly ProjectDBContext _context;

        public EstadosCivisController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: EstadosCivis
        public async Task<IActionResult> Index()
        {
              return _context.EstadosCivis != null ? 
                          View(await _context.EstadosCivis.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.EstadosCivis'  is null.");
        }

        // GET: EstadosCivis/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.EstadosCivis == null)
            {
                return NotFound();
            }

            var estadoCivil = await _context.EstadosCivis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            return View(estadoCivil);
        }

        // GET: EstadosCivis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosCivis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,CreatedAt,UpdatedAt")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoCivil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoCivil);
        }

        // GET: EstadosCivis/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.EstadosCivis == null)
            {
                return NotFound();
            }

            var estadoCivil = await _context.EstadosCivis.FindAsync(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }
            return View(estadoCivil);
        }

        // POST: EstadosCivis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Tipo,CreatedAt,UpdatedAt")] EstadoCivil estadoCivil)
        {
            if (id != estadoCivil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoCivil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoCivilExists(estadoCivil.Id))
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
            return View(estadoCivil);
        }

        // GET: EstadosCivis/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.EstadosCivis == null)
            {
                return NotFound();
            }

            var estadoCivil = await _context.EstadosCivis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            return View(estadoCivil);
        }

        // POST: EstadosCivis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.EstadosCivis == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.EstadosCivis'  is null.");
            }
            var estadoCivil = await _context.EstadosCivis.FindAsync(id);
            if (estadoCivil != null)
            {
                _context.EstadosCivis.Remove(estadoCivil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoCivilExists(byte id)
        {
          return (_context.EstadosCivis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
