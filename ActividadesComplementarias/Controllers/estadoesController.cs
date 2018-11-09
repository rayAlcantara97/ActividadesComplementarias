using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadesComplementarias.Models;

namespace ActividadesComplementarias.Controllers
{
    public class estadoesController : Controller
    {
        private readonly ActividadesComplementariasContext _context;

        public estadoesController(ActividadesComplementariasContext context)
        {
            _context = context;
        }

        // GET: estadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.estado.ToListAsync());
        }

        // GET: estadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.estado
                .SingleOrDefaultAsync(m => m.idestado == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // GET: estadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idestado,nombre_estado")] estado estado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        // GET: estadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.estado.SingleOrDefaultAsync(m => m.idestado == id);
            if (estado == null)
            {
                return NotFound();
            }
            return View(estado);
        }

        // POST: estadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idestado,nombre_estado")] estado estado)
        {
            if (id != estado.idestado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estadoExists(estado.idestado))
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
            return View(estado);
        }

        // GET: estadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.estado
                .SingleOrDefaultAsync(m => m.idestado == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        // POST: estadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado = await _context.estado.SingleOrDefaultAsync(m => m.idestado == id);
            _context.estado.Remove(estado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estadoExists(int id)
        {
            return _context.estado.Any(e => e.idestado == id);
        }
    }
}
