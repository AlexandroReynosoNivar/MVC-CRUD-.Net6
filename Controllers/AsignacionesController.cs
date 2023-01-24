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
    public class AsignacionesController : Controller
    {
        private readonly SisalrilTaskContext _context;

        public AsignacionesController(SisalrilTaskContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index()
        {
            var sisalrilTaskContext = _context.Asignaciones.Include(a => a.IdEdificioNavigation).Include(a => a.IdTrabajadorNavigation);
            return View(await sisalrilTaskContext.ToListAsync());
        }

        // GET: Asignaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacione = await _context.Asignaciones
                .Include(a => a.IdEdificioNavigation)
                .Include(a => a.IdTrabajadorNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacione == null)
            {
                return NotFound();
            }

            return View(asignacione);
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            ViewData["IdEdificio"] = new SelectList(_context.Edificios, "IdEdificio", "IdEdificio");
            ViewData["IdTrabajador"] = new SelectList(_context.Trabajadores, "IdTrabajador", "IdTrabajador");
            return View();
        }

        // POST: Asignaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacion,IdEdificio,IdTrabajador,AsignacionFechaInicio,AsignacionNoDias")] Asignacione asignacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEdificio"] = new SelectList(_context.Edificios, "IdEdificio", "IdEdificio", asignacione.IdEdificio);
            ViewData["IdTrabajador"] = new SelectList(_context.Trabajadores, "IdTrabajador", "IdTrabajador", asignacione.IdTrabajador);
            return View(asignacione);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacione = await _context.Asignaciones.FindAsync(id);
            if (asignacione == null)
            {
                return NotFound();
            }
            ViewData["IdEdificio"] = new SelectList(_context.Edificios, "IdEdificio", "IdEdificio", asignacione.IdEdificio);
            ViewData["IdTrabajador"] = new SelectList(_context.Trabajadores, "IdTrabajador", "IdTrabajador", asignacione.IdTrabajador);
            return View(asignacione);
        }

        // POST: Asignaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,IdEdificio,IdTrabajador,AsignacionFechaInicio,AsignacionNoDias")] Asignacione asignacione)
        {
            if (id != asignacione.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacioneExists(asignacione.IdAsignacion))
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
            ViewData["IdEdificio"] = new SelectList(_context.Edificios, "IdEdificio", "IdEdificio", asignacione.IdEdificio);
            ViewData["IdTrabajador"] = new SelectList(_context.Trabajadores, "IdTrabajador", "IdTrabajador", asignacione.IdTrabajador);
            return View(asignacione);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asignaciones == null)
            {
                return NotFound();
            }

            var asignacione = await _context.Asignaciones
                .Include(a => a.IdEdificioNavigation)
                .Include(a => a.IdTrabajadorNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacione == null)
            {
                return NotFound();
            }

            return View(asignacione);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asignaciones == null)
            {
                return Problem("Entity set 'SisalrilTaskContext.Asignaciones'  is null.");
            }
            var asignacione = await _context.Asignaciones.FindAsync(id);
            if (asignacione != null)
            {
                _context.Asignaciones.Remove(asignacione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacioneExists(int id)
        {
          return _context.Asignaciones.Any(e => e.IdAsignacion == id);
        }
    }
}
