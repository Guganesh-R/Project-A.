using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMS1.Models;

namespace TMS1.Controllers
{
    public class VehicleInfoController : Controller
    {
        private readonly TMS1Context _context;

        public VehicleInfoController(TMS1Context context)
        {
            _context = context;
        }

        // GET: VehicleInfo
        public async Task<IActionResult> Index()
        {
              return _context.VehicleInfo != null ? 
                          View(await _context.VehicleInfo.ToListAsync()) :
                          Problem("Entity set 'TMS1Context.VehicleInfo'  is null.");
        }

        // GET: VehicleInfo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VehicleInfo == null)
            {
                return NotFound();
            }

            var vehicleInfo = await _context.VehicleInfo
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleInfo == null)
            {
                return NotFound();
            }

            return View(vehicleInfo);
        }

        // GET: VehicleInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,VehicleCapacity,SeatAvailablity")] VehicleInfo vehicleInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleInfo);
        }

        // GET: VehicleInfo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VehicleInfo == null)
            {
                return NotFound();
            }

            var vehicleInfo = await _context.VehicleInfo.FindAsync(id);
            if (vehicleInfo == null)
            {
                return NotFound();
            }
            return View(vehicleInfo);
        }

        // POST: VehicleInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VehicleId,VehicleCapacity,SeatAvailablity")] VehicleInfo vehicleInfo)
        {
            if (id != vehicleInfo.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleInfoExists(vehicleInfo.VehicleId))
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
            return View(vehicleInfo);
        }

        // GET: VehicleInfo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VehicleInfo == null)
            {
                return NotFound();
            }

            var vehicleInfo = await _context.VehicleInfo
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleInfo == null)
            {
                return NotFound();
            }

            return View(vehicleInfo);
        }

        // POST: VehicleInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VehicleInfo == null)
            {
                return Problem("Entity set 'TMS1Context.VehicleInfo'  is null.");
            }
            var vehicleInfo = await _context.VehicleInfo.FindAsync(id);
            if (vehicleInfo != null)
            {
                _context.VehicleInfo.Remove(vehicleInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleInfoExists(string id)
        {
          return (_context.VehicleInfo?.Any(e => e.VehicleId == id)).GetValueOrDefault();
        }
    }
}
