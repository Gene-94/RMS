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
    public class FormacoesController : Controller
    {
        private readonly ProjectDBContext _context;

        public FormacoesController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: Formacoes
        public async Task<IActionResult> Index()
        {
            var gestaoinscricoesLaravelContext = _context.Formacoes.Include(f => f.Coordenador).Include(f => f.RegimeHorario).Include(f => f.RegimePresenca);
            return View(await gestaoinscricoesLaravelContext.ToListAsync());
        }

        // GET: Formacoes/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null || _context.Formacoes == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacoes
                .Include(f => f.Coordenador)
                .Include(f => f.RegimeHorario)
                .Include(f => f.RegimePresenca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // GET: Formacoes/Create
        public IActionResult Create()
        {
            ViewData["CoordenadorId"] = new SelectList(_context.Coordenadores, "Id", "Id");
            ViewData["RegimeHorarioId"] = new SelectList(_context.RegimesHorarios, "Id", "Id");
            ViewData["RegimePresencaId"] = new SelectList(_context.RegimesPresencas, "Id", "Id");
            return View();
        }

        // POST: Formacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,RegimePresencaId,RegimeHorarioId,DuracaoHoras,DataInicioPrevista,CoordenadorId,CreatedAt,UpdatedAt")] Formacao formacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoordenadorId"] = new SelectList(_context.Coordenadores, "Id", "Id", formacao.CoordenadorId);
            ViewData["RegimeHorarioId"] = new SelectList(_context.RegimesHorarios, "Id", "Id", formacao.RegimeHorarioId);
            ViewData["RegimePresencaId"] = new SelectList(_context.RegimesPresencas, "Id", "Id", formacao.RegimePresencaId);
            return View(formacao);
        }

        // GET: Formacoes/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null || _context.Formacoes == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacoes.FindAsync(id);
            if (formacao == null)
            {
                return NotFound();
            }
            ViewData["CoordenadorId"] = new SelectList(_context.Coordenadores, "Id", "Id", formacao.CoordenadorId);
            ViewData["RegimeHorarioId"] = new SelectList(_context.RegimesHorarios, "Id", "Id", formacao.RegimeHorarioId);
            ViewData["RegimePresencaId"] = new SelectList(_context.RegimesPresencas, "Id", "Id", formacao.RegimePresencaId);
            return View(formacao);
        }

        // POST: Formacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Nome,Descricao,RegimePresencaId,RegimeHorarioId,DuracaoHoras,DataInicioPrevista,CoordenadorId,CreatedAt,UpdatedAt")] Formacao formacao)
        {
            if (id != formacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacaoExists(formacao.Id))
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
            ViewData["CoordenadorId"] = new SelectList(_context.Coordenadores, "Id", "Id", formacao.CoordenadorId);
            ViewData["RegimeHorarioId"] = new SelectList(_context.RegimesHorarios, "Id", "Id", formacao.RegimeHorarioId);
            ViewData["RegimePresencaId"] = new SelectList(_context.RegimesPresencas, "Id", "Id", formacao.RegimePresencaId);
            return View(formacao);
        }

        // GET: Formacoes/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null || _context.Formacoes == null)
            {
                return NotFound();
            }

            var formacao = await _context.Formacoes
                .Include(f => f.Coordenador)
                .Include(f => f.RegimeHorario)
                .Include(f => f.RegimePresenca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // POST: Formacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            if (_context.Formacoes == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.Formacoes'  is null.");
            }
            var formacao = await _context.Formacoes.FindAsync(id);
            if (formacao != null)
            {
                _context.Formacoes.Remove(formacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacaoExists(ulong id)
        {
          return (_context.Formacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
