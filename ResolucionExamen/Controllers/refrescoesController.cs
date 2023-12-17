using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResolucionExamen.Context;
using ResolucionExamen.Models;

namespace ResolucionExamen.Controllers
{
    public class refrescoesController : Controller
    {
        private readonly MiContext _context;

        public refrescoesController(MiContext context)
        {
            _context = context;
        }

        // GET: refrescoes
        public async Task<IActionResult> Index()
        {
              return _context.refrescos != null ? 
                          View(await _context.refrescos.ToListAsync()) :
                          Problem("Entity set 'MiContext.refrescos'  is null.");
        }

        // GET: refrescoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.refrescos == null)
            {
                return NotFound();
            }

            var refresco = await _context.refrescos
                .FirstOrDefaultAsync(m => m.idRefresco == id);
            if (refresco == null)
            {
                return NotFound();
            }

            return View(refresco);
        }

        // GET: refrescoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: refrescoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRefresco,Marca,Producto,Cantidad,FechaDeRegistro,Precio,Disponibilidad")] refresco refresco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refresco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refresco);
        }

        // GET: refrescoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.refrescos == null)
            {
                return NotFound();
            }

            var refresco = await _context.refrescos.FindAsync(id);
            if (refresco == null)
            {
                return NotFound();
            }
            return View(refresco);
        }

        // POST: refrescoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idRefresco,Marca,Producto,Cantidad,FechaDeRegistro,Precio,Disponibilidad")] refresco refresco)
        {
            if (id != refresco.idRefresco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refresco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!refrescoExists(refresco.idRefresco))
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
            return View(refresco);
        }

        // GET: refrescoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.refrescos == null)
            {
                return NotFound();
            }

            var refresco = await _context.refrescos
                .FirstOrDefaultAsync(m => m.idRefresco == id);
            if (refresco == null)
            {
                return NotFound();
            }

            return View(refresco);
        }

        // POST: refrescoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.refrescos == null)
            {
                return Problem("Entity set 'MiContext.refrescos'  is null.");
            }
            var refresco = await _context.refrescos.FindAsync(id);
            if (refresco != null)
            {
                _context.refrescos.Remove(refresco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool refrescoExists(int id)
        {
          return (_context.refrescos?.Any(e => e.idRefresco == id)).GetValueOrDefault();
        }
    }
}
