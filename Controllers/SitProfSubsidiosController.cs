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
    public class SitProfSubsidiosController : Controller
    {
        private readonly ProjectDBContext _context;

        public SitProfSubsidiosController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: SitProfSubsidios
        public async Task<IActionResult> Index()
        {
              return _context.SitProfSubsidios != null ? 
                          View(await _context.SitProfSubsidios.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.SitProfSubsidios'  is null.");
        }

        // GET: SitProfSubsidios/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.SitProfSubsidios == null)
            {
                return NotFound();
            }

            var sitProfSubsidio = await _context.SitProfSubsidios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitProfSubsidio == null)
            {
                return NotFound();
            }

            return View(sitProfSubsidio);
        }

        // GET: SitProfSubsidios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SitProfSubsidios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Detalhes,CreatedAt,UpdatedAt")] SitProfSubsidio sitProfSubsidio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sitProfSubsidio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sitProfSubsidio);
        }

        // GET: SitProfSubsidios/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.SitProfSubsidios == null)
            {
                return NotFound();
            }

            var sitProfSubsidio = await _context.SitProfSubsidios.FindAsync(id);
            if (sitProfSubsidio == null)
            {
                return NotFound();
            }
            return View(sitProfSubsidio);
        }

        // POST: SitProfSubsidios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Nome,Detalhes,CreatedAt,UpdatedAt")] SitProfSubsidio sitProfSubsidio)
        {
            if (id != sitProfSubsidio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sitProfSubsidio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SitProfSubsidioExists(sitProfSubsidio.Id))
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
            return View(sitProfSubsidio);
        }

        // GET: SitProfSubsidios/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.SitProfSubsidios == null)
            {
                return NotFound();
            }

            var sitProfSubsidio = await _context.SitProfSubsidios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sitProfSubsidio == null)
            {
                return NotFound();
            }

            return View(sitProfSubsidio);
        }

        // POST: SitProfSubsidios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.SitProfSubsidios == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.SitProfSubsidios'  is null.");
            }
            var sitProfSubsidio = await _context.SitProfSubsidios.FindAsync(id);
            if (sitProfSubsidio != null)
            {
                _context.SitProfSubsidios.Remove(sitProfSubsidio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SitProfSubsidioExists(byte id)
        {
          return (_context.SitProfSubsidios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
