using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisalrilProject.Models;

namespace SisalrilProject.Controllers
{
    public class EdificiosController : Controller
    {
        private readonly SisalrilTaskContext _context;

        public EdificiosController(SisalrilTaskContext context)
        {
            _context = context;
        }

        // GET: Edificios
        public async Task<IActionResult> Index()
        {         
            return View(await _context.Edificios.ToListAsync());
        }

        // GET: Edificios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Edificios == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificios
                .FirstOrDefaultAsync(m => m.IdEdificio == id);
            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);
        }

        // GET: Edificios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Edificios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEdificio,EdificioDireccion,TipoEdificio,NivelCalidad,Categoria")] Edificio edificio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edificio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edificio);
        }

        // GET: Edificios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Edificios == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificios.FindAsync(id);
            if (edificio == null)
            {
                return NotFound();
            }
            return View(edificio);
        }

        // POST: Edificios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEdificio,EdificioDireccion,TipoEdificio,NivelCalidad,Categoria")] Edificio edificio)
        {
            if (id != edificio.IdEdificio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edificio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdificioExists(edificio.IdEdificio))
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
            return View(edificio);
        }

        // GET: Edificios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Edificios == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificios
                .FirstOrDefaultAsync(m => m.IdEdificio == id);
            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);
        }

        // POST: Edificios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Edificios == null)
            {
                return Problem("Entity set 'SisalrilTaskContext.Edificios'  is null.");
            }
            var edificio = await _context.Edificios.FindAsync(id);
            if (edificio != null)
            {
                _context.Edificios.Remove(edificio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdificioExists(int id)
        {
          return _context.Edificios.Any(e => e.IdEdificio == id);
        }
    }
}
