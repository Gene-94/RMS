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
    public class EstadosInscricaoController : Controller
    {
        private readonly ProjectDBContext _context;

        public EstadosInscricaoController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: EstadosInscricao
        public async Task<IActionResult> Index()
        {
              return _context.EstadosInscricao != null ? 
                          View(await _context.EstadosInscricao.ToListAsync()) :
                          Problem("Entity set 'GestaoinscricoesLaravelContext.EstadosInscricao'  is null.");
        }

        // GET: EstadosInscricao/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.EstadosInscricao == null)
            {
                return NotFound();
            }

            var estadoInscricao = await _context.EstadosInscricao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoInscricao == null)
            {
                return NotFound();
            }

            return View(estadoInscricao);
        }

        // GET: EstadosInscricao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosInscricao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEstado,CreatedAt,UpdatedAt")] EstadoInscricao estadoInscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoInscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoInscricao);
        }

        // GET: EstadosInscricao/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.EstadosInscricao == null)
            {
                return NotFound();
            }

            var estadoInscricao = await _context.EstadosInscricao.FindAsync(id);
            if (estadoInscricao == null)
            {
                return NotFound();
            }
            return View(estadoInscricao);
        }

        // POST: EstadosInscricao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,NomeEstado,CreatedAt,UpdatedAt")] EstadoInscricao estadoInscricao)
        {
            if (id != estadoInscricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoInscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoInscricaoExists(estadoInscricao.Id))
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
            return View(estadoInscricao);
        }

        // GET: EstadosInscricao/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.EstadosInscricao == null)
            {
                return NotFound();
            }

            var estadoInscricao = await _context.EstadosInscricao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoInscricao == null)
            {
                return NotFound();
            }

            return View(estadoInscricao);
        }

        // POST: EstadosInscricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.EstadosInscricao == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.EstadosInscricao'  is null.");
            }
            var estadoInscricao = await _context.EstadosInscricao.FindAsync(id);
            if (estadoInscricao != null)
            {
                _context.EstadosInscricao.Remove(estadoInscricao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoInscricaoExists(byte id)
        {
          return (_context.EstadosInscricao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
