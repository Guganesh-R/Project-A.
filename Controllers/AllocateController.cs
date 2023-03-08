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
    public class AllocateController : Controller
    {
        private readonly TMS1Context _context;

        public AllocateController(TMS1Context context)
        {
            _context = context;
        }

        // GET: Allocate
        public async Task<IActionResult> Index()
        {
            var tMS1Context = _context.Allocate.Include(a => a.EmployeeInfo).Include(a => a.RouteInfo).Include(a => a.VehicleInfo);
            return View(await tMS1Context.ToListAsync());
        }

        // GET: Allocate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Allocate == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocate
                .Include(a => a.EmployeeInfo)
                .Include(a => a.RouteInfo)
                .Include(a => a.VehicleInfo)
                .FirstOrDefaultAsync(m => m.AllocatId == id);
            if (allocate == null)
            {
                return NotFound();
            }

            return View(allocate);
        }

        // GET: Allocate/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeInfo, "EmployeeID", "EmployeeID");
            ViewData["RouteId"] = new SelectList(_context.RouteInfo, "RouteId", "RouteId");
            ViewData["VehicleId"] = new SelectList(_context.VehicleInfo, "VehicleId", "VehicleId");
            return View();
        }

        // POST: Allocate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocatId,VehicleId,RouteId,EmployeeId")] Allocate allocate)
        {
            var a = allocate.VehicleId;
            if (ModelState.IsValid)
            {
                _context.Add(allocate);
                await _context.SaveChangesAsync();
                await SeatUpdation(a);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeInfo, "EmployeeID", "EmployeeID", allocate.EmployeeId);
            ViewData["RouteId"] = new SelectList(_context.RouteInfo, "RouteId", "RouteId", allocate.RouteId);
            ViewData["VehicleId"] = new SelectList(_context.VehicleInfo, "VehicleId", "VehicleId", allocate.VehicleId);
            return View(allocate);
        }

        // GET: Allocate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Allocate == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocate.FindAsync(id);
            if (allocate == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeInfo, "EmployeeID", "EmployeeID", allocate.EmployeeId);
            ViewData["RouteId"] = new SelectList(_context.RouteInfo, "RouteId", "RouteId", allocate.RouteId);
            ViewData["VehicleId"] = new SelectList(_context.VehicleInfo, "VehicleId", "VehicleId", allocate.VehicleId);
            return View(allocate);
        }

        // POST: Allocate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocatId,VehicleId,RouteId,EmployeeId")] Allocate allocate)
        {
            if (id != allocate.AllocatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocateExists(allocate.AllocatId))
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
            ViewData["EmployeeId"] = new SelectList(_context.EmployeeInfo, "EmployeeID", "EmployeeID", allocate.EmployeeId);
            ViewData["RouteId"] = new SelectList(_context.RouteInfo, "RouteId", "RouteId", allocate.RouteId);
            ViewData["VehicleId"] = new SelectList(_context.VehicleInfo, "VehicleId", "VehicleId", allocate.VehicleId);
            return View(allocate);
        }

        // GET: Allocate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Allocate == null)
            {
                return NotFound();
            }

            var allocate = await _context.Allocate
                .Include(a => a.EmployeeInfo)
                .Include(a => a.RouteInfo)
                .Include(a => a.VehicleInfo)
                .FirstOrDefaultAsync(m => m.AllocatId == id);
            if (allocate == null)
            {
                return NotFound();
            }

            return View(allocate);
        }

        // POST: Allocate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Allocate == null)
            {
                return Problem("Entity set 'TMS1Context.Allocate'  is null.");
            }
            var allocate = await _context.Allocate.FindAsync(id);
            if (allocate != null)
            {
                _context.Allocate.Remove(allocate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocateExists(int id)
        {
          return (_context.Allocate?.Any(e => e.AllocatId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> SeatUpdation(string a)
        {
            var allocate = _context.Allocate;
            using (var dbconnect = _context)
            {

                VehicleInfo? l = dbconnect.VehicleInfo.Find(a);
                int b = l.SeatAvailablity;
                l.SeatAvailablity = b - 1;
                dbconnect.SaveChangesAsync();
                return View(allocate);
            }
        }
    }
}
