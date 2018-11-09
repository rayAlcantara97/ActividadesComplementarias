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
    public class grupoesController : Controller
    {
        private readonly ActividadesComplementariasContext _context;

        public grupoesController(ActividadesComplementariasContext context)
        {
            _context = context;
        }

        // GET: grupoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.grupo.ToListAsync());
        }

        // GET: grupoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.grupo
                .SingleOrDefaultAsync(m => m.idgrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: grupoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: grupoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idgrupo,nombre_grupo,capacidad,hora_inicial,hora_final,instructor_idinstructor,area_idarea,actividad_idactividad,periodo_idperiodo")] grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupo);
        }

        // GET: grupoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.grupo.SingleOrDefaultAsync(m => m.idgrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }
            return View(grupo);
        }

        // POST: grupoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idgrupo,nombre_grupo,capacidad,hora_inicial,hora_final,instructor_idinstructor,area_idarea,actividad_idactividad,periodo_idperiodo")] grupo grupo)
        {
            if (id != grupo.idgrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!grupoExists(grupo.idgrupo))
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
            return View(grupo);
        }

        // GET: grupoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupo = await _context.grupo
                .SingleOrDefaultAsync(m => m.idgrupo == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: grupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupo = await _context.grupo.SingleOrDefaultAsync(m => m.idgrupo == id);
            _context.grupo.Remove(grupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool grupoExists(int id)
        {
            return _context.grupo.Any(e => e.idgrupo == id);
        }
    }
}
