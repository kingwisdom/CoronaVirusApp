using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid19Tracker.Data.DataContext;
using Covid19Tracker.Entities.Tracker;

namespace Covid19Tracker.Web.Controllers
{
    public class CovidCasesController : Controller
    {
        private readonly Covid19TrackerDBContext _context;

        public CovidCasesController(Covid19TrackerDBContext context)
        {
            _context = context;
        }

        // GET: CovidCases
        public async Task<IActionResult> Index()
        {
            return View(await _context.Covid19Trackers.ToListAsync());
        }

        // GET: CovidCases/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidCase = await _context.Covid19Trackers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (covidCase == null)
            {
                return NotFound();
            }

            return View(covidCase);
        }

        // GET: CovidCases/Create
        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        
        // POST: CovidCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Age,Gender,Nationality,CaseStatus,State,DateofRecorvery,DateOfDeath")] CovidCase covidCase)
        {
            if (ModelState.IsValid)
            {
                covidCase.ID = Guid.NewGuid();
                _context.Add(covidCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(covidCase);
        }

        // GET: CovidCases/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidCase = await _context.Covid19Trackers.FindAsync(id);
            if (covidCase == null)
            {
                return NotFound();
            }
            return View(covidCase);
        }

        // POST: CovidCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Age,Gender,Nationality,CaseStatus,State,DateofRecorvery,DateOfDeath")] CovidCase covidCase)
        {
            if (id != covidCase.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(covidCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CovidCaseExists(covidCase.ID))
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
            return View(covidCase);
        }

        // GET: CovidCases/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidCase = await _context.Covid19Trackers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (covidCase == null)
            {
                return NotFound();
            }

            return View(covidCase);
        }

        // POST: CovidCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var covidCase = await _context.Covid19Trackers.FindAsync(id);
            _context.Covid19Trackers.Remove(covidCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CovidCaseExists(Guid id)
        {
            return _context.Covid19Trackers.Any(e => e.ID == id);
        }
    }
}
