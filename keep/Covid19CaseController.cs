using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid19Tracker.Web.Controllers
{
    public class Covid19CaseController : Controller
    {
        // GET: Covid19Case
        public ActionResult Index()
        {
            return View();
        }

        // GET: Covid19Case/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Covid19Case/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Covid19Case/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Covid19Case/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Covid19Case/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Covid19Case/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Covid19Case/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}