using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFinalProject.Data;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class ComputersController : Controller
    {
        private readonly MVCFinalProjectContext _context;

        public ComputersController(MVCFinalProjectContext context)
        {
            _context = context;
        }

        // GET: Computers
        public async Task<IActionResult> Index(int? sn, decimal? pf, decimal? pt, DateTime df, DateTime dt, string rn)
        {
            var computers = from c in _context.Computer 
                            select c;
            if (sn != null)
            {
                computers = computers.Where(c => c.ManufactererSerialNumber == sn);
            }
            if (!String.IsNullOrEmpty(rn))
            {
                computers = computers.Where(c => c.OfficeRoomNumber.ToLower().Equals(rn.ToLower()));
            }
            if (pf != null)
            {
                computers = computers.Where(c => c.Price >= pf);
            }
            if (pt != null)
            {
                computers = computers.Where(c => c.ManufactererSerialNumber <= pt);
            }
            if (!df.Equals(DateTime.MinValue))
            {
                computers = computers.Where(c => c.InstallationDate >= df);
            }
            if (!dt.Equals(DateTime.MinValue))
            {
                computers = computers.Where(c => c.InstallationDate <= dt);
            }

            return View(await computers.ToListAsync());
        }

        // GET: Computers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Computer == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // GET: Computers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManufactererSerialNumber,OfficeRoomNumber,OfficeLocation,ComputerSpecification,OperatingSystem,OwnerName,InstallationDate,Price")] Computer computer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        // GET: Computers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Computer == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ManufactererSerialNumber,OfficeRoomNumber,OfficeLocation,ComputerSpecification,OperatingSystem,OwnerName,InstallationDate,Price")] Computer computer)
        {
            if (id != computer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerExists(computer.Id))
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
            return View(computer);
        }

        // GET: Computers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Computer == null)
            {
                return NotFound();
            }

            var computer = await _context.Computer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Computer == null)
            {
                return Problem("Entity set 'MVCFinalProjectContext.Computer'  is null.");
            }
            var computer = await _context.Computer.FindAsync(id);
            if (computer != null)
            {
                _context.Computer.Remove(computer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerExists(int id)
        {
          return _context.Computer.Any(e => e.Id == id);
        }
    }
}
