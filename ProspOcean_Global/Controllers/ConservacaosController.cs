using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProspOcean_Global.Models;
using ProspOcean_Global.Persistencia;

namespace ProspOcean_Global.Controllers
{
    public class ConservacaosController : Controller
    {
        private readonly ProspOceanDbContext _context;

        public ConservacaosController(ProspOceanDbContext context)
        {
            _context = context;
        }

        // GET: Conservacaos
        public async Task<IActionResult> Index()
        {
            var prospOceanDbContext = _context.Conservacoes.Include(c => c.Especie);
            return View(await prospOceanDbContext.ToListAsync());
        }

        // GET: Conservacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conservacao = await _context.Conservacoes
                .Include(c => c.Especie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conservacao == null)
            {
                return NotFound();
            }

            return View(conservacao);
        }

        // GET: Conservacaos/Create
        public IActionResult Create()
        {
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Descricao");
            return View();
        }

        // POST: Conservacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,DataInicio,Contato,EspecieId")] Conservacao conservacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conservacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Descricao", conservacao.EspecieId);
            return View(conservacao);
        }

        // GET: Conservacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conservacao = await _context.Conservacoes.FindAsync(id);
            if (conservacao == null)
            {
                return NotFound();
            }
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Descricao", conservacao.EspecieId);
            return View(conservacao);
        }

        // POST: Conservacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,DataInicio,Contato,EspecieId")] Conservacao conservacao)
        {
            if (id != conservacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conservacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConservacaoExists(conservacao.Id))
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
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Descricao", conservacao.EspecieId);
            return View(conservacao);
        }

        // GET: Conservacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conservacao = await _context.Conservacoes
                .Include(c => c.Especie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conservacao == null)
            {
                return NotFound();
            }

            return View(conservacao);
        }

        // POST: Conservacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conservacao = await _context.Conservacoes.FindAsync(id);
            if (conservacao != null)
            {
                _context.Conservacoes.Remove(conservacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConservacaoExists(int id)
        {
            return _context.Conservacoes.Any(e => e.Id == id);
        }
    }
}
