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
    public class RegimesHorariosController : Controller
    {
        private readonly ProjectDBContext _context;

        public RegimesHorariosController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: RegimesHorarios
        public async Task<IActionResult> Index()
        {
              return _context.RegimesHorarios != null ? 
                          View(await _context.RegimesHorarios.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.RegimesHorarios'  is null.");
        }

        // GET: RegimesHorarios/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.RegimesHorarios == null)
            {
                return NotFound();
            }

            var regimesHorario = await _context.RegimesHorarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regimesHorario == null)
            {
                return NotFound();
            }

            return View(regimesHorario);
        }

        // GET: RegimesHorarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegimesHorarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeRegime,CreatedAt,UpdatedAt")] RegimesHorario regimesHorario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regimesHorario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regimesHorario);
        }

        // GET: RegimesHorarios/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.RegimesHorarios == null)
            {
                return NotFound();
            }

            var regimesHorario = await _context.RegimesHorarios.FindAsync(id);
            if (regimesHorario == null)
            {
                return NotFound();
            }
            return View(regimesHorario);
        }

        // POST: RegimesHorarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,NomeRegime,CreatedAt,UpdatedAt")] RegimesHorario regimesHorario)
        {
            if (id != regimesHorario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regimesHorario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegimesHorarioExists(regimesHorario.Id))
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
            return View(regimesHorario);
        }

        // GET: RegimesHorarios/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.RegimesHorarios == null)
            {
                return NotFound();
            }

            var regimesHorario = await _context.RegimesHorarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regimesHorario == null)
            {
                return NotFound();
            }

            return View(regimesHorario);
        }

        // POST: RegimesHorarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.RegimesHorarios == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.RegimesHorarios'  is null.");
            }
            var regimesHorario = await _context.RegimesHorarios.FindAsync(id);
            if (regimesHorario != null)
            {
                _context.RegimesHorarios.Remove(regimesHorario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegimesHorarioExists(byte id)
        {
          return (_context.RegimesHorarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
