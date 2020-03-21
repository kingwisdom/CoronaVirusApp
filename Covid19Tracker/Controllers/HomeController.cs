using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Covid19Tracker.Models;
using Covid19Tracker.Service.Services;
using Covid19Tracker.Web.ViewModels;

namespace Covid19Tracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICovid19CaseManagerService _covid19CaseManager;

        public HomeController(ILogger<HomeController> logger,ICovid19CaseManagerService covid19CaseManager)
        {
            _logger = logger;
            _covid19CaseManager = covid19CaseManager;
        }

        public IActionResult Index()
        {
            CasesViewModel cases = new CasesViewModel { 
            
                All = _covid19CaseManager.GetAllCasesCount(),
                Death = _covid19CaseManager.GetAllDeathCount(),
                Recorverd = _covid19CaseManager.GetAllRecoveriesCount(),
                Sick = _covid19CaseManager.GetAllSickCount()
            };
            //var model =  _covid19CaseManager.GetAllCasesCount();

            return View(cases);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
