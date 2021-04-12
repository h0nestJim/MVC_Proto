using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AP_Proto.Data;
using AP_Proto.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AP_Proto.Views
{
    public class UpdateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpdateController(ApplicationDbContext context)
        {
            _context = context;
        }



      





        // GET: Update
        public async Task<IActionResult> Index()
        {
            return View(await _context.Updates.ToListAsync());
        }

        // GET: Update/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var updateModel = await _context.Updates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (updateModel == null)
            {
                return NotFound();
            }

            return View(updateModel);
        }

        // GET: Update/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Update/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Updated,UserId,Details")] UpdateModel updateModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(updateModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(updateModel);
        }

        // GET: Update/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var updateModel = await _context.Updates.FindAsync(id);
            if (updateModel == null)
            {
                return NotFound();
            }
            return View(updateModel);
        }

        // POST: Update/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Updated,UserId,Details")] UpdateModel updateModel)
        {
            if (id != updateModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updateModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpdateModelExists(updateModel.Id))
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
            return View(updateModel);
        }

        // GET: Update/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var updateModel = await _context.Updates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (updateModel == null)
            {
                return NotFound();
            }

            return View(updateModel);
        }

        // POST: Update/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var updateModel = await _context.Updates.FindAsync(id);
            _context.Updates.Remove(updateModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpdateModelExists(int id)
        {
            return _context.Updates.Any(e => e.Id == id);
        }
    }
}
