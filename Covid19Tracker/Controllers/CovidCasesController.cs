using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Covid19Tracker.Data.DataContext;
using Covid19Tracker.Entities.Tracker;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        // GET: CovidCases/GetByAge
        [HttpGet] 
        public IActionResult GetByAge()
        {
            return View();
        }

        // POST: CovidCases/GetByAge
        [HttpGet]
        public IActionResult GetAllByAge(string age)
        {
            if (age == null)
            {
                return NotFound();
            }
            string[] agg = age.Split(',');

            int fn = int.Parse(agg[0]);
            int sn = int.Parse(agg[1]);

            var get = _context.Covid19Trackers.Where(e =>e.Age>= fn && e.Age <= sn).ToList();
           // var covidCase = await _context.Covid19Trackers.AllAsync(e=>e.Age==fn);

            if (get == null)
            {
                return NotFound();
            }

            return View(get);
            //return RedirectToAction("getbyage", "covidcases", covidCase);
        }

        //GET: covidCases/getbyrecorvered
        [HttpGet]
        public async Task<IActionResult> GetByRecorvered()
        {
            var covidCase = await _context.Covid19Trackers
               .Where(m => m.CaseStatus == CaseStatus.Recovered).ToListAsync();
            if (covidCase == null)
            {
                return NotFound();
            }

            return View(covidCase);
        }
        
        //GET: covidCases/getbyDeath
        [HttpGet]
        public async Task<IActionResult> GetByDeath()
        {
            var covidCase = await _context.Covid19Trackers
               .Where(m => m.CaseStatus == CaseStatus.Death).ToListAsync();
            if (covidCase == null)
            {
                return NotFound();
            }

            return View(covidCase);
        }
        
        //GET: covidCases/getbysick
        [HttpGet]
        public async Task<IActionResult> GetBySick()
        {
            var covidCase = await _context.Covid19Trackers
               .Where(m => m.CaseStatus == CaseStatus.Sick).ToListAsync();
            if (covidCase == null)
            {
                return NotFound();
            }

            return View(covidCase);
        }
        // POST: CovidCases/GetByAge
        [HttpGet]
        public async Task<IActionResult> GetAllByState(string state)
        {
            if (state == null)
            {
                return NotFound();
            }
           

            var get = await _context.Covid19Trackers.Where(e => e.State.ToLower() == state.ToLower()).ToListAsync();
            

            if (get == null)
            {
                return NotFound();
            }

            return View(get);
           
        }

        [HttpGet]
        public IActionResult staysafe()
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
                covidCase.Name = "Anonymous";
                covidCase.Age = 0;
                covidCase.Gender = Gender.None;
                covidCase.DateofRecorvery = DateTime.Today;
                covidCase.DateOfDeath = DateTime.Today;
                _context.Add(covidCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(covidCase);
        }

        // GET: CovidCases/Edit/5
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        //[Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
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
