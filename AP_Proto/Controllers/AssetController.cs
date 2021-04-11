using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AP_Proto.Data;
using AP_Proto.Models;

namespace AP_Proto.Views
{
    public class AssetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asset
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asset.ToListAsync());
        }

        // GET: Asset/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetModel = await _context.Asset
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetModel == null)
            {
                return NotFound();
            }

            return View(assetModel);
        }

        // GET: Asset/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asset/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,assetType,Note")] AssetModel assetModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetModel);
        }

        // GET: Asset/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetModel = await _context.Asset.FindAsync(id);
            if (assetModel == null)
            {
                return NotFound();
            }
            return View(assetModel);
        }

        // POST: Asset/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,assetType,Note")] AssetModel assetModel)
        {
            if (id != assetModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetModelExists(assetModel.Id))
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
            return View(assetModel);
        }

        // GET: Asset/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetModel = await _context.Asset
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetModel == null)
            {
                return NotFound();
            }

            return View(assetModel);
        }

        // POST: Asset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetModel = await _context.Asset.FindAsync(id);
            _context.Asset.Remove(assetModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetModelExists(int id)
        {
            return _context.Asset.Any(e => e.Id == id);
        }
    }
}
