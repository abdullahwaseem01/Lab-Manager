using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OntarioTechUniversity.Data;
using OntarioTechUniversity.Models;

namespace OntarioTechUniversity.Controllers
{
    public class SafetyDataSheetsController : Controller
    {
        private readonly SchoolContext _context;

        public SafetyDataSheetsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: SafetyDataSheets
        // adding the search function
        public async Task<IActionResult> Index(string searchString)
        {
            var safetyDataSheets = from i in _context.SafetyDataSheets
                                   select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                safetyDataSheets = safetyDataSheets.Where(x => x.Name.Contains(searchString));
            }

            return View(await safetyDataSheets.ToListAsync());
            
        }

        // GET: SafetyDataSheets/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyDataSheet = await _context.SafetyDataSheets
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.Name == id);
            if (safetyDataSheet == null)
            {
                return NotFound();
            }

            return View(safetyDataSheet);
        }

        // GET: SafetyDataSheets/Create
        public IActionResult Create()
        {
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID");
            return View();
        }

        // POST: SafetyDataSheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Model,Manufacturer,DateOfIssue,RevisionDate,LocationID,Status,Url")] SafetyDataSheet safetyDataSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(safetyDataSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", safetyDataSheet.LocationID);
            return View(safetyDataSheet);
        }

        // GET: SafetyDataSheets/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyDataSheet = await _context.SafetyDataSheets.FindAsync(id);
            if (safetyDataSheet == null)
            {
                return NotFound();
            }
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", safetyDataSheet.LocationID);
            return View(safetyDataSheet);
        }

        // POST: SafetyDataSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Model,Manufacturer,DateOfIssue,RevisionDate,LocationID,Status,Url")] SafetyDataSheet safetyDataSheet)
        {
            if (id != safetyDataSheet.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(safetyDataSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SafetyDataSheetExists(safetyDataSheet.Name))
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
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", safetyDataSheet.LocationID);
            return View(safetyDataSheet);
        }

        // GET: SafetyDataSheets/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyDataSheet = await _context.SafetyDataSheets
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.Name == id);
            if (safetyDataSheet == null)
            {
                return NotFound();
            }

            return View(safetyDataSheet);
        }

        // POST: SafetyDataSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var safetyDataSheet = await _context.SafetyDataSheets.FindAsync(id);
            _context.SafetyDataSheets.Remove(safetyDataSheet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SafetyDataSheetExists(string id)
        {
            return _context.SafetyDataSheets.Any(e => e.Name == id);
        }

        //Also adding the HttpPost method since it was not there before

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}
