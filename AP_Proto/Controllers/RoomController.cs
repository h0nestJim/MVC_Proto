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
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            return View(await _context.Room.ToListAsync());
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomModel = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomNumber == id);
            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNumber,campus,Description")] RoomModel roomModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomModel);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomModel = await _context.Room.FindAsync(id);
            if (roomModel == null)
            {
                return NotFound();
            }
            return View(roomModel);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RoomNumber,campus,Description")] RoomModel roomModel)
        {
            if (id != roomModel.RoomNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomModelExists(roomModel.RoomNumber))
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
            return View(roomModel);
        }

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomModel = await _context.Room
                .FirstOrDefaultAsync(m => m.RoomNumber == id);
            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roomModel = await _context.Room.FindAsync(id);
            _context.Room.Remove(roomModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomModelExists(string id)
        {
            return _context.Room.Any(e => e.RoomNumber == id);
        }
    }
}
