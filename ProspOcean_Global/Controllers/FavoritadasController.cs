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
    public class FavoritadasController : Controller
    {
        private readonly ProspOceanDbContext _context;

        public FavoritadasController(ProspOceanDbContext context)
        {
            _context = context;
        }

        // GET: Favoritadas
        public async Task<IActionResult> Index()
        {
            var prospOceanDbContext = _context.Favoritadas.Include(f => f.Especie).Include(f => f.Usuario);
            return View(await prospOceanDbContext.ToListAsync());
        }

        // GET: Favoritadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoritadas = await _context.Favoritadas
                .Include(f => f.Especie)
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoritadas == null)
            {
                return NotFound();
            }

            return View(favoritadas);
        }

        // GET: Favoritadas/Create
        public IActionResult Create()
        {
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Descricao");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }

        // POST: Favoritadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,EspecieId")] Favoritadas favoritadas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favoritadas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Descricao", favoritadas.EspecieId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", favoritadas.UsuarioId);
            return View(favoritadas);
        }

        // GET: Favoritadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoritadas = await _context.Favoritadas.FindAsync(id);
            if (favoritadas == null)
            {
                return NotFound();
            }
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Descricao", favoritadas.EspecieId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", favoritadas.UsuarioId);
            return View(favoritadas);
        }

        // POST: Favoritadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,EspecieId")] Favoritadas favoritadas)
        {
            if (id != favoritadas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoritadas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoritadasExists(favoritadas.Id))
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
            ViewData["EspecieId"] = new SelectList(_context.Especies, "Id", "Descricao", favoritadas.EspecieId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", favoritadas.UsuarioId);
            return View(favoritadas);
        }

        // GET: Favoritadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoritadas = await _context.Favoritadas
                .Include(f => f.Especie)
                .Include(f => f.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoritadas == null)
            {
                return NotFound();
            }

            return View(favoritadas);
        }

        // POST: Favoritadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoritadas = await _context.Favoritadas.FindAsync(id);
            if (favoritadas != null)
            {
                _context.Favoritadas.Remove(favoritadas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoritadasExists(int id)
        {
            return _context.Favoritadas.Any(e => e.Id == id);
        }
    }
}
