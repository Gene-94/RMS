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
    public class FormandosController : Controller
    {
        private readonly ProjectDBContext _context;

        public FormandosController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: Formandos
        public async Task<IActionResult> Index()
        {
            var gestaoinscricoesLaravelContext = _context.Formandos.Include(f => f.Concelho).Include(f => f.Empresa).Include(f => f.EstadoCivil).Include(f => f.Habilitacoes).Include(f => f.Nacionalidade).Include(f => f.Naturalidade).Include(f => f.Subsidio).Include(f => f.TipoDocumento);
            return View(await gestaoinscricoesLaravelContext.ToListAsync());
        }

        // GET: Formandos/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null || _context.Formandos == null)
            {
                return NotFound();
            }

            var formando = await _context.Formandos
                .Include(f => f.Concelho)
                .Include(f => f.Empresa)
                .Include(f => f.EstadoCivil)
                .Include(f => f.Habilitacoes)
                .Include(f => f.Nacionalidade)
                .Include(f => f.Naturalidade)
                .Include(f => f.Subsidio)
                .Include(f => f.TipoDocumento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formando == null)
            {
                return NotFound();
            }

            return View(formando);
        }

        // GET: Formandos/Create
        public IActionResult Create()
        {
            ViewData["ConcelhoId"] = new SelectList(_context.Concelhos, "Id", "Id");
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Id");
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadosCivis, "Id", "Id");
            ViewData["HabilitacoesId"] = new SelectList(_context.Habilitacoes, "Id", "Id");
            ViewData["NacionalidadeId"] = new SelectList(_context.Paises, "Id", "Id");
            ViewData["NaturalidadeId"] = new SelectList(_context.Paises, "Id", "Id");
            ViewData["SubsidioId"] = new SelectList(_context.Subsidios, "Id", "Id");
            ViewData["TipoDocumentoId"] = new SelectList(_context.TiposDocumentos, "Id", "Id");
            return View();
        }

        // POST: Formandos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telemovel,DataNascimento,TipoDocumentoId,EstadoCivilId,NrDocumento,ValidadeDocumento,Niss,Nif,NacionalidadeId,NaturalidadeId,HabilitacoesId,AreaCurso,AnoConclusao,EstabelecimentoEnino,Certificado,Emprego,SubsidioId,UltimaProff,InicioProff,FimProff,EmpresaId,Morada,ConcelhoId,CodPostal,CreatedAt,UpdatedAt")] Formando formando)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formando);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConcelhoId"] = new SelectList(_context.Concelhos, "Id", "Id", formando.ConcelhoId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Id", formando.EmpresaId);
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadosCivis, "Id", "Id", formando.EstadoCivilId);
            ViewData["HabilitacoesId"] = new SelectList(_context.Habilitacoes, "Id", "Id", formando.HabilitacoesId);
            ViewData["NacionalidadeId"] = new SelectList(_context.Paises, "Id", "Id", formando.NacionalidadeId);
            ViewData["NaturalidadeId"] = new SelectList(_context.Paises, "Id", "Id", formando.NaturalidadeId);
            ViewData["SubsidioId"] = new SelectList(_context.Subsidios, "Id", "Id", formando.SubsidioId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TiposDocumentos, "Id", "Id", formando.TipoDocumentoId);
            return View(formando);
        }

        // GET: Formandos/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null || _context.Formandos == null)
            {
                return NotFound();
            }

            var formando = await _context.Formandos.FindAsync(id);
            if (formando == null)
            {
                return NotFound();
            }
            ViewData["ConcelhoId"] = new SelectList(_context.Concelhos, "Id", "Id", formando.ConcelhoId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Id", formando.EmpresaId);
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadosCivis, "Id", "Id", formando.EstadoCivilId);
            ViewData["HabilitacoesId"] = new SelectList(_context.Habilitacoes, "Id", "Id", formando.HabilitacoesId);
            ViewData["NacionalidadeId"] = new SelectList(_context.Paises, "Id", "Id", formando.NacionalidadeId);
            ViewData["NaturalidadeId"] = new SelectList(_context.Paises, "Id", "Id", formando.NaturalidadeId);
            ViewData["SubsidioId"] = new SelectList(_context.Subsidios, "Id", "Id", formando.SubsidioId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TiposDocumentos, "Id", "Id", formando.TipoDocumentoId);
            return View(formando);
        }

        // POST: Formandos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Nome,Email,Telemovel,DataNascimento,TipoDocumentoId,EstadoCivilId,NrDocumento,ValidadeDocumento,Niss,Nif,NacionalidadeId,NaturalidadeId,HabilitacoesId,AreaCurso,AnoConclusao,EstabelecimentoEnino,Certificado,Emprego,SubsidioId,UltimaProff,InicioProff,FimProff,EmpresaId,Morada,ConcelhoId,CodPostal,CreatedAt,UpdatedAt")] Formando formando)
        {
            if (id != formando.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formando);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormandoExists(formando.Id))
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
            ViewData["ConcelhoId"] = new SelectList(_context.Concelhos, "Id", "Id", formando.ConcelhoId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Id", formando.EmpresaId);
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadosCivis, "Id", "Id", formando.EstadoCivilId);
            ViewData["HabilitacoesId"] = new SelectList(_context.Habilitacoes, "Id", "Id", formando.HabilitacoesId);
            ViewData["NacionalidadeId"] = new SelectList(_context.Paises, "Id", "Id", formando.NacionalidadeId);
            ViewData["NaturalidadeId"] = new SelectList(_context.Paises, "Id", "Id", formando.NaturalidadeId);
            ViewData["SubsidioId"] = new SelectList(_context.Subsidios, "Id", "Id", formando.SubsidioId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TiposDocumentos, "Id", "Id", formando.TipoDocumentoId);
            return View(formando);
        }

        // GET: Formandos/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null || _context.Formandos == null)
            {
                return NotFound();
            }

            var formando = await _context.Formandos
                .Include(f => f.Concelho)
                .Include(f => f.Empresa)
                .Include(f => f.EstadoCivil)
                .Include(f => f.Habilitacoes)
                .Include(f => f.Nacionalidade)
                .Include(f => f.Naturalidade)
                .Include(f => f.Subsidio)
                .Include(f => f.TipoDocumento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formando == null)
            {
                return NotFound();
            }

            return View(formando);
        }

        // POST: Formandos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            if (_context.Formandos == null)
            {
                return Problem("Entity set 'GestaoinscricoesLaravelContext.Formandos'  is null.");
            }
            var formando = await _context.Formandos.FindAsync(id);
            if (formando != null)
            {
                _context.Formandos.Remove(formando);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormandoExists(ulong id)
        {
          return (_context.Formandos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
