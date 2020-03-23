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


        // Case percentage calculations for chartd
        
        public IActionResult Index()
        {
            var all = Convert.ToDouble(_covid19CaseManager.GetAllCasesCount());
            var recov = Convert.ToDouble(_covid19CaseManager.GetAllRecoveriesCount());
            var sicki = Convert.ToDouble(_covid19CaseManager.GetAllSickCount());
            var deathy = Convert.ToDouble(_covid19CaseManager.GetAllDeathCount());
            double a = recov / all;
            double Getrecoverbar = Math.Round(a*100);
            double b = sicki / all;
            double Getsickbar = Math.Round(b * 100);
            double c = deathy / all;
            double Getdeathbar = Math.Round(a * 100);
            CasesViewModel cases = new CasesViewModel {

                All = _covid19CaseManager.GetAllCasesCount(),
                Death = _covid19CaseManager.GetAllDeathCount(),
                Recorverd = _covid19CaseManager.GetAllRecoveriesCount(),
                Sick = _covid19CaseManager.GetAllSickCount(),
                getrecoverbar = (Getrecoverbar),
                getsickbar = (Getsickbar),
                getdeathbar = (Getdeathbar)
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
