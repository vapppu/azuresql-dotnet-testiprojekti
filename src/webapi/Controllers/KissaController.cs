using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    public class KissaController : Controller
    {
        private readonly VeeratestidbContext _context;

        public KissaController(VeeratestidbContext context)
        {
            _context = context;
        }

        // GET: Kissa
        public IEnumerable<Kissat> Index()
        {
            // return View(await _context.Kissats.ToListAsync());
            return _context.Kissats.ToArray();

        }

        // GET: Kissa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kissat = await _context.Kissats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kissat == null)
            {
                return NotFound();
            }

            return View(kissat);
        }

        // GET: Kissa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kissa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Color")] Kissat kissat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kissat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kissat);
        }

        // GET: Kissa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kissat = await _context.Kissats.FindAsync(id);
            if (kissat == null)
            {
                return NotFound();
            }
            return View(kissat);
        }

        // POST: Kissa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Color")] Kissat kissat)
        {
            if (id != kissat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kissat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KissatExists(kissat.Id))
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
            return View(kissat);
        }

        // GET: Kissa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kissat = await _context.Kissats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kissat == null)
            {
                return NotFound();
            }

            return View(kissat);
        }

        // POST: Kissa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kissat = await _context.Kissats.FindAsync(id);
            if (kissat != null)
            {
                _context.Kissats.Remove(kissat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KissatExists(int id)
        {
            return _context.Kissats.Any(e => e.Id == id);
        }
    }
}
