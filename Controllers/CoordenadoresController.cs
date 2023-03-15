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
    public class CoordenadoresController : Controller
    {
        private readonly ProjectDBContext _context;

        public CoordenadoresController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: Coordenadores
        public async Task<IActionResult> Index()
        {
              return _context.Coordenadores != null ? 
                          View(await _context.Coordenadores.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.Coordenadores'  is null.");
        }

        // GET: Coordenadores/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null || _context.Coordenadores == null)
            {
                return NotFound();
            }

            var coordenador = await _context.Coordenadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordenador == null)
            {
                return NotFound();
            }

            return View(coordenador);
        }

        // GET: Coordenadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coordenadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone,AvatarPath")] Coordenador coordenador)
        {
            coordenador.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(coordenador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coordenador);
        }

        // GET: Coordenadores/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null || _context.Coordenadores == null)
            {
                return NotFound();
            }

            var coordenador = await _context.Coordenadores.FindAsync(id);
            if (coordenador == null)
            {
                return NotFound();
            }
            return View(coordenador);
        }

        // POST: Coordenadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Nome,Email,Telefone,AvatarPath,CreatedAt,UpdatedAt")] Coordenador coordenador)
        {
            if (id != coordenador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    coordenador.UpdatedAt = DateTime.Now;
                    _context.Update(coordenador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoordenadorExists(coordenador.Id))
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
            return View(coordenador);
        }

        // GET: Coordenadores/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null || _context.Coordenadores == null)
            {
                return NotFound();
            }

            var coordenador = await _context.Coordenadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coordenador == null)
            {
                return NotFound();
            }

            return View(coordenador);
        }

        // POST: Coordenadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            if (_context.Coordenadores == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.Coordenadores'  is null.");
            }
            var coordenador = await _context.Coordenadores.FindAsync(id);
            if (coordenador != null)
            {
                _context.Coordenadores.Remove(coordenador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoordenadorExists(ulong id)
        {
          return (_context.Coordenadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
