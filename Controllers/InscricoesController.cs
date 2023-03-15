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
    public class InscricoesController : Controller
    {
        private readonly ProjectDBContext _context;

        public InscricoesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: Inscricaos
        public async Task<IActionResult> Index()
        {
            var gestaoinscricoesLaravelContext = _context.Inscricoes.Include(i => i.Formacao).Include(i => i.Formando).Include(i => i.IdEstadoNavigation);
            return View(await gestaoinscricoesLaravelContext.ToListAsync());
        }

        // GET: Inscricaos/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null || _context.Inscricoes == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .Include(i => i.Formacao)
                .Include(i => i.Formando)
                .Include(i => i.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // GET: Inscricaos/Create
        public IActionResult Create()
        {
            ViewData["FormacaoId"] = new SelectList(_context.Formacoes, "Id", "Id");
            ViewData["FormandoId"] = new SelectList(_context.Formandos, "Id", "Id");
            ViewData["IdEstado"] = new SelectList(_context.EstadosInscricao, "Id", "Id");
            return View();
        }

        // POST: Inscricaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FormandoId,FormacaoId,DataInscricao,Preferencia,IdEstado,CreatedAt,UpdatedAt")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormacaoId"] = new SelectList(_context.Formacoes, "Id", "Id", inscricao.FormacaoId);
            ViewData["FormandoId"] = new SelectList(_context.Formandos, "Id", "Id", inscricao.FormandoId);
            ViewData["IdEstado"] = new SelectList(_context.EstadosInscricao, "Id", "Id", inscricao.IdEstado);
            return View(inscricao);
        }

        // GET: Inscricaos/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null || _context.Inscricoes == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            ViewData["FormacaoId"] = new SelectList(_context.Formacoes, "Id", "Id", inscricao.FormacaoId);
            ViewData["FormandoId"] = new SelectList(_context.Formandos, "Id", "Id", inscricao.FormandoId);
            ViewData["IdEstado"] = new SelectList(_context.EstadosInscricao, "Id", "Id", inscricao.IdEstado);
            return View(inscricao);
        }

        // POST: Inscricaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,FormandoId,FormacaoId,DataInscricao,Preferencia,IdEstado,CreatedAt,UpdatedAt")] Inscricao inscricao)
        {
            if (id != inscricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricaoExists(inscricao.Id))
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
            ViewData["FormacaoId"] = new SelectList(_context.Formacoes, "Id", "Id", inscricao.FormacaoId);
            ViewData["FormandoId"] = new SelectList(_context.Formandos, "Id", "Id", inscricao.FormandoId);
            ViewData["IdEstado"] = new SelectList(_context.EstadosInscricao, "Id", "Id", inscricao.IdEstado);
            return View(inscricao);
        }

        // GET: Inscricaos/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null || _context.Inscricoes == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .Include(i => i.Formacao)
                .Include(i => i.Formando)
                .Include(i => i.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            if (_context.Inscricoes == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.Inscricoes'  is null.");
            }
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricaoExists(ulong id)
        {
          return (_context.Inscricoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
